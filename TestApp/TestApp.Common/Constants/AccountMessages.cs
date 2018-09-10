namespace TestApp.Common.Constants
{
    public static class AccountMessages
    {
        public const string EMAIL_TOO_LONG = "Email too long.";
        public const string EMAIL_TOO_SHORT = "Email too short.";

        public readonly static string EMAIL_LENGTH_INFO = $"Must be between {AccountStringsContstants.MIN_EMAIL_LENGTH} and {AccountStringsContstants.MAX_EMAIL_LENGTH} characters.";

        public const string PASSWORD_TOO_LONG = "Password too long.";
        public const string PASSWORD_TOO_SHORT = "Password too short.";
        public const string PASSWORD_MISSMATCH = "Passwords do not match.";
        
        public readonly static string PASSWORD_LENGTH_INFO = $"Must be between {AccountStringsContstants.MIN_PASSWORD_LENGTH} and {AccountStringsContstants.MAX_PASSWORD_LENGTH} characters.";

        public const string FIRSTNAME_TOO_LONG = "First name too long.";
        public const string FIRSTNAME_TOO_SHORT = "First name too short.";

        public readonly static string FIRSTNAME_LENGTH_INFO = $"Must be between {AccountStringsContstants.MIN_FIRSTNAME_LENGTH} and {AccountStringsContstants.MAX_FIRSTNAME_LENGTH} characters.";

        public const string LASTNAME_TOO_LONG = "Last name too long.";
        public const string LASTNAME_TOO_SHORT = "Last name too short.";

        public readonly static string LASTNAME_LENGTH_INFO = $"Must be between {AccountStringsContstants.MIN_LASTNAME_LENGTH} and {AccountStringsContstants.MAX_LASTNAME_LENGTH} characters.";
    }
}
