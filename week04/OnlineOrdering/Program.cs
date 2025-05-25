using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // First customer(USA)
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Alice Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P010", 1.50, 5));

        // Second customer(International)
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Lee", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N100", 5.25, 3));
        order2.AddProduct(new Product("Pencil", "P011", 0.99, 10));
        order2.AddProduct(new Product("Eraser", "E200", 0.50, 4));

        // Third Customer(USA)
        Address address3 = new Address("789 Oak St", "Los Angeles", "CA", "USA");
        Customer customer3 = new Customer("Charlie Brown", address3);
        Order order3 = new Order(customer3);
        order3.AddProduct(new Product("Laptop", "L300", 999.99, 1));
        order3.AddProduct(new Product("Mouse", "M400", 25.00, 1));
        order3.AddProduct(new Product("Keyboard", "K500", 45.00, 1));
        order3.AddProduct(new Product("Monitor", "M600", 199.99, 2));

        Console.Clear();
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Order Details:");
        PrintOrderDetails(order1);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine();
        PrintOrderDetails(order2);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine();
        PrintOrderDetails(order3);
        Console.WriteLine("--------------------------------------------------");
    }
    static void PrintOrderDetails(Order order) // method to print order details 
    // Printing and user interaction are the responsibility of the program class and keeping this here will help keep the code maintainable if adding more features
    // follows the Single Responsibility Principle
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}\n");
    }
}