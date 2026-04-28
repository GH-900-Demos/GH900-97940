
using MyAmazingConsole.Interfaces;
using MyAmazingConsole.Models;
using MyAmazingConsole.Repositories;

IOrderRepository repository = new InMemoryOrderRepository();

// --- Create orders ---

var customer1 = new Customer("Alice", "Martin", "12 Rue de la Paix, Paris");
var order1 = new Order(customer1);
order1.AddItem(new OrderItem("SKU-001", "Wireless Keyboard", 2, 49.99m));
order1.AddItem(new OrderItem("SKU-002", "USB-C Hub", 1, 35.00m));
repository.Add(order1);

var customer2 = new Customer("Bob", "Dupont", "5 Avenue Victor Hugo, Lyon");
var order2 = new Order(customer2);
order2.AddItem(new OrderItem("SKU-003", "Mechanical Mouse", 1, 79.90m));
order2.AddItem(new OrderItem("SKU-004", "Monitor 27\"", 1, 349.00m));
repository.Add(order2);

var customer3 = new Customer("Clara", "Lefevre", "8 Boulevard Montmartre, Marseille");
var order3 = new Order(customer3);
order3.AddItem(new OrderItem("SKU-005", "Laptop Stand", 3, 25.00m));
repository.Add(order3);

// --- Display all orders ---

Console.WriteLine("=== All Orders ===");
foreach (var order in repository.GetAll())
    Console.WriteLine(order);

// --- Update statuses ---

repository.UpdateStatus(order1.Id, OrderStatus.Completed);
repository.UpdateStatus(order2.Id, OrderStatus.Shipped);

// --- Filter by status ---

Console.WriteLine("=== Shipped Orders ===");
foreach (var order in repository.GetByStatus(OrderStatus.Shipped))
    Console.WriteLine(order);

Console.WriteLine("=== Completed Orders ===");
foreach (var order in repository.GetByStatus(OrderStatus.Completed))
    Console.WriteLine(order);

// --- Get a single order by ID ---

var found = repository.GetById(order3.Id);
Console.WriteLine($"=== Order by ID: {order3.Id} ===");
Console.WriteLine(found is not null ? found.ToString() : "Not found.");

// --- Remove an order ---

repository.Remove(order3.Id);
Console.WriteLine($"=== After Removing Order {order3.Id} ===");
Console.WriteLine($"Total orders remaining: {repository.GetAll().Count}");

