using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.DAL.DBModel
{
    public class tbRole
    {
        private int roleId;

        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        private string  description;

        public string  Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
