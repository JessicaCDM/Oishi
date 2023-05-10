using System.ComponentModel.DataAnnotations;

namespace Oishi.Shared.ViewModels.Account
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um nome")]
        [MaxLength(48)]
        [MinLength(3, ErrorMessage = "Min - 3 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Insira um email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma senha")]
        [MinLength(8)]
        [MaxLength(32)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$", ErrorMessage = "A sua password precisa de conter pelo menos 8 caracteres, uma letra maiúscula, uma minuscula, um número e um caractere.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Insira a senha novamente")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }

        public Guid? ConfirmationToken { get; set; }
    }
}