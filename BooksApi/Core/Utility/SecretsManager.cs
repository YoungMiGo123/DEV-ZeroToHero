using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace BooksApi.Core.Utility
{
    public class SecretsManager
    {
        private static string _keyVaultUri = $"https://booksapi-dev-secrets.vault.azure.net/";
        public static async Task<KeyValuePair<string,string>> SetSecret(string secretName, string secretValue)
        {
            var client = new SecretClient(new Uri(_keyVaultUri), new DefaultAzureCredential());
            await client.SetSecretAsync(secretName, secretValue);
            return new KeyValuePair<string, string>(secretName, secretValue);
        }
        public static async Task<string> GetSecret(string secretName)
        {
            var client = new SecretClient(new Uri(_keyVaultUri), new DefaultAzureCredential());
            var secret = await client.GetSecretAsync(secretName);
            var secretValue = secret.Value.Value;
            return secretValue;
        }
    }
}
