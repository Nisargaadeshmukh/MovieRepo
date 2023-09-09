using MAapp1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MApp1.Model
{
    internal class MovieSerializer
    {
        private string filePath;

        public MovieSerializer(string filePath)
        {
            this.filePath = @"D:\movieapp\movies.dat";

        }

        public List<Movie> LoadMovies()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        return (List<Movie>)formatter.Deserialize(fs);
                    }
                }
                return new List<Movie>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading movies: " + ex.Message);
                return new List<Movie>();
            }
        }

        public void SaveMovies(List<Movie> movies)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, movies);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving movies: " + ex.Message);
            }
        }
    }
}