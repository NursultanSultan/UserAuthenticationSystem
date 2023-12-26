
using System.Security.Cryptography;

namespace UserAuthSystem.Services
{
    public class PasswordHasher
    {
        private const int Iterations = 1000;

        public static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[16];
                rng.GetBytes(salt);
                return salt;
                
            }
        }

        public static byte[] HashPassword(string password, byte[] salt)
        {
            using(var pbkdf2 = new Rfc2898DeriveBytes(password,salt, Iterations))
            {
                return pbkdf2.GetBytes(20);
            }
        }

        public static bool ValidatePassword(string providedPassword, byte[] storedHash, byte[] storedSalt)
        {
            var newHash = HashPassword(providedPassword, storedSalt);
            return newHash.SequenceEqual(storedHash);
        }
    }
}
