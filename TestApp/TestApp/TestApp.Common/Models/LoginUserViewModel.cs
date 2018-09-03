using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TestApp.Common.Constants;

namespace TestApp.Common.Models
{
    public class LoginUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid email.")]
        [MaxLength(AccountStringsContstants.MAX_EMAIL_LENGTH, ErrorMessage = AccountMessages.EMAIL_TOO_LONG)]
        [MinLength(AccountStringsContstants.MIN_EMAIL_LENGTH, ErrorMessage = AccountMessages.EMAIL_TOO_SHORT)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [MaxLength(AccountStringsContstants.MAX_PASSWORD_LENGTH, ErrorMessage = AccountMessages.PASSWORD_TOO_LONG)]
        [MinLength(AccountStringsContstants.MIN_PASSWORD_LENGTH, ErrorMessage = AccountMessages.PASSWORD_TOO_SHORT)]
        public string Password { get; set; }
    }
}
