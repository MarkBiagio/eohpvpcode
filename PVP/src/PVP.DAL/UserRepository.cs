using PVP.DomainModel;
using System.Collections.Generic;
using Simple.Data;
using System;

namespace PVP.DAL
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            using (var db = Database.Open())
            {
                List<User> users = db.tbUser.FindAll();
                return users;
            }
        }

        public User GetUser(int userId)
        {
            using (var db = Database.Open())
            {
                User user = db.tbUser.Get(userId);
                return user;
            }
        }

        public Role GetRole(SystemRole role)
        {
            using (var db = Database.Open())
            {
                Role dbRole = db.tbRole.Get((int)role);
                return dbRole;
            }
        }

        public void Save(User user)
        {
            using(var db = Database.Open())
            {
                db.tbUser.UpdateById(user);
            }
        }
    }
}
