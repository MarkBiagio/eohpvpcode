using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.DAL.DBModel
{
    public class tbUser
    {

        public tbUser()
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
    }
}
