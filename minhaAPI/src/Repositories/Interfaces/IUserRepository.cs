using src.Models;
using System.Threading.Tasks;

namespace src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(long id);
        User GetUser(string email);
        void AddUser(User user);
        void Update(User user);
        void Delete(User user);
        Task<User> Login(string email, string password);
    }
}