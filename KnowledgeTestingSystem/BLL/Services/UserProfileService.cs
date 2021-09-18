using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        readonly IUnitOfWork database;
        readonly IMapper automapper;

        public UserProfileService(IUnitOfWork uow, IMapper mapper)
        {
            this.database = uow;
            this.automapper = mapper;
        }

        public async Task AddAsync(UserProfileDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("User profile can not be null");
            }

            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Name))
            {
                throw new TestingSystemException("User profile has incorrect data");
            }

            UserProfile userProfile = automapper.Map<UserProfile>(model);

            await database.UserProfileRepository.AddAsync(userProfile);
            await database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            UserProfile userProfile = await database.UserProfileRepository.GetByIdAsync(modelId);

            if (userProfile == null)
            {
                throw new TestingSystemException("User profile was not found");
            }

            await database.UserProfileRepository.DeleteByIdAsync(modelId);
            await database.SaveAsync();
        }

        public async Task<IEnumerable<UserProfileDTO>> GetAll()
        {
            IEnumerable<UserProfile> usersProfiles = await database.UserProfileRepository.GetAllAsync();
            return automapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileDTO>>(usersProfiles);
        }

        public async Task<UserProfileDTO> GetByIdAsync(int id)
        {
            UserProfile userProfile = await database.UserProfileRepository.GetByIdAsync(id);

            if (userProfile == null)
            {
                throw new TestingSystemException("User profile was not found");
            }

            UserProfileDTO userProfileModel = automapper.Map<UserProfileDTO>(userProfile);
            return userProfileModel;
        }

        public async Task<UserProfileDTO> GetByUserNameAsync(string username)
        {
            if (username == null)
            {
                throw new TestingSystemException("User name can not be null");
            }

            IEnumerable<UserProfile> userProfiles = await database.UserProfileRepository.GetAllAsync();
            UserProfile userProfile = userProfiles.FirstOrDefault(p => p.UserName == username);

            if (userProfile == null)
            {
                throw new TestingSystemException("User profile was not found");
            }

            UserProfileDTO userProfileModel = automapper.Map<UserProfileDTO>(userProfile);
            return userProfileModel;
        }

        public async Task UpdateAsync(UserProfileDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("User profile can not be null");
            }

            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Name))
            {
                throw new TestingSystemException("User profile has incorrect data");
            }

            UserProfile userProfile = automapper.Map<UserProfile>(model);
            database.UserProfileRepository.Update(userProfile);
            await database.SaveAsync();
        }
    }
}
