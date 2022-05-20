using System.Linq;
using src.Models;
using src.Repositories.Interfaces;
using src.Context;
using System.Threading.Tasks;
using minhaAPI.src.Repositories;
using Microsoft.EntityFrameworkCore;

namespace src.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async void AddUser(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public User GetUser(long id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUser(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public async void Update(User user)
        {
            //pega no bd 
            User _user = await (from u in _context.Users
                                where u.Id == user.Id
                                select u).SingleOrDefaultAsync();

            //faz as modificações
            _user.Email = user.Email;
            _user.Password = user.Password;


            _context.Users.Attach(_user);
            await _context.SaveChangesAsync();
        }

        public async void Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Login(string email, string password)
        {
            return await (from u in _context.Users
                          where u.Email == email
                          && u.Password == password
                          select u).FirstOrDefaultAsync();
        }
    }
}