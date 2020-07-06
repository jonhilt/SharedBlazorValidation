using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using SharedValidationExample.Shared.Account;

namespace SharedValidationExample.Client.Shared
{
    public class ValidateEmail : IValidateEmail
    {
        private readonly HttpClient _http;

        public ValidateEmail(HttpClient http)
        {
            _http = http;
        }
        
        public async Task<bool> CheckIfUnique(string email, CancellationToken cancellationToken)
        {
            var requestUri = $"account?email={email}";
            
            var existingAccounts = await 
                _http.GetFromJsonAsync<Search.Model>(requestUri, cancellationToken);
            
            return !existingAccounts.Accounts.Any();
        }
    }
}