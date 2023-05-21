using LoanCalc.DAL.Models;
using LoanCalc.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IUserService _userService;
        public AccountsController(IUserService userService)
        {
            _userService = userService;
                
        }
        // GET: api/<AccountsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {

            var response =  _userService.createNewAccount(user);




            return Ok(user);
        }

        [HttpPost, Route("api/Accounts/Login")]

        public async Task<IActionResult> Login([FromBody] User user)
        {

            return Ok(user);

        }


        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
