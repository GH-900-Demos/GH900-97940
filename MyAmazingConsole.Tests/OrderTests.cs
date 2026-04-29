using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests;

public class OrderTests
{
    private static Customer CreateCustomer() =>
        new("Jane", "Doe", "123 Main St");

    private static OrderItem CreateItem(string code = "SKU-1", int quantity = 1, decimal unitCost = 10.00m) =>
        new(code, "Widget", quantity, unitCost);

    // ── Constructor ───────────────────────────────────────────────────────────

    [Fact]
    public void Constructor_SetsCustomer()
    {
        var customer = CreateCustomer();

        var order = new Order(customer);

        Assert.Equal(customer, order.Customer);
    }

    [Fact]
    public void Constructor_DefaultsStatusToCreated()
    {
        var order = new Order(CreateCustomer());

        Assert.Equal(OrderStatus.Created, order.Status);
    }

    [Fact]
    public void Constructor_StartsWithEmptyItemsList()
    {
        var order = new Order(CreateCustomer());

        Assert.Empty(order.Items);
    }

    [Fact]
    public void Constructor_AssignsUniqueId()
    {
        var order1 = new Order(CreateCustomer());
        var order2 = new Order(CreateCustomer());

        Assert.NotEqual(order1.Id, order2.Id);
    }

    [Fact]
    public void Constructor_SetsCreatedAtToUtcNow()
    {
        var before = DateTime.UtcNow;
        var order = new Order(CreateCustomer());
        var after = DateTime.UtcNow;

        Assert.InRange(order.CreatedAt, before, after);
    }

    // ── TotalCost ─────────────────────────────────────────────────────────────

    [Fact]
    public void TotalCost_WithNoItems_ReturnsZero()
    {
        var order = new Order(CreateCustomer());

        Assert.Equal(0m, order.TotalCost);
    }

    [Fact]
    public void TotalCost_WithSingleItem_ReturnsItemTotalCost()
    {
        var order = new Order(CreateCustomer());
        order.AddItem(CreateItem(quantity: 3, unitCost: 5.00m));

        Assert.Equal(15.00m, order.TotalCost);
    }

    [Fact]
    public void TotalCost_WithMultipleItems_ReturnsSumOfAllItemTotalCosts()
    {
        var order = new Order(CreateCustomer());
        order.AddItem(CreateItem("SKU-1", quantity: 2, unitCost: 10.00m));
        order.AddItem(CreateItem("SKU-2", quantity: 3, unitCost: 5.00m));

        Assert.Equal(35.00m, order.TotalCost);
    }

    // ── AddItem ───────────────────────────────────────────────────────────────

    [Fact]
    public void AddItem_AppendsItemToItemsList()
    {
        var order = new Order(CreateCustomer());
        var item = CreateItem();

        order.AddItem(item);

        Assert.Single(order.Items);
        Assert.Contains(item, order.Items);
    }

    [Fact]
    public void AddItem_MultipleItems_AllAppended()
    {
        var order = new Order(CreateCustomer());
        var item1 = CreateItem("SKU-1");
        var item2 = CreateItem("SKU-2");

        order.AddItem(item1);
        order.AddItem(item2);

        Assert.Equal(2, order.Items.Count);
    }

    // ── RemoveItem ────────────────────────────────────────────────────────────

    [Fact]
    public void RemoveItem_WithExistingCode_RemovesItem()
    {
        var order = new Order(CreateCustomer());
        order.AddItem(CreateItem("SKU-1"));

        order.RemoveItem("SKU-1");

        Assert.Empty(order.Items);
    }

    [Fact]
    public void RemoveItem_WithNonExistingCode_LeavesListUnchanged()
    {
        var order = new Order(CreateCustomer());
        order.AddItem(CreateItem("SKU-1"));

        order.RemoveItem("SKU-MISSING");

        Assert.Single(order.Items);
    }

    [Fact]
    public void RemoveItem_WithMultipleMatchingCodes_RemovesAllMatches()
    {
        var order = new Order(CreateCustomer());
        order.AddItem(new OrderItem("SKU-1", "Widget A", 1, 5.00m));
        order.AddItem(new OrderItem("SKU-1", "Widget B", 2, 5.00m));
        order.AddItem(CreateItem("SKU-2"));

        order.RemoveItem("SKU-1");

        Assert.Single(order.Items);
        Assert.Equal("SKU-2", order.Items[0].Code);
    }

    // ── Status ────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(OrderStatus.Completed)]
    [InlineData(OrderStatus.Shipped)]
    [InlineData(OrderStatus.Closed)]
    public void Status_CanBeUpdated(OrderStatus newStatus)
    {
        var order = new Order(CreateCustomer());

        order.Status = newStatus;

        Assert.Equal(newStatus, order.Status);
    }

    // ── ToString ──────────────────────────────────────────────────────────────

    [Fact]
    public void ToString_ContainsOrderId()
    {
        var order = new Order(CreateCustomer());

        Assert.Contains(order.Id.ToString(), order.ToString());
    }

    [Fact]
    public void ToString_ContainsCustomerInfo()
    {
        var customer = CreateCustomer();
        var order = new Order(customer);

        Assert.Contains(customer.ToString(), order.ToString());
    }

    [Fact]
    public void ToString_ContainsStatus()
    {
        var order = new Order(CreateCustomer());

        Assert.Contains(nameof(OrderStatus.Created), order.ToString());
    }

    [Fact]
    public void ToString_ContainsTotalCost()
    {
        var order = new Order(CreateCustomer());
        order.AddItem(CreateItem(quantity: 2, unitCost: 10.00m));

        Assert.Contains("20", order.ToString());
    }
}
