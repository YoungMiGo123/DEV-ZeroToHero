using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components.Rendering;

namespace ZeroToHero.BestPractices.TinyLink.Utilities
{
    public class HashHelper
    {
        private static int _hashLength = 8;
        public static string GenerateHash(string input)
        {
            var inputWihSalt = $"{input}{Guid.NewGuid()}";
            return GenerateSha512(inputWihSalt)[.._hashLength];
        }
        private static string GenerateSha512(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
