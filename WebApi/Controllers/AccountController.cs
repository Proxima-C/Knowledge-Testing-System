using Authorization;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // -> "IdentityDbContext"
        private readonly List<User> people = new List<User>
        {
            new User { UserName="admin@gmail.com", Password="12345", Role = "admin" },
            new User { UserName="qwerty@gmail.com", Password="55555", Role = "user" }
        };

        [HttpPost("token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // create JWT-token
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Your username: {User.Identity.Name}");
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok("Your role: admin");
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            User person = people.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if (person == null)
            {
                return null;
            }
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
