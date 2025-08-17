using System;

namespace SDP_ASG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup restaurant menu
            Menu mainMenu = new Menu("Main Menu");
            Menu appetizers = new Menu("Appetizers");
            Menu desserts = new Menu("Desserts");
            Menu drinks = new Menu("Drinks");
            mainMenu.add(appetizers);
            mainMenu.add(desserts);
            mainMenu.add(drinks);

            MenuItem springrolls = new FoodMenuItem("Spring Rolls", "Crispy rolls with vegetables", 5.99);
            MenuItem garlicBread = new FoodMenuItem("Garlic Bread", "Toasted bread with garlic butter", 3.99);
            appetizers.add(springrolls);
            appetizers.add(garlicBread);

            MenuItem iceCream = new FoodMenuItem("Ice Cream", "Vanilla ice cream", 4.99);
            MenuItem brownie = new FoodMenuItem("Brownie", "Chocolate brownie with nuts", 6.99);
            desserts.add(iceCream);
            desserts.add(brownie);

            MenuItem iceLemonTea = new BeverageMenuItem("Ice Lemon Tea", "Homemade Iced Lemon Tea", 4.99);
            MenuItem greenTea = new BeverageMenuItem("Green Tea", "Aromatic China Grade Premium Imperial Green Tea", 5.99);
            drinks.add(iceLemonTea);
            drinks.add(greenTea);

            Order currentOrder = null;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Grabberoo Food Delivery ===");
                Console.WriteLine("1. View Menu");
                Console.WriteLine("2. Create New Order");
                Console.WriteLine("3. Add Item to Order");
                Console.WriteLine("4. View Current Order");
                Console.WriteLine("5. Pay & Submit Order");
                Console.WriteLine("6. Cancel Order");
                Console.WriteLine("7. Progress Order (Prepare → Deliver)");
                Console.WriteLine("8. Exit");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Menu ---");
                        Iterator menuIterator = mainMenu.createIterator();
                        while (menuIterator.hasNext())
                        {
                            MenuComponent component = menuIterator.next();
                            component.print();
                        }
                        break;

                    case "2":
                        if (currentOrder != null)
                        {
                            Console.Write("Do you want to create a new order and remove your existing order? 1=yes, 2=no : ");
                            string userChoice = Console.ReadLine();
                            bool removeExistingOrder = userChoice switch
                            {
                                "1" => true,
                                "2" => false,
                                _ => false // default to false
                            };
                            if (!removeExistingOrder)
                            {
                                Console.WriteLine("Existing order was not removed. ");
                                break; // break out of loop
                            }
                        }
                        // continue if user wants to remove existing order
                        Console.WriteLine("Created new order and removed order. ");
                        currentOrder = new Order(DateTime.Now, "123 Main St", "PendingPayment", "Not Paid", true);
                        Console.WriteLine("New order created in state: " + currentOrder.StateName);
                        break;

                    case "3":
                        if (currentOrder == null)
                        {
                            Console.WriteLine("Please create an order first.");
                            break;
                        }
                        Console.WriteLine("Enter item number: 1=Spring Rolls, 2=Garlic Bread, 3=Ice Cream, 4=Brownie, 5=Ice Lemon Tea, 6=Green Tea");
                        string itemChoice = Console.ReadLine();
                        MenuItem selected = itemChoice switch
                        {
                            "1" => springrolls,
                            "2" => garlicBread,
                            "3" => iceCream,
                            "4" => brownie,
                            "5" => iceLemonTea,
                            "6" => greenTea,
                            _ => null
                        };
                        if (selected == null)
                        {
                            Console.WriteLine("Invalid item number selected. ");
                            break;
                        }
                        Console.Write("Quantity: ");
                        int qty = int.Parse(Console.ReadLine());
                        //add extra condiments here
                        // if selected is a beverage
                        OrderItem newOrderItem = null;
                        if (selected is BeverageMenuItem beverage)
                        {
                            Console.WriteLine("Would you like to modify your drink?");
                            OrderItemFactory bevFactory = new BeverageOrderItemFactory();
                            newOrderItem = bevFactory.CreateOrderItem(selected, qty);

                            Console.WriteLine("beverage selected");
                            Console.WriteLine("1 = More Ice");
                            Console.WriteLine("2 = Less Ice");
                            Console.WriteLine("3 = Normal Ice");
                            string iceChoice = Console.ReadLine();
                            newOrderItem = iceChoice switch
                            {
                                "1" => new MoreIce(newOrderItem),
                                "2" => new LessIce(newOrderItem),
                                "3" => newOrderItem,
                                _ => newOrderItem // default to normal ice
                            };
                        } else // if selected is a food
                        {
                            Console.WriteLine("Would you like some extra condiments?");
                            OrderItemFactory foodFactory = new FoodOrderItemFactory();
                            newOrderItem = foodFactory.CreateOrderItem(selected, qty);
                            Console.WriteLine("1 = Cheese");
                            Console.WriteLine("2 = Hot Sauce");
                            Console.WriteLine("3 = No thanks");
                            string iceChoice = Console.ReadLine();
                            newOrderItem = iceChoice switch
                            {
                                "1" => new Cheese(newOrderItem),
                                "2" => new HotSauce(newOrderItem),
                                "3" => newOrderItem,
                                _ => newOrderItem // default to normal ice
                            };
                        }
                        currentOrder.AddItem(newOrderItem);
                        Console.WriteLine($"{((OrderItem)newOrderItem).getQuantity()}x {((OrderItem)newOrderItem).getName()} added.");

                        break;

                    case "4":
                        if (currentOrder != null)
                        {
                            Console.WriteLine("Current Order (" + currentOrder.StateName + "):");
                            currentOrder.PrintItems();
                        }
                        else Console.WriteLine("No order exists.");
                        break;

                    case "5":
                        if (currentOrder == null || currentOrder.IsEmpty())
                        {
                            Console.WriteLine("No items in order.");
                            break;
                        }
                        
                        Console.WriteLine("Choose payment: 1=Credit Card, 2=PayPal, 3=Cash on Delivery");
                        string payChoice = Console.ReadLine();
                        PaymentStrategy payment = payChoice switch
                        {
                            "1" => new CreditCardPayment(currentOrder.GetTotal(), "1234-5678-9012-3456"),
                            "2" => new PayPalPayment(currentOrder.GetTotal(), "user@example.com"),
                            _ => new CashOnDeliveryPayment()
                        };

                        payment.processPayment(currentOrder.GetTotal());
                        currentOrder.PayOrder(); // triggers state machine → PendingOrderState
                        Console.WriteLine("Order state: " + currentOrder.StateName);
                        break;

                    case "6":
                        if (currentOrder != null)
                        {
                            currentOrder.CancelOrder();
                            Console.WriteLine("Order state: " + currentOrder.StateName);
                        }
                        else Console.WriteLine("No active order.");
                        break;

                    case "7":
                        if (currentOrder == null) { Console.WriteLine("No active order."); break; }
                        currentOrder.PrepareOrder();  // PendingOrderState → PrepareOrderState
                        Console.WriteLine("Order state: " + currentOrder.StateName);
                        currentOrder.CompleteOrder(); // PrepareOrderState → CompleteOrderState
                        Console.WriteLine("Order state: " + currentOrder.StateName);
                        currentOrder = null;
                        break;

                    case "8":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
