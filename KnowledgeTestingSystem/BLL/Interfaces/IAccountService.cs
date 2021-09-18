using Authorization.Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<object> LoginAsync(LoginModel loginModel);

        Task RegisterAsync(RegisterModel model);
    }
}
