using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SharedValidationExample.Server.Controllers;
using SharedValidationExample.Shared.Account;

namespace SharedValidationExample.Server
{
    public class ValidateEmail : IValidateEmail
    {
        private readonly FakeSearch _fakeSearch;

        public ValidateEmail(FakeSearch fakeSearch)
        {
            _fakeSearch = fakeSearch;
        }
        
        public async Task<bool> CheckIfUnique(string email, CancellationToken cancellationToken)
        {
            var existingAccounts = _fakeSearch.Handle(new Search.Query {Email = email});
            return !existingAccounts.Accounts.Any();
        }
    }
}