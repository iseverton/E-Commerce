using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public ApplicationRole(string roleName, string description)
    {
        Id = Guid.NewGuid();
        Name = roleName;
        NormalizedName = roleName.ToUpper();
        Description = description;
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }
}
