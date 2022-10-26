using Microsoft.Extensions.Configuration;
using MovieBook.App.Api.Core.Entities;
using MovieBook.App.Api.Core.Interface;
using MovieBook.App.Api.Models.DTO.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.App.Api.Core.Services
{
    public class AccountService: IAccountService
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public AccountService(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DefaultConnection");
        }
        public UserAccount GetUser(UserCredentials userCredentials)
        {
            UserAccount result = null;
            try
            {
                using (con = new SqlConnection(Constr))
                {

                    con.Open();
                    var cmd = new SqlCommand("sp_AuthenticateUser", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", userCredentials.UserName);
                    cmd.Parameters.AddWithValue("@Password", userCredentials.Password);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    UserAccount usr = new UserAccount();

                    while (sqlDataReader.Read())
                    {
                        usr.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        usr.UserName = sqlDataReader["UserName"].ToString();
                        usr.Password = sqlDataReader["UserPassword"].ToString();
                        usr.NickName = sqlDataReader["NickName"].ToString();

                    }
                    if (usr != null && usr.Id != 0)
                    {

                        
                        result = usr;
                    }
                }


            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
        public bool RegisterUser(UserRegister userRegister)
        {
            bool result = false;
            try
            {
                using (con = new SqlConnection(Constr))
                {

                    con.Open();
                    var cmd = new SqlCommand("sp_AddUserBase", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", userRegister.UserName);
                    cmd.Parameters.AddWithValue("@NickName", userRegister.NickName);
                    cmd.Parameters.AddWithValue("@Password", userRegister.Password);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
