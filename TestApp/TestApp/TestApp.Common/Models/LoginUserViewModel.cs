﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TestApp.Common.Constants;

namespace TestApp.Common.Models
{
    public class LoginUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        //[StringLength(maximumLength:StringLengthContstants.MAX_EMAIL_LENGTH, MinimumLength = StringLengthContstants.MIN_EMAIL_LENGTH)]
        [MaxLength(StringLengthContstants.MAX_EMAIL_LENGTH, ErrorMessage = "Email too long.")]
        [MinLength(StringLengthContstants.MIN_EMAIL_LENGTH, ErrorMessage = "Email too short.")]
        public string Email { get; set; }

        [Required]
        //[StringLength(maximumLength:StringLengthContstants.MAX_PASSWORD_LENGTH, MinimumLength = StringLengthContstants.MIN_PASSWORD_LENGTH)]
        [DisplayName("Password")]
        [MaxLength(StringLengthContstants.MAX_PASSWORD_LENGTH, ErrorMessage = "Password too long.")]
        [MinLength(StringLengthContstants.MIN_PASSWORD_LENGTH, ErrorMessage = "Password too short.")]
        public string PasswordHash { get; set; }
    }
}
