using MyAmazingConsole.Interfaces;
using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _store = [];

    public void Add(Order order)
    {
        if (_store.ContainsKey(order.Id))
            throw new InvalidOperationException($"An order with id {order.Id} already exists.");
        _store[order.Id] = order;
    }

    public Order? GetById(Guid id) =>
        _store.TryGetValue(id, out var order) ? order : null;

    public IReadOnlyList<Order> GetAll() =>
        [.. _store.Values];

    public IReadOnlyList<Order> GetByStatus(OrderStatus status) =>
        [.. _store.Values.Where(o => o.Status == status)];

    public void UpdateStatus(Guid id, OrderStatus status)
    {
        var order = GetById(id)
            ?? throw new KeyNotFoundException($"Order {id} not found.");
        order.Status = status;
    }

    public void Remove(Guid id)
    {
        if (!_store.Remove(id))
            throw new KeyNotFoundException($"Order {id} not found.");
    }
}
