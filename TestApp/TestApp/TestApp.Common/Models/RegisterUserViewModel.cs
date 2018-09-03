using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TestApp.Common.Constants;

namespace TestApp.Common.Models
{
    public class RegisterUserViewModel
    {
        public int Id { get; set; }

        //[StringLength(maximumLength: StringLengthContstants.MAX_FIRSTNAME_LENGTH, MinimumLength = StringLengthContstants.MIN_FIRSTNAME_LENGTH)]
        [MaxLength(AccountStringsContstants.MAX_FIRSTNAME_LENGTH, ErrorMessage = "First name too long.")]
        [MinLength(AccountStringsContstants.MIN_FIRSTNAME_LENGTH, ErrorMessage = "First name too short.")]
        public string FirstName { get; set; }

        //[StringLength(maximumLength: StringLengthContstants.MAX_LASTNAME_LENGTH, MinimumLength = StringLengthContstants.MIN_LASTNAME_LENGTH)]
        [MaxLength(AccountStringsContstants.MAX_LASTNAME_LENGTH, ErrorMessage = "Last name too long.")]
        [MinLength(AccountStringsContstants.MIN_LASTNAME_LENGTH, ErrorMessage = "Last name too short.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid email.")]
        //[StringLength(maximumLength: StringLengthContstants.MAX_EMAIL_LENGTH, MinimumLength = StringLengthContstants.MIN_EMAIL_LENGTH)]
        [MaxLength(AccountStringsContstants.MAX_EMAIL_LENGTH, ErrorMessage = "Email too long.")]
        [MinLength(AccountStringsContstants.MIN_EMAIL_LENGTH, ErrorMessage = "Email too short.")]
        public string Email { get; set; }

        [Required]
        //[StringLength(maximumLength: StringLengthContstants.MAX_PASSWORD_LENGTH, MinimumLength = StringLengthContstants.MIN_PASSWORD_LENGTH)]
        [MaxLength(AccountStringsContstants.MAX_PASSWORD_LENGTH, ErrorMessage = "Password too long.")]
        [MinLength(AccountStringsContstants.MIN_PASSWORD_LENGTH, ErrorMessage = "Password too short.")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        //[StringLength(maximumLength: StringLengthContstants.MAX_PASSWORD_LENGTH, MinimumLength = StringLengthContstants.MIN_PASSWORD_LENGTH)]
        [MaxLength(AccountStringsContstants.MAX_PASSWORD_LENGTH, ErrorMessage = "Password too long.")]
        [MinLength(AccountStringsContstants.MIN_PASSWORD_LENGTH, ErrorMessage = "Password too short.")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
