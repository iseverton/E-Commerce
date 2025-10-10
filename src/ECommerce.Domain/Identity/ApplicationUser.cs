using Microsoft.AspNetCore.Identity;

namespace ECommerce.Domain.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ApplicationUser(string firstName,string lastName,string email,string phone)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phone;
        UserName = email;
    }

    public ApplicationUser() { }
}
