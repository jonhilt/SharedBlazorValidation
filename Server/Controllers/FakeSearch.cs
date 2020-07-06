using System;
using System.Linq;
using SharedValidationExample.Shared.Account;

namespace SharedValidationExample.Server.Controllers
{
    public class FakeSearch
    {
        public Search.Model Handle(Search.Query query)
        {
            var results = new Search.Model();
           
            // Just some test data to prove this works, if you try to create an account with "exists@exists.com" you'll get a validation error...
            if (query.Email == "exists@exists.com")
            {
                results.Accounts = new[] {new Search.Model.SearchResult {Created = DateTime.Now, Id = 1}};
            }
            else
            {
                results.Accounts = Enumerable.Empty<Search.Model.SearchResult>();
            }

            return results;
        }
    }
}