// Create the menu structure (Composite Pattern)
using SDP_ASG;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu mainMenu = new Menu("Main Menu");
        Menu appetizers = new Menu("Appetizers");
        Menu desserts = new Menu("Desserts");
        mainMenu.add(appetizers);
        mainMenu.add(desserts);

        MenuItem springrolls = new FoodMenuItem("Spring Rolls", "Crispy rolls with vegetables", 5.99);
        MenuItem Garlic = new FoodMenuItem("Garlic Bread", "Toasted bread with garlic butter", 3.99);
        appetizers.add(springrolls);
        appetizers.add(Garlic);
        MenuItem IceCream = new FoodMenuItem("Ice Cream", "Vanilla ice cream", 4.99);
        MenuItem Brownie = new FoodMenuItem("Brownie", "Chocolate brownie with nuts", 6.99);
        desserts.add(IceCream);
        desserts.add(Brownie);

        // Display the menu using the Iterator Pattern
        Console.WriteLine("Menu:");
        Iterator menuIterator = mainMenu.createIterator();
        while (menuIterator.hasNext())
        {
            MenuComponent component = menuIterator.next();
            component.print();
        }


        // Create an order and manage its lifecycle using the State Pattern
        Console.WriteLine("\nOrder Lifecycle:");
        Order order = new Order(DateTime.Now, "123 Main St", "Pending", "Credit Card", true);
        
        order.PayOrder(true); // Transition to PendingOrderState
        order.PrepareOrder(); // Transition to PrepareOrderState
        order.CompleteOrder(); // Transition to CompleteOrderState


        // Create an OrderItem with Factory Method Pattern
        Console.WriteLine("\nCreate OrderItem: ");
        OrderItemFactory foodStall = new FoodOrderItemFactory();
        OrderItem orderItem = foodStall.CreateOrderItem(springrolls, 3);
        orderItem = new Cheese(orderItem);
        // display successful creation of order item
        Console.WriteLine($"{orderItem.getName()} x {orderItem.getQuantity()} : ${orderItem.getCost():N2}");


        // Payment using the Strategy Pattern
        Console.WriteLine("\nPayment:");
        PaymentStrategy creditCardPayment = new CreditCardPayment(100.0, "1234-5678-9012-3456");
        PaymentStrategy payPalPayment = new PayPalPayment(50.0, "user@example.com");
        PaymentStrategy cashOnDelivery = new CashOnDeliveryPayment();

        Console.WriteLine("Paying with Credit Card:");
        creditCardPayment.processPayment(20.0);

        Console.WriteLine("Paying with PayPal:");
        payPalPayment.processPayment(30.0);

        Console.WriteLine("Paying with Cash on Delivery:");
        cashOnDelivery.processPayment(40.0);

        Console.WriteLine("\nMenu with Holiday Discount:");
        mainMenu.Discount(new HolidayDiscount());
        mainMenu.print();

        Console.WriteLine("\nMenu with Student Discount:");
        mainMenu.Discount(new StudentDiscount());
        mainMenu.print();
    }
}