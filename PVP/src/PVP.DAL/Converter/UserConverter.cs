using PVP.DAL.DBModel;
using PVP.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.DAL.Converter
{
    public static class UserConverter
    {
        public static User CreateUserFromtbUser(tbUser tb_user, List<tbRole> tb_roles)
        {
            User u = new User()
            {
                UserId = tb_user.UserId,
                LoginName = tb_user.LoginName,
                Name = tb_user.Name,
                IsActive = tb_user.IsActive,
                Roles = new List<Role>()
            };

            
            foreach(tbRole r in tb_roles)
            {
                u.Roles.Add(UserConverter.CreateRoleFromtbRole(r));
            }

            return u;
        }

        public static Role CreateRoleFromtbRole(tbRole tb_role)
        {
            return new Role() { RoleId = tb_role.RoleId, Description = tb_role.Description };
        }
    }
}
