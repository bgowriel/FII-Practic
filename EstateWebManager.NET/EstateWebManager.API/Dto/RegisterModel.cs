using System.ComponentModel.DataAnnotations;

namespace EstateWebManager.API.Dto
{
    public class RegisterModel
    {
        [EmailAddress]
        [MinLength(6)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [MinLength(8)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
