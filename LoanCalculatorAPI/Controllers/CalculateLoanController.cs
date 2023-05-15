using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.InputParams;
using Infrastructure.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateLoanController : ControllerBase
    {
        // GET: api/<CalculateLoanController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CalculateLoanController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CalculateLoanController>
        [HttpPost]
        public ActionResult Post([FromBody] CalculateLoanInput cli )
        {
            Infrastructure.IComputeLoan cml = new ComputeLoan();
            CalculateLoanResponse clr = cml.CalculateLoan(cli);

            return Ok(clr);
        }

        // PUT api/<CalculateLoanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CalculateLoanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
