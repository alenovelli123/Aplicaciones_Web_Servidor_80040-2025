using WebAppClase08.EF;
using WebAppClase08.Interfaces;
using WebAppClase08.Models;

namespace WebAppClase08.Repositories
{
    public class UserRepository(MiDBContext _context) : IUserRepository
    {
        public List<UserViewModel> GetAllUsers()
        {
            return _context.Users
                .Where(u => !u.IsDeleted)
                .Select(u => new UserViewModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    DNI = u.Dni
                })
                .ToList();
        }

        public User GetUserById(long id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id && !u.IsDeleted);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(long id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                user.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}
