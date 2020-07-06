using System;
using System.Collections.Generic;

namespace SharedValidationExample.Shared.Account
{
    public class Search
    {
        public class Query
        {
            public string Email { get; set; }
        }

        public class Model
        {
            public IEnumerable<SearchResult> Accounts { get; set; }

            public class SearchResult
            {
                public int Id { get; set; }
                public DateTime Created { get; set; }
            }
        }
    }
}