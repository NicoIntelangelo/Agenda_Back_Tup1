using Agenda_Back_Tup1.Data;
using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using Agenda_Back_Tup1.Repository.Interfaces;
using System.Diagnostics.Contracts;

namespace Agenda_Back_Tup1.Repository.Implementatios
{
    public class UserRepository : IUserRepository
    {
        
        private readonly AplicationDbContext _context;

        public UserRepository(AplicationDbContext context)
        {
            _context = context;
        }


        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetListUser()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public void UpdateUserData(User user)
        {
            var userItem = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (userItem != null)
            {
                userItem.Nombre = user.Nombre;
                userItem.Telefono = user.Telefono;

                _context.SaveChanges();
            }
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }
    }
}
