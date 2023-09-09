using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAapp1.Controller;
using MovieClassLibrary.Model;



namespace MAapp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\movieapp\movies.dat";

            // Create an instance of the Controller and start the application
            Controllers controller = new Controllers(filePath);
            controller.Start();
        }
        }
    }

