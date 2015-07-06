using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DBHandler.Entities;
using System.Data.SqlClient;
using System.Data;
namespace DBHandler
{
    public class DBClass
    {
        public static string ConnectionString=null;

        public DBClass()
        {
            //Todo : set this out
            ConnectionString = ConfigurationManager.ConnectionStrings["IgnitorDBConnectionString"].ConnectionString;
            //ConnectionString = "Data Source=STARKPC;Initial Catalog=IgnitorDB;Integrated Security=True";
        }

        public UserModel ValidateUser(UserModel userModel)
        {
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("ig_validate_user", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@username", userModel.Username));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", userModel.Password));

                        sqlConnection.Open();
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                userModel.Username = Convert.ToString(sqlDataReader["username"]);
                                userModel.Password = Convert.ToString(sqlDataReader["password"]);
                                userModel.Mobile = Convert.ToString(sqlDataReader["mobile"]);
                                userModel.Email = Convert.ToString(sqlDataReader["email"]);
                                userModel.Token = Convert.ToString(sqlDataReader["token"]);
                            }
                        }
                        sqlConnection.Close();
                    }
                }
            }
             catch (Exception exception)
            {
                throw;
            }
            userModel.Password = "";
            return userModel;
        }

        public int TotalUser()
        {
            int TotalUser=0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("ig_total_user", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();
                        TotalUser = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return TotalUser;
        }

        public List<SendQuotesModel> GetAllQuotes()
        {
            List<SendQuotesModel> QuotesList = new List<SendQuotesModel>();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("ig_crud_quotes", sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@id", 1));
                        sqlCommand.Parameters.Add(new SqlParameter("@StatementType", "selectall"));
                        sqlCon.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            QuotesList.Add(new SendQuotesModel { Id = Convert.ToInt32(sqlDataReader["Id"]), QuoteText = sqlDataReader["QuoteText"].ToString(), QouteAuthor = (string)sqlDataReader["QuoteAuthor"].ToString(), CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]), Category = sqlDataReader["CategoryName"].ToString() });
                        }
                        sqlCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // LogUtility.Error("cUserDbHandler.cs", "ValidateUser_DA", ex.Message, ex);
            }
            return QuotesList;
        }

        public void SetPhotoOnFriendMobile(ReceivePhotoModel receivePhotoModel)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("ig_crud_quotes", sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@id", 1));
                        sqlCommand.Parameters.Add(new SqlParameter("@StatementType", "selectall"));
                        sqlCon.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        //while (sqlDataReader.Read())
                        //{
                        //    QuotesList.Add(new SendQuotesModel { Id = Convert.ToInt32(sqlDataReader["Id"]), QuoteText = sqlDataReader["QuoteText"].ToString(), QouteAuthor = (string)sqlDataReader["QuoteAuthor"].ToString(), CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]), Category = sqlDataReader["CategoryName"].ToString() });
                        //}
                        sqlCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // LogUtility.Error("cUserDbHandler.cs", "ValidateUser_DA", ex.Message, ex);
            }
           // return QuotesList;
        }
    }
}
