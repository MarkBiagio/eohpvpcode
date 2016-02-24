using PVP.DomainModel;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PVP.DAL
{
    public class UserRepository
    {
        private const string CONNECTION_STRING = "Data Source=tcp:ad16o7zdca.database.windows.net;" +
                "Initial Catalog=PVP.SQL;" +
                "MultipleActiveResultSets=True;" +
                "User Id=EOHStaging; Password=y@l3b123;";

        public UserRepository()
        {

        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection cnn =  new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("prUser_GetUsers", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                cnn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            Id = reader.GetInt32(0),
                            LoginName = reader.GetString(1),
                            Name = reader.GetString(2),
                            IsActive = reader.GetBoolean(3)
                        });
                    }
                }
                
            }
            return users;
        }

        public User GetUser(int userId)
        {
            return new User() { Id = 1, LoginName = "mark@eoh.co.za", Name = "Mark", IsActive = true };
        }

        public List<Role> GetUserRoles(int userId)
        {
            List<Role> roles = new List<Role>();

            using (SqlConnection cnn = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("prRole_GetRoleForUser", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@UserId", System.Data.SqlDbType.Int);
                p.Value = userId;
                command.Parameters.Add(p);
                cnn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role()
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1)
                        });
                    }
                }
            }
            return roles;
        }
    }
}
