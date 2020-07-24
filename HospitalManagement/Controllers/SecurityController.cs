using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityAPIController : ControllerBase
    {
        // GET: api/SecurityAPI
        [HttpGet]
        

        private string GenerateJSONWebToken(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("238420983409284098230948"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Email,""),
            new Claim("Admin","true"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken("shivani",
              "shivani",
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        // GET: 
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: 
        [HttpPost]
        public IActionResult Post([FromBody] User obj)
        {
            if ((obj.userName == "shivani") && (obj.password == "shivani"))
            {
                obj.token = GenerateJSONWebToken(obj.userName);
                obj.password = "";
                return Ok(obj);
            }
            else
            {
                return StatusCode(401, "Not proprer code");
            }
        }

        // PUT
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
