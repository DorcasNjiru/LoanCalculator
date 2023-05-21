using LoanCalc.DAL.Services;
using LoanCalculatorAPI.TokenManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGenerateTokencs _generateTokencs;

        public SignInController(IUserService userService, IGenerateTokencs _token)
        {
                _userService = userService;
            _generateTokencs = _token;
        }
        // GET: api/<SignInController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SignInController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SignInController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login log)
        {

           var response = _userService.AuthenticateUser(log.EmailAddress, log.Password);  

            if(response.Success)
            {
                var token = _generateTokencs.GenerateTokenV1(log.EmailAddress);

                response.Token = token; 

                return Ok(response);

            }

            return BadRequest("User does not exist");



        }

        // PUT api/<SignInController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SignInController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class Login
        {
            public string EmailAddress { get; set; }
            public string Password { get; set; }
        }
    }
}
