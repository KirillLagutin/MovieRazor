using MovieRazor.Models;
using MovieRazor.Repositories.Interfaces;
using MovieRazor.Services.Interface;
using System.Data;

namespace MovieRazor.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ICustomLogger _logger;

        public MovieRepository (ICustomLogger logger)
        {
            _logger = logger;
        }

        public List<Movie> GetAll()
        {
            return new List<Movie>()
                {
                    new Movie()
                    {
                        Id = 1,
                        Title = "Q",
                        ReleaseDate = new DateOnly(2017, 12, 31),
                        RuntimeMinute = 365,
                        Director = "Z"
                    },
                    new Movie()
                    {
                        Id = 2,
                        Title = "W",
                        ReleaseDate = new DateOnly(2020, 11, 22),
                        RuntimeMinute = 200,
                        Director = "X"
                    },
                    new Movie()
                    {
                        Id = 3,
                        Title = "E",
                        ReleaseDate = new DateOnly(2009, 06, 18),
                        RuntimeMinute = 222,
                        Director = "C"
                    }
                };
        }

        public Movie GetById(int id)
        {
            var allMovies = GetAll();
            return allMovies.First(x => x.Id == id);
        }
    }
}
