using System.Collections.Generic;
using System.Linq;
using DBModel.Interfaces;
using WebCalcNew.Helpers;

namespace WebCalcNew.Managers
{
    public class UserRepository : IUserRepository
    {
        public User Load(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            using (var context = new UserContext())
            {
                return context.Users.ToList();
            }
        }

        public bool Validate(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;
            if (string.IsNullOrWhiteSpace(userName))
                return false;
            using (var context = new UserContext())
            {
                return context.Users.FirstOrDefault(u => u.Login == userName && u.Password == password) != null;
            }
        }
    }
}