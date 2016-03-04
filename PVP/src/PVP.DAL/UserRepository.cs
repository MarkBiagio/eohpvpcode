using PVP.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PVP.DAL.DBModel;
using PVP.DAL.Converter;
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
            return GetDbUsers();
        }

        public List<User> GetAllUsers()
        {
            return GetDbUsers()
            .Select(tbu => Converter.UserConverter.CreateUserFromtbUser(tbu, GetUserRoles(tbu.UserId)))
            .ToList();

        }

        private List<tbUser> GetDbUsers() 
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
        }

        public void Save(User user)
        {
            //TODO: persist user
        }

        public Role GetRole(SystemRole role)
        {
            return new Role() { RoleId = (int)role, Description = role.ToString() };
        }

        public tbUser GetUser(int userId)
        {
            return new tbUser() { UserId = 1, LoginName = "mark@eoh.co.za", Name = "Mark", IsActive = true };
                
        }
        
        public User FindUser(int userId)
        {
            return new User() { UserId = userId, LoginName = "mark@eoh.co.za", Name = "Mark", IsActive = true };
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
