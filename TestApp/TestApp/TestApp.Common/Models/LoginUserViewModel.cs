using System.ComponentModel.DataAnnotations;
using TestApp.Common.Constants;

namespace TestApp.Common.Models
{
    public class LoginUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(maximumLength:StringLengthContstants.MAX_EMAIL_LENGTH, MinimumLength = StringLengthContstants.MIN_EMAIL_LENGTH)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength:StringLengthContstants.MAX_PASSWORD_LENGTH, MinimumLength = StringLengthContstants.MIN_PASSWORD_LENGTH)]
        public string PasswordHash { get; set; }
    }
}
