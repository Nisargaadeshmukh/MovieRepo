using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieClassLibrary.Model
{
    internal class MovieSerializer
    {
        private string filePath;

        public MovieSerializer(string filePath)
        {
            this.filePath = filePath;
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}






