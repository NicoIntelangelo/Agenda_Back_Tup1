using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;

namespace Agenda_Back_Tup1.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetListUser();
        User GetUser(int id);
        void DeleteUser(User user);
        User AddUser(User user);
        void UpdateUser(User user);
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
    }
}
