using System;
using System.Linq;
using System.Collections.Generic;

namespace _04Songs
{
    public class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numSongs = int.Parse(Console.ReadLine());

            var listOfSongs = new List<Song>();

            for (int i = 0; i < numSongs; i++)
            {
                string[] data = Console.ReadLine().Split("_").ToArray();

                listOfSongs.Add(new Song
                {
                    TypeList = data[0],
                    Name = data[1],
                    Time = data[2]
                });
            }

            string command = Console.ReadLine();

            if (command == "all")
            {
                foreach (var currSong in listOfSongs)
                {
                    Console.WriteLine(currSong.Name);
                }
            }
            else
            {
                foreach (var currSong in listOfSongs)
                {
                    if (command == currSong.TypeList)
                    {
                        Console.WriteLine(currSong.Name);
                    }
                }
            }
        }
    }
}
