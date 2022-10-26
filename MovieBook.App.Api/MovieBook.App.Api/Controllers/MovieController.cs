using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBook.App.Api.BL.Interface;
using MovieBook.App.Api.BL.ServiceManager;
using MovieBook.App.Api.Core.Entities;
using MovieBook.App.Api.Models.DTO.Classes;

namespace MovieBook.App.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieController : ControllerBase
    {

        private readonly IMovieManager _movieManager;
        private readonly ILogger<MovieController> _logger;
        // GET: MovieController

        public MovieController(ILogger<MovieController> logger, IMovieManager movieManager)
        {
            _logger = logger;
            _movieManager = movieManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieByUser movieBase)
        {
            
            return Ok(_movieManager.AddMovie(movieBase));
        }

        // GET: MovieController/Details/5
        [Route("GetMovieById")]
        [HttpGet]
        public async Task<IActionResult> ShowMovie(int movieId)
        {
            
            return Ok(_movieManager.GetMovie(movieId));
        }

        // GET: MovieController/Details/5
        [Route("GetMovieByUserId")]
        [HttpGet]
        public async Task<IActionResult> GetMovieByUserId(int userId)
        {

            return Ok(_movieManager.GetMoviesData(userId));
        }

        [Route("DeleteMovie")]
        [HttpGet]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            return Ok(_movieManager.DeleteMovie(id));
        }


        // GET: MovieController/Edit/5
        [Route("UpdateMovie")]
        [HttpGet]
        public async Task<IActionResult> UpdateMovie(int userId, MovieBase movieBase)
        {
            return Ok(_movieManager.UpdateMovie(userId, movieBase));
        }

       
    }
}
