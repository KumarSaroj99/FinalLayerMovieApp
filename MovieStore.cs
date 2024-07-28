using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Models;
using MovieLibrary.Repository;
using MovieLibrary.Services;
using MovieLibrary.Exceptions;

namespace MovieManagementApp.ViewController
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {
            string creater = "Sarojkumar";
            MovieManager.DeserializeData();
            while(true) 
            {
                Console.WriteLine($"\nWelcome to movie store developed by : {creater}\n" +
                    $"What do you wise to do ?\n" +
                    $"1.Add New Movie \n" +
                    $"2.Display All Movies\n" +
                    $"3.Find Movie by Id \n" +
                    $"4.Remove an Movie By Id\n" +
                    $"5.Clear all Movies \n" +
                    $"6.Exit \n"
                    );
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }
                catch (MovieNotFoundException mnf)
                {
                    Console.WriteLine(mnf.Message);
                }
                catch (MovieListEmptyException mle)
                {
                    Console.WriteLine(mle.Message);
                }
                catch (InvalidChoiceException ic)
                {
                    Console.WriteLine(ic.Message);
                }
                catch (CapacityOverException co)
                {
                    Console.WriteLine(co.Message);
                }
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Find();
                    break;
                case 4:
                    Remove();
                    break;
                case 5:
                    MovieManager.ClearAllAccounts();
                    Console.WriteLine("All Movies are cleared ! \n");
                    break;
                case 6:
                    MovieManager.SerializeData();
                    Console.WriteLine("Thank you for using our Movie Management App !!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid input.");
                    break;
            }
        }
        public static void Find()
        {
            Console.WriteLine("Enter the ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(MovieManager.FindMovie(id));
        }
        public static void Add()
        {
            try
            {
                Console.WriteLine("Enter Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Movie Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Year of release : ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Genre : ");
                string genre = Console.ReadLine();
                //movies.Add(Movie.AddNewMovie(id, name, year, genre));
                MovieManager.AddMovie(id, name, year, genre);
                Console.WriteLine("---Your Movie is created successfully !---\n");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(CapacityOverException co)
            {
                Console.WriteLine(co.Message);
            }
        }
        public static void Display()
        {
            var toDisplay = MovieManager.DisplayAllMovies();
            toDisplay.ForEach(item => Console.WriteLine($"=============ID : {item.Id}=============\n" +
                                                         $"{item}"));
        }
        //public static void Update()
        //{
        //    Console.WriteLine("Enter the ID : ");
        //    int id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Enter new Name :");
        //    string name = Console.ReadLine();
        //    MovieManager.ModifyName(id, name);
        //    Console.WriteLine("Your Movie Name is Modified successfully !\n");
        //}
        static void Remove()
        {
            Console.WriteLine("Enter the ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieManager.RemoveMovie(id);
            Console.WriteLine("Your Movie is removed successfully !\n");
        }
    }
}
