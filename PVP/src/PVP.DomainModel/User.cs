using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.DomainModel
{
     public class User : Entity
    {
        public string LoginName { get; set; }
        
        public string Name { get; set; }
        
        public bool IsActive { get; set; }
        
        public List<Role> Roles { get; set; }
    }
}
