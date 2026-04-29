using MyAmazingConsole.Interfaces;
using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

/// <summary>
/// An in-memory implementation of <see cref="IOrderRepository"/> backed by a <see cref="Dictionary{TKey,TValue}"/>.
/// Intended for development and testing; data is not persisted across application restarts.
/// </summary>
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _store = [];

    /// <inheritdoc/>
    public void Add(Order order)
    {
        if (_store.ContainsKey(order.Id))
            throw new InvalidOperationException($"An order with id {order.Id} already exists.");
        _store[order.Id] = order;
    }

    /// <inheritdoc/>
    public Order? GetById(Guid id) =>
        _store.TryGetValue(id, out var order) ? order : null;

    /// <inheritdoc/>
    public IReadOnlyList<Order> GetAll() =>
        [.. _store.Values];

    /// <inheritdoc/>
    public IReadOnlyList<Order> GetByStatus(OrderStatus status) =>
        [.. _store.Values.Where(o => o.Status == status)];

    /// <inheritdoc/>
    public void UpdateStatus(Guid id, OrderStatus status)
    {
        var order = GetById(id)
            ?? throw new KeyNotFoundException($"Order {id} not found.");
        order.Status = status;
    }

    /// <inheritdoc/>
    public void Remove(Guid id)
    {
        if (!_store.Remove(id))
            throw new KeyNotFoundException($"Order {id} not found.");
    }
}
