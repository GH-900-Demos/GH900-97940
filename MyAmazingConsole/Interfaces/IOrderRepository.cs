using MyAmazingConsole.Models;

namespace MyAmazingConsole.Interfaces;

/// <summary>
/// Defines persistence operations for <see cref="Order"/> entities.
/// </summary>
public interface IOrderRepository
{
    /// <summary>Adds a new order to the repository.</summary>
    /// <param name="order">The order to add.</param>
    /// <exception cref="InvalidOperationException">Thrown when an order with the same ID already exists.</exception>
    void Add(Order order);

    /// <summary>Retrieves an order by its unique identifier.</summary>
    /// <param name="id">The order's unique identifier.</param>
    /// <returns>The matching <see cref="Order"/>, or <c>null</c> if not found.</returns>
    Order? GetById(Guid id);

    /// <summary>Returns all orders in the repository.</summary>
    /// <returns>A read-only list of all orders.</returns>
    IReadOnlyList<Order> GetAll();

    /// <summary>Returns all orders that have the specified status.</summary>
    /// <param name="status">The status to filter by.</param>
    /// <returns>A read-only list of matching orders.</returns>
    IReadOnlyList<Order> GetByStatus(OrderStatus status);

    /// <summary>Updates the status of an existing order.</summary>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <param name="status">The new status to apply.</param>
    /// <exception cref="KeyNotFoundException">Thrown when no order with the given ID exists.</exception>
    void UpdateStatus(Guid id, OrderStatus status);

    /// <summary>Removes an order from the repository.</summary>
    /// <param name="id">The unique identifier of the order to remove.</param>
    /// <exception cref="KeyNotFoundException">Thrown when no order with the given ID exists.</exception>
    void Remove(Guid id);
}
