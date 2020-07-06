using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedValidationExample.Shared.Account;

namespace SharedValidationExample.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly FakeSearch _fakeSearch;

        public AccountController(FakeSearch fakeSearch)
        {
            _fakeSearch = fakeSearch;
        }
        
        // Search
        public async Task<ActionResult<Search.Model>> Search([FromQuery] Search.Query query)
        {
            return Ok(_fakeSearch.Handle(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SignUp signUpRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            // save here
            
            return Ok();
        }
    }
}