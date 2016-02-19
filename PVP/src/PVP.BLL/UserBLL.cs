using PVP.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.BLL
{
    public class UserBLL
    {
        public UserBLL()
        {
        }

        public List<User> GetUsers(){
            PVP.DAL.UserService srv = new DAL.UserService();
            return srv.GetUsers();
            
        }

        public User GetUser(int userId)
        {
            PVP.DAL.UserService srv = new DAL.UserService();
            return srv.GetUser(userId);
   
           
        }
    }
}
