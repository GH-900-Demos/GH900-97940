namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a customer order containing one or more <see cref="OrderItem"/> entries.
/// </summary>
public class Order
{
    /// <summary>Gets the unique identifier for this order.</summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>Gets or sets the customer who placed the order.</summary>
    public Customer Customer { get; set; }

    /// <summary>Gets or sets the list of items included in the order.</summary>
    public List<OrderItem> Items { get; set; } = [];

    /// <summary>Gets or sets the current status of the order.</summary>
    public OrderStatus Status { get; set; } = OrderStatus.Created;

    /// <summary>Gets the UTC date and time when the order was created.</summary>
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    /// <summary>Gets the sum of <see cref="OrderItem.TotalCost"/> for all items in the order.</summary>
    public decimal TotalCost => Items.Sum(i => i.TotalCost);

    /// <summary>
    /// Initializes a new instance of <see cref="Order"/> for the specified customer.
    /// </summary>
    /// <param name="customer">The customer placing the order.</param>
    public Order(Customer customer)
    {
        Customer = customer;
    }

    /// <summary>Adds an <see cref="OrderItem"/> to the order.</summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(OrderItem item) => Items.Add(item);

    /// <summary>
    /// Removes all items whose <see cref="OrderItem.Code"/> matches <paramref name="code"/>.
    /// </summary>
    /// <param name="code">The item code to remove.</param>
    public void RemoveItem(string code) =>
        Items.RemoveAll(i => i.Code == code);

    /// <summary>Returns a multi-line summary of the order including customer, items, and total cost.</summary>
    public override string ToString()
    {
        var lines = new System.Text.StringBuilder();
        lines.AppendLine($"Order {Id} | Status: {Status} | Created: {CreatedAt:u}");
        lines.AppendLine($"Customer: {Customer}");
        lines.AppendLine("Items:");
        foreach (var item in Items)
            lines.AppendLine($"  {item}");
        lines.AppendLine($"Total: {TotalCost:C}");
        return lines.ToString();
    }
}
