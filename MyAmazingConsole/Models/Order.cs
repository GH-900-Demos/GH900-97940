namespace MyAmazingConsole.Models;

public class Order
{
    public Guid Id { get; } = Guid.NewGuid();
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = [];
    public OrderStatus Status { get; set; } = OrderStatus.Created;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public decimal TotalCost => Items.Sum(i => i.TotalCost);

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddItem(OrderItem item) => Items.Add(item);

    public void RemoveItem(string code) =>
        Items.RemoveAll(i => i.Code == code);

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
