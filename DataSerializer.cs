using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieLibrary.Models;

namespace MovieLibrary.Services
{

    public class DataSerializer
    {
        
        public static string path = "C:\\Users\\sarojkumar.panda\\Desktop\\.netTraining\\FinalLayerMovieApp\\AccountLibrary\\Assets\\Movies.json";
        public static void Serialize(List<Movie> movies)
        {
            using (StreamWriter write = new StreamWriter(path))
            {
                write.WriteLine(JsonSerializer.Serialize(movies));
            }
        }
        public static List<Movie> Deserialize()
        {
            if (!File.Exists(path))
            {
                return new List<Movie>();
            }
            else
            {
                using (StreamReader read = new StreamReader(path))
                {
                    List<Movie> movie = new List<Movie>();
                    movie = JsonSerializer.Deserialize<List<Movie>>(read.ReadToEnd());
                    return movie;
                }
            }
        }
    }
}
