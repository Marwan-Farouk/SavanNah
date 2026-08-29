using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SavanNah.Models.ActionRequests;

public class CreateUserActionRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public bool Remember { get; set; }

    public List<SelectListItem>? Roles { get; set; }
    public List<string>? RoleNames { get; set; }
}