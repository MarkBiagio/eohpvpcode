using MongoDB.Bson;
using MongoDB.Driver;
using PVP.Mongo.MongoModel;
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


}
