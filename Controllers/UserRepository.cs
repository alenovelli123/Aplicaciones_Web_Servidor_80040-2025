using WebAppClase08.EF;
using WebAppClase08.Interfaces;

namespace WebAppClase08.Repositories
{
    public class UserRepository(MiDBContext _context) : IUserRepository
    {
        public List<User> GetAllUsers() // CAMBIADO: era List<UserViewModel>
        {
            return _context.Users
                .Where(u => !u.IsDeleted)
                .ToList(); // YA DEVUELVE User directamente
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
