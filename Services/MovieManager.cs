using MAapp1.Model;
using MApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAapp1.Services
{
    internal class MovieManager
    {
        private List<Movie> movies;
        private MovieSerializer movieSerializer;

        public MovieManager(string filePath)
        {
            movieSerializer = new MovieSerializer(@"D:\movieapp\movies.dat");
            movies = LoadMovies();
        }


        public List<Movie> DisplayMoviesByYear() // Change void to List<Movie>
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available.");
                return new List<Movie>(); // Return an empty list
            }
            else
            {
                Console.WriteLine("Movies sorted by year:");
                foreach (Movie movie in movies.OrderBy(movie => movie.Year))
                {
                    Console.WriteLine($"ID: {movie.Id}, Name: {movie.Name}, Genre: {movie.Genre}, Year: {movie.Year}");
                }

                return movies.OrderBy(movie => movie.Year).ToList(); // Return the sorted list
            }
        
    }

        public void AddMovie(int id, string name, string genre, int year)
        {
            try
            {
                if (movies.Count < 5)
                {
                    movies.Add(new Movie(id, name, genre, year));
                    SaveMovies();
                }
                else
                {
                    throw new Exception("Maximum movie limit reached. Cannot add more movies.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearMovies()
        {
            try
            {
                movies.Clear();
                SaveMovies();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveMovies()
        {
            movieSerializer.SaveMovies(movies);
        }

        public List<Movie> LoadMovies()
        {
            return movieSerializer.LoadMovies();
        }
    }
}

