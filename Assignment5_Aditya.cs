using System;
using System.Collections.Generic;

namespace Assignments
{
    class Movie
    {
        public int Id { get; set; } = 1000;
        public string Title { get; set; }
        public int Year { get; set; }

    }

    internal class Assignment5_Aditya
    {
        static List<Movie> movieList = new List<Movie>();
        static void Main(string[] args)
        {
            bool processing = true;
            while (processing)
            {
                Console.WriteLine("Movie Database Menu:");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Remove Movie");
                Console.WriteLine("3. Find Movie");
                Console.WriteLine("4. Update Movie");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddMovie();
                        break;
                    case "2":
                        RemoveMovie();
                        break;
                    case "3":
                        FindMovie();
                        break;
                    case "4":
                        UpdateMovie();
                        break;
                    case "5":
                        processing = false;
                        Console.WriteLine("Exiting Movie Database");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddMovie()
        {
            Movie movie = new Movie();
            movie.Id++;

            Console.Write("Enter movie title: ");
            movie.Title = Console.ReadLine();

            Console.Write("Enter release year: ");
            movie.Year = int.Parse(Console.ReadLine());

            movieList.Add(movie);
            Console.WriteLine("Movie added successfully!");
        }

        static void RemoveMovie()
        {
            Console.Write("Enter movie ID to remove: ");
            int id = int.Parse(Console.ReadLine());

            Movie movie = movieList.Find(m => m.Id == id);
            if (movie != null)
            {
                movieList.Remove(movie);
                Console.WriteLine("Movie removed successfully!");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }

        static void FindMovie()
        {
            Console.Write("Enter movie ID to find: ");
            int id = int.Parse(Console.ReadLine());

            Movie movie = movieList.Find(m => m.Id == id);
            if (movie != null)
            {
                Console.WriteLine("Movie Found:");
                Console.WriteLine($"Title : {movie.Title}, Year : ({movie.Year})");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }

        static void UpdateMovie()
        {
            Console.Write("Enter movie ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Movie movie = movieList.Find(m => m.Id == id);
            if (movie != null)
            {
                Console.Write("Enter new title: ");
                string title = Console.ReadLine();
                movie.Title = title;
                Console.Write("Enter new year: ");
                int year = int.Parse(Console.ReadLine());
                movie.Year = year;
                Console.WriteLine("Movie updated successfully!");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }
    }
}
