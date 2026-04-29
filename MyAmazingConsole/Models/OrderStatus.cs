namespace MyAmazingConsole.Models;

/// <summary>
/// Represents the lifecycle status of an <see cref="Order"/>.
/// </summary>
public enum OrderStatus
{
    /// <summary>The order has been created but not yet processed.</summary>
    Created,

    /// <summary>The order has been fulfilled and payment confirmed.</summary>
    Completed,

    /// <summary>The order has been dispatched to the customer.</summary>
    Shipped,

    /// <summary>The order is closed and no further changes are permitted.</summary>
    Closed
}
