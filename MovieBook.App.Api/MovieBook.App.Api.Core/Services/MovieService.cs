using Microsoft.Extensions.Configuration;
using MovieBook.App.Api.Core.Entities;
using MovieBook.App.Api.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.App.Api.Core.Services
{
    public class MovieService: IMovieService
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public MovieService(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DefaultConnection");
        }
        public List<MovieBase> GetMoviesByUserId(int userId)
        {
            List<MovieBase> result = new List<MovieBase>();
            try
            {
                using (con = new SqlConnection(Constr))
                {

                    con.Open();
                    var cmd = new SqlCommand("Select_UserMovieData", con);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        MovieBase movie = new MovieBase();

                        movie.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        movie.Name = sqlDataReader["MovieName"].ToString();
                        movie.GenreId = Convert.ToInt32(sqlDataReader["GenreId"]);
                        movie.LanguageId = Convert.ToInt32(sqlDataReader["LanguageId"]);
                        result.Add(movie);
                    }
                    con.Close();
                }


            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public MovieBase GetMovieById(int movieId)
        {
            MovieBase result = null;
            try
            {
                using (con = new SqlConnection(Constr))
                {

                    con.Open();
                    var cmd = new SqlCommand("Select_MovieById", con);
                    cmd.Parameters.AddWithValue("@MovieId", movieId);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    MovieBase movie = new MovieBase();

                    while (sqlDataReader.Read())
                    {
                        movie.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        movie.Name = sqlDataReader["MovieName"].ToString();
                        movie.GenreId = Convert.ToInt32(sqlDataReader["GenreId"]);
                        movie.LanguageId = Convert.ToInt32(sqlDataReader["LanguageId"]);

                    }
                    con.Close();
                    if (movie != null)
                    {


                        result = movie;
                    }

                }


            }
            catch (Exception ex)
            {
                throw;

            }
            return result;

        }
        public bool UpdateMovieById(int movieId, Entities.MovieBase movie)
        {
            bool result = false;
            try
            {
                using (con = new SqlConnection(Constr))
                {

                    con.Open();
                    var cmd = new SqlCommand("sp_Update_UserMovieData", con);
                    cmd.Parameters.AddWithValue("@MovieId", movieId);
                    cmd.Parameters.AddWithValue("@MovieName", movie.Name);
                    cmd.Parameters.AddWithValue("@LanguageId", movie.LanguageId);
                    cmd.Parameters.AddWithValue("@GenreId", movie.GenreId);


                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    int output = cmd.ExecuteNonQuery();
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
        public bool DeleteMovieById(int movieId)
        {
            bool result = false;
            try
            {
                using (con = new SqlConnection(Constr))
                {

                    con.Open();
                    var cmd = new SqlCommand("Delete_UserMovieData", con);
                    cmd.Parameters.AddWithValue("@MovieId", movieId);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    int output = cmd.ExecuteNonQuery();

                        result = true;

                }


            }
            catch (Exception ex)
            {
                throw;

            }
            return result;

        }

        public bool AddMovie(int userId, MovieBase movie)
        {
            bool result = false;
            try
            {
                using (con = new SqlConnection(Constr))
                {

                    con.Open();
                    var cmd = new SqlCommand("Create_MovieData", con);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@MovieName", movie.Name);
                    cmd.Parameters.AddWithValue("@LanguageId", movie.LanguageId);
                    cmd.Parameters.AddWithValue("@GenreId", movie.GenreId);


                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    int output = cmd.ExecuteNonQuery();
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
