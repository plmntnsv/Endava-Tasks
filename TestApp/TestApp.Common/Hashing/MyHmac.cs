using System.Security.Cryptography;

namespace TestApp.Common.Hashing
{
    public static class MyHmac
    {
        private const int SALT_SIZE = 32;

        public static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[SALT_SIZE];

                rng.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static byte[] ComputeHmac(byte[] data, byte[] salt)
        {
            using(var hmac = new HMACSHA256(salt))
            {
                return hmac.ComputeHash(data);
            }
        }
    }
}
