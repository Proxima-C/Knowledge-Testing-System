using Authorization;
using Authorization.Models;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserProfileService _userProfileService;

        public AccountService(UserManager<AppUser> userManager, IUserProfileService userProfileService)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
        }

        public async Task<object> LoginAsync(LoginModel loginModel)
        {
            var identity = await GetIdentityAsync(loginModel.Username, loginModel.Password);
            if (identity == null) throw new TestingSystemException("Invalid username or password.");

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

            return response;
        }

        public async Task RegisterAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new TestingSystemException("Username already exists.");

            AppUser user = new AppUser()
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                throw new TestingSystemException("User creation failed. Check user data and try again.");

            UserProfileDTO userProfile = new UserProfileDTO()
            {
                UserName = model.Username,
                Name = model.Name
            };
            await _userProfileService.AddAsync(userProfile);
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                return null;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }

            var claimsIdentity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}
