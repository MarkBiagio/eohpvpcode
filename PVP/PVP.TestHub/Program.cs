using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.TestHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestMongoUsers();
            Console.ReadLine();
        }

        private static void TestMongoUsers()
        {
            try
            {
                PVP.Mongo.UserService srv = new Mongo.UserService();
                var list = srv.GetUsers();
                string json = JsonConvert.SerializeObject(list);
                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
