using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoInfo.DAL
{
    public class DalStoreProcedure
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DemoInfoConnection"].ConnectionString;

        public DataSet GetDistrict(string storedProcedureName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                DataSet data = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }

        public DataSet RegisterUser(string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                DataSet data = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }

        public DataSet AuthnticateUser(string userEmail, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("[dbo].[User.Authenticate]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = userEmail;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                command.Parameters.Add("@MsgType", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

                DataSet data = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }
        public DataSet GetUserData(string userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("[dbo].[GetUser.Details]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserId", SqlDbType.NVarChar, 100).Value = userId;


                DataSet data = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }
        public DataSet UpdateUserData(string userId, string userName, int districtId, string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("[dbo].[Edit.User.Details]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserId", SqlDbType.NVarChar, 100).Value = userId;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;
                command.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 100).Value = districtId;
                command.Parameters.Add("@UserEmail", SqlDbType.NVarChar, 100).Value = email;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                command.Parameters.Add("@MsgType", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;


                DataSet data = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }

        public DataSet DeleteUserData(string userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("[dbo].[Delete.User]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserId", SqlDbType.NVarChar, 100).Value = userId;
                command.Parameters.Add("@MsgType", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

                DataSet data = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }
    }
}