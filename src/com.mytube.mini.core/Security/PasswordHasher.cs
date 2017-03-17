using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PasswordHash
{
    public class PasswordHash
    {
        const int SALT_BYTE_SIZE = 128;
        const int SALT_BASE64_SIZE = 172;

        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string CreateSalt(int size)//TODO: something with size, need checking for password length, because user can send to me a lot of symbols
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var buf = new byte[size];
                rng.GetBytes(buf);
                return Convert.ToBase64String(buf);
            }
        }

        public static string CreateHash(string password)
        {
            var salt = CreateSalt(SALT_BYTE_SIZE);
            using (var algorithm = SHA256.Create())
            {
                var hash = algorithm.ComputeHash(GetBytes(password + salt));
                return salt + Convert.ToBase64String(hash);
            }
        }

        public static bool ValidatePassowrd(string password, string hash)
        {
            var salt = hash.Substring(0, SALT_BASE64_SIZE);
            using (var algorithm = SHA256.Create())
            {
                var newHash = algorithm.ComputeHash(GetBytes(password + salt));
                var oldHash = Convert.FromBase64String(hash.Substring(SALT_BASE64_SIZE));
                return oldHash.SequenceEqual(newHash);
            }
        }
    }
}
