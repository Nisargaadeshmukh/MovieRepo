using MAapp1.Controllers;
using MAapp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieClassLibrary.Model;


namespace MAapp1
{
    internal class Program
    {
        static void Main(string[] args)
        {            
                MovieManager movieManager = new MovieManager(@"D:\movieapp\movies.dat");
                MovieController movieController = new MovieController(movieManager);
                movieController.Run();
            }
        }
    }

