using BLL.DTO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserProfileService : ICrud<UserProfileDTO>
    {
        Task<UserProfileDTO> GetByUserNameAsync(string username);
    }
}
