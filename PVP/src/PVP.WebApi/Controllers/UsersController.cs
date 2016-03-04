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
        private UserRepository _repository;
        
        public UsersController()
        {
            _repository = new UserRepository();
        }
        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetUsers();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _repository.GetUser(id);
        }

        [HttpPost("{userId}")]
        public void MakeUserAdministrator(int userId)
        {
            BLL.UserBLL bll = new BLL.UserBLL(_repository);
            bll.MakeUserAdministrator(userId);
        }
    }
}
