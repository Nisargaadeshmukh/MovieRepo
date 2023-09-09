using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClassLibrary.Model
{
    internal class MovieManager
    {
        private List<Movie> movies;
        private MovieSerializer movieSerializer;
        private const int MaximumMovieLimit = 5;

        public MovieManager(string filePath)
        {
            movieSerializer = new MovieSerializer(filePath);
            movies = LoadMovies();
        }

        public List<Movie> DisplayMoviesByYear()
        {
            if (movies.Count == 0)
            {
                throw new Exception("No movies available.");
            }
            else
            {
                return movies.OrderBy(movie => movie.Year).ToList();
            }
        }

        public void AddMovie(int id, string name, string genre, int year)
        {
            try
            {
                if (movies.Count < MaximumMovieLimit)
                {
                    movies.Add(new Movie(id, name, genre, year));
                    SaveMovies();
                }
                else
                {
                    throw new Exception("Maximum movie limit reached. Cannot add more movies.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ClearMovies()
        {
            try
            {
                if (movies.Count != 0)
                {
                    movies.Clear();
                    SaveMovies();
                }
                else
                {
                    throw new Exception("No movies to clear.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveMovies()
        {
            movieSerializer.SaveMovies(movies);
        }

        private List<Movie> LoadMovies()
        {
            return movieSerializer.LoadMovies();
        }
    }
}