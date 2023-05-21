using LoanCalc.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace LoanCalculatorAPI.TokenManager
{
    public class GenerateToken:IGenerateTokencs
    {

        private readonly IConfiguration _configuration;

        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string  GenerateTokenV1 (string username)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);            //var claims = new[]            //{                //new Claim(ClaimTypes.NameIdentifier,user.Username),                //new Claim(ClaimTypes.Role,user.Role)            //};            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],                _configuration["Jwt:Audience"],                //claims,                expires: DateTime.Now.AddMinutes(15),                signingCredentials: credentials);            return new JwtSecurityTokenHandler().WriteToken(token);



            
        }
    }
}
