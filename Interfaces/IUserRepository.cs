using WebAppClase08.EF;
using WebAppClase08.Models;

namespace WebAppClase08.Interfaces
{
    public interface IUserRepository
    {
        List<UserViewModel> GetAllUsers();
        User GetUserById(long id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
    }
}
