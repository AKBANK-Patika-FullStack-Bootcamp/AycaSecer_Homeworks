using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Week1_Homeworks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private List<Movie> _moviesList;
        MovieContext movieDbOperations;
        MoviesRepository repository;


        public MoviesController()
        {
            _moviesList = new List<Movie>();
            movieDbOperations = new MovieContext();
            repository = new MoviesRepository();
            // filledList();
        }
        /// <summary>
        /// Get Movies
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">movies not found</response>
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            _moviesList = repository.Select();
            if (_moviesList == null)
                return NotFound();
            return Ok(_moviesList);
        }

        /// <summary>
        /// Get Movie By MovieId
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">movie not found</response>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovie(int Id)
        {
            // var movie = _moviesList.Where(item => item.Id == Id).FirstOrDefault();
            var movie = repository.SelectById(Id);
            if (movie != null)
                return Ok(movie);
            return NotFound();

        }
        /// <summary>
        /// Delete Movie
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">movie not deleted</response>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMovie(int Id)
        {
            var isDeleted = _moviesList.Remove(_moviesList.Where(item => item.Id == Id).FirstOrDefault());
            if (isDeleted) return Ok(_moviesList);
            else return NotFound();
        }
        /// <summary>
        /// Insert Movie
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">movie not inserted</response>
        [HttpPost]
        public async Task<IActionResult> InsertMovie(Movie movieBody)
        {

            repository.Insert(movieBody);
            if (_moviesList.Contains(movieBody)) return Ok(_moviesList);
            else return NotFound();

        }
        /// <summary>
        /// Update Movie
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">movie not updated</response>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateMovie(int Id, Movie movie)
        {
            var myFindedMovie = _moviesList.Remove(_moviesList.Where(movie => movie.Id == Id).FirstOrDefault());
            if (myFindedMovie)
            {
                _moviesList.Add(movie);
                return Ok(_moviesList);
            }
            else return NotFound();
        }
        public List<Movie> filledList()
        {
            _moviesList.Add(new Movie { Id = 1, MovieTitle = "Spider-Man: No Way Home", MovieOverview = "Peter Parker is unmasked and no longer able to separate his normal life from the high-stakes of being a super-hero. When he asks for help from Doctor Strange the stakes become even more dangerous, forcing him to discover what it truly means to be Spider-Man.", ReleaseDate = Convert.ToDateTime("15/12/2021"), VoteAverage = 8.5 });
            _moviesList.Add(new Movie { Id = 2, MovieTitle = "The Matrix Resurrections", MovieOverview = "Plagued by strange memories, Neo's life takes an unexpected turn when he finds himself back inside the Matrix.", ReleaseDate = Convert.ToDateTime("16/12/2021"), VoteAverage = 7.4 });
            _moviesList.Add(new Movie { Id = 3, MovieTitle = "Red Notice", MovieOverview = "An Interpol-issued Red Notice is a global alert to hunt and capture the world's most wanted. But when a daring heist brings together the FBI's top profiler and two rival criminals, there's no telling what will happen.", ReleaseDate = Convert.ToDateTime("04/11/2021"), VoteAverage = 6.8 });
            _moviesList.Add(new Movie { Id = 4, MovieTitle = "Resident Evil: Welcome to Raccoon City", MovieOverview = "Once the booming home of pharmaceutical giant Umbrella Corporation, Raccoon City is now a dying Midwestern town. The company’s exodus left the city a wasteland…with great evil brewing below the surface. When that evil is unleashed, the townspeople are forever…changed…and a small group of survivors must work together to uncover the truth behind Umbrella and make it through the night.", ReleaseDate = Convert.ToDateTime("24/11/2021"), VoteAverage = 6.2 });
            _moviesList.Add(new Movie { Id = 5, MovieTitle = "Sooryavanshi", MovieOverview = "A fearless, faithful albeit slightly forgetful Mumbai cop, Veer Sooryavanshi, the chief of the Anti-Terrorism Squad in India pulls out all the stops and stunts to thwart a major conspiracy to attack his city.", ReleaseDate = Convert.ToDateTime("11/05/2021"), VoteAverage = 5.5 });
            return _moviesList;
        }
    }
}
