using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanCalculatorAPI.Controllers
{
     public class upload
    {

        public IFormFile File { get; set; }
        public int ID { get; set; }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        // GET: api/<SendEmailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SendEmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



       

        // POST api/<SendEmailController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile upl)
        {

            return Ok();
        }

        // PUT api/<SendEmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SendEmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
