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
            //ConnectionString = ConfigurationManager.ConnectionStrings["IgnitorDBConnectionString"].ConnectionString;
            ConnectionString = "Data Source=STARKPC;Initial Catalog=IgnitorDB;Integrated Security=True";
        }

        public UserModel ValidateUser(UserModel userModel)
        {
            try
            {
                using(SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("validate_user", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add(new SqlParameter("@username", userModel.Username));
                        sqlCmd.Parameters.Add(new SqlParameter("@password", userModel.Password));

                        sqlCon.Open();
                        using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                userModel.Username = Convert.ToString(sqlReader["username"]);
                                userModel.Password = Convert.ToString(sqlReader["password"]);
                                userModel.Mobile = Convert.ToString(sqlReader["mobile"]);
                                userModel.Email = Convert.ToString(sqlReader["email"]);
                                userModel.Token = Convert.ToString(sqlReader["token"]);
                            }
                        }
                        sqlCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return userModel;
        }
    }
}
