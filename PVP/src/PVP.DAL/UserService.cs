using PVP.DAL.DBModel;
using PVP.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.DAL
{
    public class UserService
    {
        public List<User> GetUsers()
        {
            UserRepository repo = new UserRepository();
            return repo.GetUsers()
                .Select(tbu => Converter.UserConverter.CreateUserFromtbUser(tbu, repo.GetUserRoles(tbu.UserId)))
                .ToList();

        }

        public User GetUser(int userId)
        {
            UserRepository repo = new UserRepository();
            tbUser tbu = repo.GetUser(userId);
            return Converter.UserConverter.CreateUserFromtbUser(tbu, repo.GetUserRoles(tbu.UserId));
        }
    }
}
