using MovieBook.App.Api.BL.Interface;
using MovieBook.App.Api.Core.Entities;
using MovieBook.App.Api.Core.Interface;
using MovieBook.App.Api.Core.Services;
using MovieBook.App.Api.Models.DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.App.Api.BL.ServiceManager
{
    public class MovieManager: IMovieManager
    {
        private readonly IMovieService _movieService;

        public MovieManager(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public List<MovieBase> GetMoviesData(int userId)
        {
            return _movieService.GetMoviesByUserId(userId);
        }

        public MovieBase GetMovie(int movieId)
        {
            return _movieService.GetMovieById(movieId);
        }

        public bool UpdateMovie(int id, MovieBase movie)
        {
            return _movieService.UpdateMovieById(id, movie);
        }
        public bool DeleteMovie(int id)
        {
            return _movieService.DeleteMovieById(id);
        }

        public bool AddMovie(MovieByUser movie)
        {
            int userId = movie.UserId;
            var movieBase = new MovieBase()
            {
                Name = movie.MovieName,
                LanguageId = movie.LanguageId,
                GenreId = movie.GenreId,
            };
            return _movieService.AddMovie(userId, movieBase);
        }
    }
}
