using LoginAndAuth.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGiuneco.Models;

namespace WebApplicationGiuneco.Services
{
    public class ActivityDAO : IActivityService
    {
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(ActivityModel activity)
        {
            throw new NotImplementedException();
        }

        public ActivityModel GetActivityById(int Id)
        {
            ActivityModel foundActivities = null;

            string sqlStatement = "SELECT * FROM TestDb.dbo.Activity where ID = @id";

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundActivities = new ActivityModel { Id = (int)reader[0], Title = (string)reader[1], HoursWorked = (int)reader[3], Description = (string)reader[2], Status = (Status)reader[4] };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + e.StackTrace);
                }

            }
            return foundActivities;
        }

        public List<ActivityModel> GetAllActivity()
        {
            List<ActivityModel> foundActivities = new List<ActivityModel>();

            string sqlStatement = "SELECT * FROM TestDb.dbo.Activity";

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundActivities.Add(new ActivityModel { Id = (int)reader[0], Title = (string)reader[1], HoursWorked = (int)reader[3], Description = (string)reader[2], Status = (Status)reader[4] });
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + e.StackTrace);
                }

            }
            return foundActivities;
        }

        public int Insert(ActivityModel activity)
        {
            throw new NotImplementedException();
        }

        public List<ActivityModel> SearchActivity(string searchItem)
        {
            List<ActivityModel> foundActivities = new List<ActivityModel>();

            string sqlStatement = "SELECT * FROM TestDb.dbo.Activity where Title Like @Title";

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Title", '%' + searchItem + '%');

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundActivities.Add(new ActivityModel { Id = (int)reader[0], Title = (string)reader[1], HoursWorked = (int)reader[3], Description = (string)reader[2], Status = (Status)reader[4] });
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + e.StackTrace);
                }

            }
            return foundActivities;
        }

        public List<ActivityModel> SearchActivityByStatus(int searchItem, int id_user)
        {
            List<ActivityUserModel> activityUserModels = new List<ActivityUserModel>();
            List<ActivityModel> foundActivities = new List<ActivityModel>();

            string sqlStatementActivityUser = "SELECT * from ActivityUser where Id_user = @id_user";

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sqlStatementActivityUser, sqlConnection);
                command.Parameters.AddWithValue("@id_user", id_user);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        activityUserModels.Add(new ActivityUserModel { Id = (int)reader[0], Id_activity = (int)reader[1], Id_user = (int)reader[2] });
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + e.StackTrace);
                }

            }
            foreach (ActivityUserModel activityUserModel in activityUserModels)
            {
                string sqlStatementActivity = "SELECT * from Activity where Id in (@id) and status = @status";
                using (SqlConnection sqlConnection = new SqlConnection(connString))
                {


                    SqlCommand command = new SqlCommand(sqlStatementActivity, sqlConnection);
                    sqlConnection.Open();
                    command.Parameters.AddWithValue("@status", searchItem);
                    command.Parameters.AddWithValue("@id", activityUserModel.Id_activity);
                    try
                    {

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            foundActivities.Add(new ActivityModel { Id = (int)reader[0], Title = (string)reader[1], HoursWorked = (int)reader[3], Description = (string)reader[2], Status = (Status)reader[4] });
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + e.StackTrace);
                    }
                }
            }
            return foundActivities;
        }

        public List<UserModel> SearchUserByActivity( int id_activity)
        {
            List<ActivityUserModel> activityUserModels = new List<ActivityUserModel>();
            List<UserModel> foundUsers = new List<UserModel>();

            string sqlStatementActivityUser = "SELECT * from ActivityUser where Id_Activity = @id_activity";

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sqlStatementActivityUser, sqlConnection);
                command.Parameters.AddWithValue("@id_activity", id_activity);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        activityUserModels.Add(new ActivityUserModel { Id = (int)reader[0], Id_activity = (int)reader[1], Id_user = (int)reader[2] });
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + e.StackTrace);
                }

            }
            foreach (ActivityUserModel activityUserModel in activityUserModels)
            {
                string sqlStatementActivity = "SELECT * from Users where ID in (@id)";
                using (SqlConnection sqlConnection = new SqlConnection(connString))
                {


                    SqlCommand command = new SqlCommand(sqlStatementActivity, sqlConnection);
                    sqlConnection.Open();
                    command.Parameters.AddWithValue("@id", activityUserModel.Id_user);
                    try
                    {

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            foundUsers.Add(new UserModel {ID = (int)reader[0] , username = (string)reader[1], password = (string)reader[2] });
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + e.StackTrace);
                    }
                }
            }
            return foundUsers;
        }
        public int Update(ActivityModel activity)
    {
        throw new NotImplementedException();
    }
}
}
