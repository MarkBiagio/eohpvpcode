using PVP.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PVP.DAL;

namespace PVP.BLL
{
    public class UserBLL
    {
        UserRepository _repository;

        public UserBLL(UserRepository repository)
        {
            _repository = repository;
        }

        public void MakeUserAdministrator(int userId)
        {
            var user = _repository.GetUser(userId);
            var adminRole = _repository.GetRole(SystemRole.Administrator);

            user.RemoveAllRoles();
            user.AddRole(adminRole);
            _repository.Save(user);
        }
    }
}
