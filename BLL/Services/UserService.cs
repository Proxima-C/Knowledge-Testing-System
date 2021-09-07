using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        readonly IUnitOfWork database;
        readonly IMapper automapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            this.database = uow;
            this.automapper = mapper;
        }

        public async Task AddAsync(UserDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("User can not be null");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new TestingSystemException("User has incorrect data");
            }

            User user = automapper.Map<User>(model);

            await database.UserRepository.AddAsync(user);
            await database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            User user = await database.UserRepository.GetByIdAsync(modelId);

            if (user == null)
            {
                throw new TestingSystemException("User was not found");
            }

            await database.UserRepository.DeleteByIdAsync(modelId);
            await database.SaveAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            IEnumerable<User> users = await database.UserRepository.GetAllAsync();
            return automapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            User user = await database.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new TestingSystemException("User was not found");
            }

            UserDTO testModel = automapper.Map<UserDTO>(user);
            return testModel;
        }

        public async Task UpdateAsync(UserDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("User can not be null");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new TestingSystemException("User has incorrect data");
            }

            User user = automapper.Map<User>(model);
            database.UserRepository.Update(user);
            await database.SaveAsync();
        }
    }
}
