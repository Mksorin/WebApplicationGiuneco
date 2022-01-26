using LoginAndAuth.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndAuth.Services
{
    public class UsersDAO
    {
        bool valid = false;
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

       
        public bool FindUserByNamePassword(UserModel User)
        {
            string sqlStatement = "SELECT * FROM TestDb.dbo.Users WHERE USERNAME = @username AND PASSWORD  = @password";

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = User.username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = User.password;

                try 
                {
                    sqlConnection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        valid = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + e.StackTrace);
                }
            }
            return valid;
        }

        public int GetUserId(UserModel User)
        {
            int Id = 0;
            string sqlStatement = "SELECT Id FROM TestDb.dbo.Users WHERE USERNAME = @username AND PASSWORD  = @password";

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = User.username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = User.password;

                try
                {
                    sqlConnection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Id = (int)reader[0];
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + e.StackTrace);
                }
            }
            return Id;

        }
    }
}
