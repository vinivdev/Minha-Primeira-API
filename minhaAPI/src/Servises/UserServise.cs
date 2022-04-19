using minhaAPI.src.Servises.Interfaces;
using src.Models;
using src.Repositories.Interfaces;
using System.Threading.Tasks;

namespace minhaAPI.src.Servises
{
    public class UserServise : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServise(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public User GetUser(long id)
        {
            return _userRepository.GetUser(id);
        }

        public User GetUser(string email)
        {
            User _user = _userRepository.GetUser(email);
            if (_user != null)
            {
                return _user;
            }
            else
            {
                return null;
            }
        }

        public bool Add(User newUser)
        {
            var _user = _userRepository.GetUser(newUser.Email);

            if (_user == null)
            {
                _userRepository.AddUser(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(User user)
        {
            var _user = _userRepository.GetUser(user.Id);
            
            if(_user != null)
            {
                _userRepository.Update(user);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Delete(long id)
        {
            User _user =  _userRepository.GetUser(id);

            if (_user != null)
            {
                _userRepository.Delete(_user);
                return true;
            }
            else
                return false;
        }

        public async Task<User> Login(string email, string senha)
        {
            return await _userRepository.Login(email, senha);
        }
    }
}
