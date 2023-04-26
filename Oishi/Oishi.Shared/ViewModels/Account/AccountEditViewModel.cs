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
        [RegularExpression("/^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Min - 8 caracteres - com pelo menos 1 letra mai�scula, 1 min�scula e 1 n�mero")]
        public string? Password { get; set; }
    }
}