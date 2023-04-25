using System.ComponentModel.DataAnnotations;

namespace Oishi.WebApp.Models
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = "Insira o seu nome de utilizador")]
        [MinLength(3)]
        [MaxLength(48)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Insira um email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [MaxLength(320)]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Number invalid")]
        [MinLength(9)]
        [MaxLength(13)]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Insira a password")]
        [MinLength(8)]
        [MaxLength(32)]     
        public string Password { get; set; }
    }
}