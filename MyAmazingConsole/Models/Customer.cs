namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a customer who can place orders.
/// </summary>
public class Customer
{
    /// <summary>Gets or sets the customer's first name.</summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>Gets or sets the customer's last name.</summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>Gets or sets the customer's delivery address.</summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of <see cref="Customer"/>.
    /// </summary>
    /// <param name="firstName">The customer's first name.</param>
    /// <param name="lastName">The customer's last name.</param>
    /// <param name="address">The customer's delivery address.</param>
    public Customer(string firstName, string lastName, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    /// <summary>Returns a string in the format "FirstName LastName - Address".</summary>
    public override string ToString() =>
        $"{FirstName} {LastName} - {Address}";
}
