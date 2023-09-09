using MAapp1.Model;
using MAapp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAapp1.Controller
{
    internal class Controller
    {
        private MovieManager movieManager;

        public Controller(string filePath)
        {
            movieManager = new MovieManager(filePath);
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Display movies by year");
                Console.WriteLine("2. Add movie");
                Console.WriteLine("3. Clear all");
                Console.WriteLine("4. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            List<Movie> movies = movieManager.DisplayMoviesByYear();
                            if (movies.Count > 0)
                            {
                                Console.WriteLine("Movies sorted by year:");
                                foreach (var movie in movies)
                                {
                                    Console.WriteLine($"ID: {movie.Id}, Name: {movie.Name}, Genre: {movie.Genre}, Year: {movie.Year}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No movies available.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.Write("Enter movie ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter movie Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter movie Genre: ");
                            string genre = Console.ReadLine();

                            Console.Write("Enter movie Year: ");
                            int year = Convert.ToInt32(Console.ReadLine());

                            movieManager.AddMovie(id, name, genre, year);
                            Console.WriteLine("Movie added successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            movieManager.ClearMovies();
                            Console.WriteLine("All movies cleared.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            movieManager.SaveMovies();
                            Console.WriteLine("Exiting the app.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}