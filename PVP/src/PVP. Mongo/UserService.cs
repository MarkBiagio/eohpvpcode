using MongoDB.Bson;
using MongoDB.Driver;
using PVP.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.Mongo
{
    public class UserService
    {

        public List<User> GetUsers()
        {
            IMongoClient _client = new MongoClient();
            IMongoDatabase _database = _client.GetDatabase("pvp");

            var collection = _database.GetCollection<BsonDocument>("user");
            var filter = new BsonDocument();

            var q = from x in collection.FindSync<MongUser>(filter).ToList()
                    select x.getBase();

            return q.ToList();

        }

        public User GetUser(int userId)
        {
            return null;
        }
    }

    public class MongUser : User
    {
        public ObjectId _id { get; set; }

        public User getBase()
        {
            return new User() {
                LoginName = this.LoginName,
                Name = this.Name,
                Roles = new List<Role>(this.Roles),
                UserId = 0
            };
        }
    }
}
