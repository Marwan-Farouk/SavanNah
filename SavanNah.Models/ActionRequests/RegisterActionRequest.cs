using System.ComponentModel.DataAnnotations;

namespace SavanNah.Models.ActionRequests
{
    public class RegisterActionRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "User Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
