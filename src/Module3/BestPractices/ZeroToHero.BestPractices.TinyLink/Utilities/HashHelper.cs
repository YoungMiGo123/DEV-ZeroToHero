using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components.Rendering;

namespace ZeroToHero.BestPractices.TinyLink.Utilities
{
    public class HashHelper
    {
        public static string GenerateHash(string input)
        {
            return GenerateSha512(input)[..8];
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
