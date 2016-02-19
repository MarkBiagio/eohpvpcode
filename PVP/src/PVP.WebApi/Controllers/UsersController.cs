using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PVP.DomainModel;


namespace PVP.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            BLL.UserBLL bll = new BLL.UserBLL();
            return bll.GetUsers();

        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            BLL.UserBLL bll = new BLL.UserBLL();
            return bll.GetUser(1);
               
        }

    }
}
