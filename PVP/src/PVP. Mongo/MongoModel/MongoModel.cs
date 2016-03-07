using MongoDB.Bson;
using PVP.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.Mongo.MongoModel
{
    public class MongUser : User
    {
        public ObjectId _id { get; set; }

        public User getBase()
        {
            return new User()
            {
                LoginName = this.LoginName,
                Name = this.Name,
                Roles = new List<Role>(this.Roles)
            };
        }
    }
}
