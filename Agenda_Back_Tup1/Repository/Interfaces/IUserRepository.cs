using Agenda_Back_Tup1.Entities;

namespace Agenda_Back_Tup1.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetListUser();
        User GetUser(int id);
        void DeleteUser(User user);
        User AddUser(User user);
        void UpdateUser(User user);
    }
}
