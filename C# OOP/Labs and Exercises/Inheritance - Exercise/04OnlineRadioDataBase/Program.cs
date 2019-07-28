namespace OnlineRadioDataBaseEdited
{
    using Exceptions;
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();

            int songsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < songsNumber; i++)
            {
                string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string artistName;
                    string songName;
                    string songLength;
                    try
                    {
                        artistName = input[0];
                        songName = input[1];
                        songLength = input[2];

                    }
                    catch (InvalidSongException exception)
                    {
                        Console.WriteLine(exception.Message);
                        continue;
                    }

                    Song song = new Song(artistName, songName, songLength);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine($"Songs added: {songs.Count}");

            long playlistLength = 0L;

            foreach (Song song in songs)
            {
                playlistLength += song.SongMinutes * 60;
                playlistLength += song.SongSeconds;
            }

            TimeSpan totalTime = TimeSpan.FromSeconds(playlistLength);

            Console.WriteLine($"Playlist length: {totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");
        }
    }
}
