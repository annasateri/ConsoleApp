using ConsoleApp.Interfaces;

namespace ConsoleApp.Models;
internal class Contact : IContact
{
    public Contact()
    {
        Id = Guid.NewGuid();
        FirstName = null!;
        LastName = null!;
        Email = null!;
        PhoneNumber = null!;
        Address = null!;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}