namespace MyAmazingConsole.Models;

public class OrderItem
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Quantity), "Quantity must be greater than zero.");
            _quantity = value;
        }
    }

    public decimal UnitCost { get; set; }
    public decimal TotalCost => Quantity * UnitCost;

    public OrderItem(string code, string description, int quantity, decimal unitCost)
    {
        Code = code;
        Description = description;
        Quantity = quantity;
        UnitCost = unitCost;
    }

    public override string ToString() =>
        $"[{Code}] {Description} | Qty: {Quantity} | Unit: {UnitCost:C} | Total: {TotalCost:C}";
}
