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
            mainMenu.add(appetizers);
            mainMenu.add(desserts);

            MenuItem springrolls = new MenuItem("Spring Rolls", "Crispy rolls with vegetables", 5.99);
            MenuItem garlicBread = new MenuItem("Garlic Bread", "Toasted bread with garlic butter", 3.99);
            appetizers.add(springrolls);
            appetizers.add(garlicBread);

            MenuItem iceCream = new MenuItem("Ice Cream", "Vanilla ice cream", 4.99);
            MenuItem brownie = new MenuItem("Brownie", "Chocolate brownie with nuts", 6.99);
            desserts.add(iceCream);
            desserts.add(brownie);

            Order currentOrder = null;
            DiscountStrategy currentDiscount = null;
            bool leave = false;

            while (!leave)
            {
                string role = "";
                while (role != "1" && role != "2")
                {
                    Console.WriteLine("\n=== Grabberoo Food Delivery ===");
                    Console.WriteLine("Select your role");
                    Console.WriteLine("1. Customer");
                    Console.WriteLine("2. Shop Owner");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter choice: ");
                    role = Console.ReadLine();
                }
                bool isCustomer = role == "1";
                bool isShopOwner = role == "2";
                if (role == "3")
                {
                    leave = true;
                    break;
                }
                bool exit = false;

                if (isCustomer)
                {
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
                                mainMenu.Discount(currentDiscount);
                                Iterator menuIterator = mainMenu.createIterator();
                                while (menuIterator.hasNext())
                                {
                                    MenuComponent component = menuIterator.next();
                                    component.print();
                                }
                                break;

                            case "2":
                                currentOrder = new Order(DateTime.Now, "123 Main St", "PendingPayment", "Not Paid", true);
                                Console.WriteLine("New order created in state: " + currentOrder.StateName);
                                break;

                            case "3":
                                if (currentOrder == null)
                                {
                                    Console.WriteLine("Please create an order first.");
                                    break;
                                }
                                Console.WriteLine("Enter item number: 1=Spring Rolls, 2=Garlic Bread, 3=Ice Cream, 4=Brownie");
                                string itemChoice = Console.ReadLine();
                                MenuItem selected = itemChoice switch
                                {
                                    "1" => springrolls,
                                    "2" => garlicBread,
                                    "3" => iceCream,
                                    "4" => brownie,
                                    _ => null
                                };
                                if (selected != null)
                                {
                                    Console.Write("Quantity: ");
                                    int qty = int.Parse(Console.ReadLine());
                                    OrderItemFactory factory = new FoodOrderItemFactory();
                                    currentOrder.AddItem(factory.CreateOrderItem(selected, qty));
                                    Console.WriteLine($"{qty}x {selected.Name} added.");
                                }
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
                else
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n=== Grabberoo Food Delivery ===");
                        Console.WriteLine("1. Add Discount");
                        Console.WriteLine("2. Exit");
                        Console.Write("Select option: ");
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Select discount type:");
                            Console.WriteLine("1. Holiday Discount");
                            Console.WriteLine("2. Shop Anniversary Discount");
                            Console.Write("Enter choice: ");
                            string discountChoice = Console.ReadLine();
                            if (discountChoice == "1")
                            {
                                currentDiscount = new HolidayDiscount();
                                mainMenu.Discount(currentDiscount);
                                Console.WriteLine("Holiday Discount applied.");
                            }
                            else if (discountChoice == "2")
                            {
                                currentDiscount = new ShopAnniversaryDiscount();
                                mainMenu.Discount(currentDiscount);
                                Console.WriteLine("Shop Anniversary Discount applied.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid option.");
                            }
                        }
                        else if (choice == "2")
                        {
                            exit = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option.");
                        }
                    }
                }
            }
        }
    }
}
