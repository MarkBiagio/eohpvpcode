using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.DomainModel
{
     public class   User
    {
        public User()
        {
        }

        private int userId;
        private string loginName;
        private string name;
        private bool isActive;
        
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        private List<Role> roles;

        public List<Role> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public void AddRole(Role role)
        {
            roles.Add(role);
        }
    }
}
