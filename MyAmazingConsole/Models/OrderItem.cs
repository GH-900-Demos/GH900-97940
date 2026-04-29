namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a single line item within an <see cref="Order"/>.
/// </summary>
public class OrderItem
{
    /// <summary>Gets or sets the unique product code (SKU) for this item.</summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>Gets or sets the human-readable description of the item.</summary>
    public string Description { get; set; } = string.Empty;

    private int _quantity;

    /// <summary>
    /// Gets or sets the number of units ordered.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is less than or equal to zero.</exception>
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

    /// <summary>Gets or sets the cost per single unit.</summary>
    public decimal UnitCost { get; set; }

    /// <summary>Gets the total cost for this line item (<see cref="Quantity"/> × <see cref="UnitCost"/>).</summary>
    public decimal TotalCost => Quantity * UnitCost;

    /// <summary>
    /// Initializes a new instance of <see cref="OrderItem"/>.
    /// </summary>
    /// <param name="code">The unique product code (SKU).</param>
    /// <param name="description">A human-readable description of the item.</param>
    /// <param name="quantity">The number of units ordered. Must be greater than zero.</param>
    /// <param name="unitCost">The cost per single unit.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="quantity"/> is less than or equal to zero.</exception>
    public OrderItem(string code, string description, int quantity, decimal unitCost)
    {
        Code = description;
        Description = description;
        Quantity = quantity;
        UnitCost = unitCost;
    }

    /// <summary>Returns a formatted string showing code, description, quantity, unit cost, and total cost.</summary>
    public override string ToString() =>
        $"[{Code}] {Description} | Qty: {Quantity} | Unit: {UnitCost:C} | Total: {TotalCost:C}";
}
