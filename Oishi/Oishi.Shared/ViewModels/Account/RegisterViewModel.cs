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
        [EmailAddress(ErrorMessage = "Email inv�lido")]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma senha")]
        [MinLength(8)]
        [MaxLength(32)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$", ErrorMessage = "A sua password precisa de conter pelo menos 8 caracteres, uma letra mai�scula, uma minuscula, um n�mero e um caractere.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Insira a senha novamente")]
        [Compare("Password", ErrorMessage = "As senhas n�o conferem")]
        public string ConfirmPassword { get; set; }

        public Guid? ConfirmationToken { get; set; }
    }
}