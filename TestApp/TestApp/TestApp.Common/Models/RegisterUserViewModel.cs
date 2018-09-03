using System.ComponentModel.DataAnnotations;
using TestApp.Common.Constants;

namespace TestApp.Common.Models
{
    public class RegisterUserViewModel
    {
        public int Id { get; set; }

        //[StringLength(maximumLength: StringLengthContstants.MAX_FIRSTNAME_LENGTH, MinimumLength = StringLengthContstants.MIN_FIRSTNAME_LENGTH)]
        [MaxLength(StringLengthContstants.MAX_FIRSTNAME_LENGTH, ErrorMessage = "First name too long.")]
        [MinLength(StringLengthContstants.MIN_FIRSTNAME_LENGTH, ErrorMessage = "First name too short.")]
        public string FirstName { get; set; }

        //[StringLength(maximumLength: StringLengthContstants.MAX_LASTNAME_LENGTH, MinimumLength = StringLengthContstants.MIN_LASTNAME_LENGTH)]
        [MaxLength(StringLengthContstants.MAX_LASTNAME_LENGTH, ErrorMessage = "Last name too long.")]
        [MinLength(StringLengthContstants.MIN_LASTNAME_LENGTH, ErrorMessage = "Last name too short.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        //[StringLength(maximumLength: StringLengthContstants.MAX_EMAIL_LENGTH, MinimumLength = StringLengthContstants.MIN_EMAIL_LENGTH)]
        [MaxLength(StringLengthContstants.MAX_EMAIL_LENGTH, ErrorMessage = "Email too long.")]
        [MinLength(StringLengthContstants.MIN_EMAIL_LENGTH, ErrorMessage = "Email too short.")]
        public string Email { get; set; }

        [Required]
        //[StringLength(maximumLength: StringLengthContstants.MAX_PASSWORD_LENGTH, MinimumLength = StringLengthContstants.MIN_PASSWORD_LENGTH)]
        [MaxLength(StringLengthContstants.MAX_PASSWORD_LENGTH, ErrorMessage = "Password too long.")]
        [MinLength(StringLengthContstants.MIN_PASSWORD_LENGTH, ErrorMessage = "Password too short.")]
        public string Password { get; set; }

        [Required]
        //[StringLength(maximumLength: StringLengthContstants.MAX_PASSWORD_LENGTH, MinimumLength = StringLengthContstants.MIN_PASSWORD_LENGTH)]
        [MaxLength(StringLengthContstants.MAX_PASSWORD_LENGTH, ErrorMessage = "Password too long.")]
        [MinLength(StringLengthContstants.MIN_PASSWORD_LENGTH, ErrorMessage = "Password too short.")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
