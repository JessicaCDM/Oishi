using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Shared.ViewModels.Account
{
    public class AccountEditViewModel
    {
        [DisplayName("Nome de utilizador")]
        [Required(ErrorMessage = "Insira o nome de utilizador")]
        [MaxLength(48)]
        [MinLength(3, ErrorMessage = "Min - 3 caracteres")]
        public string Username { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Insira um email")]
        [EmailAddress(ErrorMessage = "Email inv�lido")]
        [MaxLength(320)]
        public string Email { get; set; }

        [DisplayName("Telem�vel")]
        [Phone(ErrorMessage = "Number inv�lido")]
        [MinLength(9, ErrorMessage = "Min - 9 caracteres")]
        [MaxLength(13)]
        public string? Phone { get; set; }

        [DisplayName("Palavra-passe")]
        [MinLength(8)]
        [MaxLength(32)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$", ErrorMessage = "A sua password precisa de conter pelo menos 8 caracteres, uma letra mai�scula, uma minuscula, um n�mero e um caractere.")]
        public string? Password { get; set; }

    }
}