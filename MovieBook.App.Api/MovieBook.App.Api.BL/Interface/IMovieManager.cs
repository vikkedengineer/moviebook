using MovieBook.App.Api.Core.Entities;
using MovieBook.App.Api.Models.DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.App.Api.BL.Interface
{
    public interface IMovieManager
    {
        List<MovieBase> GetMoviesData(int userId);

        MovieBase GetMovie(int movieId);

        bool UpdateMovie(int id, MovieBase movie);
        bool DeleteMovie(int id);

        bool AddMovie(MovieByUser movie);



    }
}
