using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();

        Task AddAsync(CreateUserDTO model);

        Task UpdateAsync(UserDTO model);

        Task<UserDTO> GetByIdAsync(string userId);

        Task DeleteByIdAsync(string userId);
    }
}
