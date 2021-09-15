using Authorization;
using Authorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Token([FromBody] LoginModel loginModel)
        {
            var identity = await GetIdentityAsync(loginModel.Username, loginModel.Password);
            if (identity == null) return BadRequest("Invalid username or password.");

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTimeInMinutes)),
                    claims: identity.Claims,
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return BadRequest("Username already exists.");

            AppUser user = new AppUser()
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest("User creation failed. Check user data and try again.");

            return Ok("User created successfully.");
        }

        #region testing
        [Authorize]
        [Route("getlogin")]
        [HttpGet]
        public IActionResult GetLogin()
        {
            return Ok($"Your username: {User.Identity.Name}");
        }

        [Authorize(Roles = "Admin")]
        [Route("isandmin")]
        [HttpGet]
        public IActionResult IsAdmin()
        {
            return Ok("Your role: admin");
        }

        [Authorize(Roles = "Moderator")]
        [Route("ismoderator")]
        [HttpGet]
        public IActionResult IsModerator()
        {
            return Ok("Your role: moderator");
        }
        #endregion

        private async Task<ClaimsIdentity> GetIdentityAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            var role = await _userManager.GetRolesAsync(user);

            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                return null;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role.FirstOrDefault())
                };

            var claimsIdentity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}
