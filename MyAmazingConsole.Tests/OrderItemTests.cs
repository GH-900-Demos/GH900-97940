using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests;

public class OrderItemTests
{
    // ── Constructor validation ────────────────────────────────────────────────

    [Fact]
    public void Constructor_WithPositiveQuantity_CreatesInstance()
    {
        var item = new OrderItem("SKU-1", "Widget", 5, 9.99m);

        Assert.Equal("SKU-1", item.Code);
        Assert.Equal("Widget", item.Description);
        Assert.Equal(5, item.Quantity);
        Assert.Equal(9.99m, item.UnitCost);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Constructor_WithNonPositiveQuantity_ThrowsArgumentOutOfRangeException(int quantity)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new OrderItem("SKU-1", "Widget", quantity, 9.99m));
    }

    // ── Property setter validation ────────────────────────────────────────────

    [Fact]
    public void QuantitySetter_WithPositiveValue_UpdatesQuantity()
    {
        var item = new OrderItem("SKU-1", "Widget", 1, 9.99m);

        item.Quantity = 10;

        Assert.Equal(10, item.Quantity);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void QuantitySetter_WithNonPositiveValue_ThrowsArgumentOutOfRangeException(int quantity)
    {
        var item = new OrderItem("SKU-1", "Widget", 1, 9.99m);

        Assert.Throws<ArgumentOutOfRangeException>(() => item.Quantity = quantity);
    }

    // ── TotalCost calculation ─────────────────────────────────────────────────

    [Fact]
    public void TotalCost_ReturnsQuantityMultipliedByUnitCost()
    {
        var item = new OrderItem("SKU-1", "Widget", 3, 10.00m);

        Assert.Equal(30.00m, item.TotalCost);
    }
}
