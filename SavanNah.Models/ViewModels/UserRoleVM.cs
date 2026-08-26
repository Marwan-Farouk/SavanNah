using Microsoft.AspNetCore.Mvc.Rendering;

namespace SavanNah.Models.ViewModels;

public class UserRoleVM
{
    public string UserId { get; set; }
    public List<string> RoleNames { get; set; }
    public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
}