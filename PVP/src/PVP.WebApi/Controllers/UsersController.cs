using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PVP.DAL;
using PVP.DomainModel;


namespace PVP.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            #region Pragmatic way
            //Pragmatic change 1
            //var repository = new UserRepository();
            //return repository.GetAllUsers();
            #endregion
            
            BLL.UserBLL bll = new BLL.UserBLL();
            return bll.GetUsers();

        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            //Pragmatic change 1
            //var repository = new UserRepository();
            //return repository.FindUser(id);
            
            BLL.UserBLL bll = new BLL.UserBLL();
            return bll.GetUser(1);
        }
        
        //Pragmatic attempt to make a user an administrator
        [HttpPost("{userId}")]
        public void MakeUserAdministrator(int userId)
        {
            var repo = new UserRepository();
            var user = repo.FindUser(userId);
            var adminRole = repo.GetRole(SystemRole.Administrator);
            
            user.Roles.Clear();
            user.AddRole(adminRole);
            repo.Save(user);

            //Purist change to layer
            //var bll = new BLL.UserBLL();
            //bll.MakeUserAdministrator(userId);
        }

    }
}
