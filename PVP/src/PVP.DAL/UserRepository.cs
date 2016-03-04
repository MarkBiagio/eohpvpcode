using PVP.DomainModel;
using System.Collections.Generic;
using Simple.Data;

namespace PVP.DAL
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            var db = Database.Open();
            List<User> users = db.tbUser.FindAll();
            return users;
        }

        public User GetUser(int userId)
        {
            var db = Database.Open();
            User user = db.tbUser.Get(userId);
            return user;
        }
    }
}
