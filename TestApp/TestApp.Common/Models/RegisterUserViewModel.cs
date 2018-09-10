using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TestApp.Common.Constants;

namespace TestApp.Common.Models
{
    public class RegisterUserViewModel
    {
        public int Id { get; set; }
        
        //[MaxLength(AccountStringsContstants.MAX_FIRSTNAME_LENGTH, ErrorMessage = AccountMessages.FIRSTNAME_TOO_LONG)]
        //[MinLength(AccountStringsContstants.MIN_FIRSTNAME_LENGTH, ErrorMessage = AccountMessages.FIRSTNAME_TOO_SHORT)]
        //public string FirstName { get; set; }
        
        //[MaxLength(AccountStringsContstants.MAX_LASTNAME_LENGTH, ErrorMessage = AccountMessages.LASTNAME_TOO_LONG)]
        //[MinLength(AccountStringsContstants.MIN_LASTNAME_LENGTH, ErrorMessage = AccountMessages.LASTNAME_TOO_SHORT)]
        //public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid email.")]
        [MaxLength(AccountStringsContstants.MAX_EMAIL_LENGTH, ErrorMessage = AccountMessages.EMAIL_TOO_LONG)]
        [MinLength(AccountStringsContstants.MIN_EMAIL_LENGTH, ErrorMessage = AccountMessages.EMAIL_TOO_SHORT)]
        public string Email { get; set; }

        [Required]
        [MaxLength(AccountStringsContstants.MAX_PASSWORD_LENGTH, ErrorMessage = AccountMessages.PASSWORD_TOO_LONG)]
        [MinLength(AccountStringsContstants.MIN_PASSWORD_LENGTH, ErrorMessage = AccountMessages.PASSWORD_TOO_SHORT)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(AccountStringsContstants.MAX_PASSWORD_LENGTH, ErrorMessage = AccountMessages.PASSWORD_TOO_LONG)]
        [MinLength(AccountStringsContstants.MIN_PASSWORD_LENGTH, ErrorMessage = AccountMessages.PASSWORD_TOO_SHORT)]
        [Compare("Password", ErrorMessage = AccountMessages.PASSWORD_MISSMATCH)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
