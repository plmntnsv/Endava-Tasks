using System.ComponentModel.DataAnnotations;
using TestApp.Common.Constants;

namespace TestApp.Common.Models
{
    public class RegisterUserViewModel
    {
        public int Id { get; set; }

        [StringLength(maximumLength: StringLengthContstants.MAX_FIRSTNAME_LENGTH, MinimumLength = StringLengthContstants.MIN_FIRSTNAME_LENGTH)]
        public string FirstName { get; set; }

        [StringLength(maximumLength: StringLengthContstants.MAX_LASTNAME_LENGTH, MinimumLength = StringLengthContstants.MIN_LASTNAME_LENGTH)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(maximumLength: StringLengthContstants.MAX_EMAIL_LENGTH, MinimumLength = StringLengthContstants.MIN_EMAIL_LENGTH)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: StringLengthContstants.MAX_PASSWORD_LENGTH, MinimumLength = StringLengthContstants.MIN_PASSWORD_LENGTH)]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength: StringLengthContstants.MAX_PASSWORD_LENGTH, MinimumLength = StringLengthContstants.MIN_PASSWORD_LENGTH)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
