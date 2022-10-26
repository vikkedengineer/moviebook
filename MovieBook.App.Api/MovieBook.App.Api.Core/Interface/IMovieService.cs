using MovieBook.App.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.App.Api.Core.Interface
{
    public interface IMovieService
    {
        List<MovieBase> GetMoviesByUserId(int userId);

        MovieBase GetMovieById(int movieId);
        bool UpdateMovieById(int id, MovieBase movie);
        bool DeleteMovieById(int id);

        bool AddMovie(int userId, MovieBase movie);

    }
}
