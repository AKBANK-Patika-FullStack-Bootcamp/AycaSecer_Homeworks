using DAL.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week1_Homeworks.Controllers
{
    public class MoviesRepository
    {
        private MovieContext _movieContext = new MovieContext();

        public void Insert(Movie movie)
        {
            try
            {
                _movieContext.movies.Add(movie);
                _movieContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LogInsert(new Logger { Message = "Ekleme işlemi yapılırken hata meydana geldi." + ex.Message });
            }

        }

        public List<Movie> Select()
        {

            List<Movie> movieList = new List<Movie>();
            movieList = _movieContext.movies.ToList();
            return movieList;
        }

        public Movie SelectById(int Id)
        {
            Movie movie = new Movie();
            movie = _movieContext.movies.FirstOrDefault(u => u.Id == Id);
            return movie;
        }

        public bool Delete(int Id)
        {
            Movie movie = new Movie();
            movie = SelectById(Id);
            if (movie != null)
            {
                _movieContext.movies.Remove(movie);
                _movieContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Update(Movie movie)
        {
            try
            {
                Movie isMovie = new Movie();
                isMovie = SelectById(movie.Id);
                if (isMovie != null)
                {
                    _movieContext.movies.Update(movie);
                    _movieContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogInsert(new Logger { Message = "Güncelleme işlemi yapılırken hata ile karşılaşıldı" + ex.Message });
            }
        }

        public void LogInsert(Logger logger)
        {
            try
            {
                _movieContext.logger.Add(logger);
                _movieContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
        public void InnerJoın()
        {
            var newList = _movieContext.movies.Join(_movieContext.movieGenres, a => a.GenresId, b => b.Id,

                (movie, movieGenres) => new MovieGenres { Genres = movieGenres.Genres });
        }

        public void CreateUser(APIAuthority user)
        {
            try
            {
                _movieContext.aPIAuthorities.Add(user);
                _movieContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

        public APIAuthority GetAuthUser(APIAuthority authUser)
        {
            APIAuthority aPIAuthority = new APIAuthority();
            if(!string.IsNullOrEmpty(authUser.UserName)&& !string.IsNullOrEmpty(authUser.Password))
            {
                aPIAuthority = _movieContext.aPIAuthorities.FirstOrDefault(u => u.UserName == authUser.UserName && u.Password == authUser.Password);
            }
            return aPIAuthority;
        }
    }
}
