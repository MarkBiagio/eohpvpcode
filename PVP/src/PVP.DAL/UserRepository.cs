using PVP.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PVP.DAL.DBModel;
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

        public List<tbUser> GetUsers()
        {
            List<tbUser> tbUsers = new List<tbUser>();

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
                        tbUsers.Add(new tbUser()
                        {
                            UserId = reader.GetInt32(0),
                            LoginName = reader.GetString(1),
                            Name = reader.GetString(2),
                            IsActive = reader.GetBoolean(3)
                        });
                        
                    }
                }
                
            }
            return tbUsers;
            //return new List<tbUser> {
            //    new tbUser() { UserId = 1, LoginName = "mark@eoh.co.za", Name= "Mark", IsActive=true },
            //    new tbUser() { UserId = 2, LoginName = "adriaan@eoh.co.za", Name= "Adriaan" , IsActive=true},
            //};
        }

        public tbUser GetUser(int userId)
        {
            return new tbUser() { UserId = 1, LoginName = "mark@eoh.co.za", Name = "Mark", IsActive = true };
                
        }

        public List<tbRole> GetUserRoles(int userId)
        {
            List<tbRole> tbRoles = new List<tbRole>();

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
                        tbRoles.Add(new tbRole()
                        {
                            RoleId = reader.GetInt32(0),
                            Description = reader.GetString(1)
                        });

                    }
                }

                
            }
            return tbRoles;

            //return new List<tbRole> {
            //    new tbRole() { RoleId = 1, Description = "User"},
            //    new tbRole() { RoleId = 2, Description = "Administrator"},
            //};
        }
    }
}
