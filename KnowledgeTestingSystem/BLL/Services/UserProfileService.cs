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

        public async Task AddAsync(UserDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("User profile can not be null");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new TestingSystemException("User profile has incorrect data");
            }

            IEnumerable<UserProfile> usersProfiles = await database.UserProfileRepository.GetAllAsync();
            if (usersProfiles.Any(u => u.UserName == model.UserName))
            {
                throw new TestingSystemException("Username already exists");
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

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            IEnumerable<UserProfile> usersProfiles = await database.UserProfileRepository.GetAllAsync();
            return automapper.Map<IEnumerable<UserProfile>, IEnumerable<UserDTO>>(usersProfiles);
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            UserProfile userProfile = await database.UserProfileRepository.GetByIdAsync(id);

            if (userProfile == null)
            {
                throw new TestingSystemException("User profile was not found");
            }

            UserDTO testModel = automapper.Map<UserDTO>(userProfile);
            return testModel;
        }

        public async Task UpdateAsync(UserDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("User profile can not be null");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new TestingSystemException("User profile has incorrect data");
            }

            IEnumerable<UserProfile> usersProfiles = await database.UserProfileRepository.GetAllAsync();
            if (usersProfiles.Any(u => u.UserName == model.UserName))
            {
                throw new TestingSystemException("Username already exists");
            }

            UserProfile userProfile = automapper.Map<UserProfile>(model);
            database.UserProfileRepository.Update(userProfile);
            await database.SaveAsync();
        }
    }
}
