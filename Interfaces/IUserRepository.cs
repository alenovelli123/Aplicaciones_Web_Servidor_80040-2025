using WebAppClase08.EF;

namespace WebAppClase08.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers(); // CAMBIADO: era List<UserViewModel>
        User GetUserById(long id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
    }
}
