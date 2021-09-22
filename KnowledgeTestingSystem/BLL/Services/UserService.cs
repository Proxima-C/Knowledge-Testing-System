using Authorization.Models;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserProfileService _userProfileService;

        public UserService(UserManager<AppUser> userManager, IUserProfileService userProfileService)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
        }

        public async Task AddAsync(CreateUserDTO model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                throw new TestingSystemException("Username already exists.");

            AppUser appUser = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded)
                throw new TestingSystemException("User creation failed.Check user data and try again.");

            UserProfileDTO userProfile = new UserProfileDTO()
            {
                UserName = model.UserName,
                Name = model.Name,
            };
            await _userProfileService.AddAsync(userProfile);
        }

        public async Task DeleteByIdAsync(string userId)
        {
            AppUser appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                throw new TestingSystemException("User was not found");
            }

            var result = await _userManager.DeleteAsync(appUser);

            if (!result.Succeeded)
            {
                throw new TestingSystemException("User deletion failed. Check user data and try again.");
            }

            UserProfileDTO userProfile = await _userProfileService.GetByUserNameAsync(appUser.UserName);

            await _userProfileService.DeleteByIdAsync(userProfile.Id);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            IEnumerable<UserProfileDTO> usersProfiles = await _userProfileService.GetAllAsync();
            IEnumerable<AppUser> appUsers = await _userManager.Users.ToListAsync();
            IEnumerable<UserDTO> users = (
                from appUser in appUsers
                let userProfile = usersProfiles.FirstOrDefault(i => i.UserName == appUser.UserName)
                select new UserDTO()
                {
                    UserId = appUser.Id,
                    ProfileId = userProfile.Id,
                    UserName = appUser.UserName,
                    Name = userProfile.Name,
                    Email = appUser.Email,
                    UserTestStatisticsIds = userProfile.UserTestStatisticsIds,
                });
            return users;
        }

        public async Task<UserDTO> GetByIdAsync(string userId)
        {
            AppUser appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                throw new TestingSystemException("User was not found");
            }

            UserProfileDTO userProfile = await _userProfileService.GetByUserNameAsync(appUser.UserName);

            UserDTO userDTO = new UserDTO()
            {
                UserId = appUser.Id,
                ProfileId = userProfile.Id,
                UserName = appUser.UserName,
                Name = userProfile.Name,
                Email = appUser.Email,
                UserTestStatisticsIds = userProfile.UserTestStatisticsIds
            };

            return userDTO;
        }

        public async Task UpdateAsync(UserDTO model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                throw new TestingSystemException("Username already exists.");

            AppUser appUser = await _userManager.FindByIdAsync(model.UserId);

            if (appUser == null)
            {
                throw new TestingSystemException("User was not found");
            }

            appUser.UserName = model.UserName;
            appUser.Email = model.Email;

            UserProfileDTO userProfile = new UserProfileDTO()
            {
                Id = model.ProfileId,
                UserName = model.UserName,
                Name = model.Name,
            };

            var result = await _userManager.UpdateAsync(appUser);

            if (!result.Succeeded)
            {
                throw new TestingSystemException("User update failed. Check user data and try again.");
            }

            await _userProfileService.UpdateAsync(userProfile);
        }
    }
}
