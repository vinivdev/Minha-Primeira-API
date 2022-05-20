using src.Models;
using System.Threading.Tasks;

namespace minhaAPI.src.Servises.Interfaces
{
    public interface IUserService
    {
        User GetUser(long id);
        User GetUser(string email);
        bool Add(User user);
        bool Update(User user);
        bool Delete(long id);
        Task<User> Login(string email, string password);
    }
}
