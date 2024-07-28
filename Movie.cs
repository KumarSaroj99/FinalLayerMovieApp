using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }   
        public string Genre { get; set; }

        public Movie(int id,string name,int year,string genre)
        {
            Id= id;
            Name= name;
            Year= year;
            Genre= genre;
        }

        public static Movie AddNewMovie(int id,string name,int year,string genre)
        {
            return new Movie(id,name,year,genre);
        }
        public override string ToString()
        {
            return 
                $"Movie Name : {Name}\n" +
                $"Year of Release : {Year}\n" +
                $"Genre : {Genre}\n";
        }
    }
}
