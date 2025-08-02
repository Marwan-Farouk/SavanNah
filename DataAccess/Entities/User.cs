using System;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities;

public class User : IdentityUser<Guid>
{
    public DateTime DateCreated { get; set; }
}
