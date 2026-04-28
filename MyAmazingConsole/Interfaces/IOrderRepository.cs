using MyAmazingConsole.Models;

namespace MyAmazingConsole.Interfaces;

public interface IOrderRepository
{
    void Add(Order order);
    Order? GetById(Guid id);
    IReadOnlyList<Order> GetAll();
    IReadOnlyList<Order> GetByStatus(OrderStatus status);
    void UpdateStatus(Guid id, OrderStatus status);
    void Remove(Guid id);
}
