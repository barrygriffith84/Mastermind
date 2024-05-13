using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Auth
{
    internal class Hashing
    {
        private static string CreateSalt(Guid rockSalt)
        {
            var groundSalt = rockSalt.ToString().Split("-");

            string mixedSalt = groundSalt[1].Substring(0, 2) + groundSalt[2].Substring(1, 2) + groundSalt[3].Substring(2);

            return mixedSalt;
        }
        internal static string CreateHashString(string stringToHash, Guid rockSalt)
        {
            string salt = CreateSalt(rockSalt);

            using (SHA256 sha256Hash = SHA256.Create())
            {

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHash + salt));


                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }
    }
}

