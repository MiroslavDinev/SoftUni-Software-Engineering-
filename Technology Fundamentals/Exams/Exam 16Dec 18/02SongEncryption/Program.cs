using System;

namespace _02SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split(":");
                string artist = tokens[0];
                string song = tokens[1];

                string validArtist = string.Empty;

                for (int i = 0; i < artist.Length; i++)
                {
                    char curr = artist[i];

                    if (i == 0 && char.IsUpper(curr))
                    {
                        validArtist += curr;
                    }
                    else if (i != 0 && char.IsUpper(curr))
                    {
                        validArtist = string.Empty;
                        break;
                    }
                    else if (i == 0 && char.IsUpper(curr) == false)
                    {
                        validArtist = string.Empty;
                        break;
                    }

                    if (i != 0 && char.IsLower(curr) || curr == '\'' || curr == ' ')
                    {
                        validArtist += curr;
                    }
                }

                if (validArtist == string.Empty)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string validSong = string.Empty;

                for (int i = 0; i < song.Length; i++)
                {
                    char curr = song[i];

                    if (char.IsUpper(curr) || curr == ' ')
                    {
                        validSong += curr;
                    }
                    else
                    {
                        validSong = string.Empty;
                        break;
                    }
                }

                if (validSong == string.Empty)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int key = validArtist.Length;

                string encryptedArtist = string.Empty;

                for (int i = 0; i < validArtist.Length; i++)
                {
                    char curr = validArtist[i];

                    if (curr == '\'' || curr == ' ')
                    {
                        encryptedArtist += curr;
                    }
                    else if (char.IsLetter(curr))
                    {
                        int currAsNum = (int)curr;
                        currAsNum += key;

                        if (currAsNum > 90 && i == 0)
                        {
                            currAsNum -= 26;
                        }
                        else if (i != 0 && currAsNum > 122)
                        {
                            currAsNum -= 26;
                        }

                        curr = (char)currAsNum;
                        encryptedArtist += curr;
                    }
                }

                string encryptedSong = string.Empty;

                for (int i = 0; i < validSong.Length; i++)
                {
                    char curr = validSong[i];

                    if (curr == ' ')
                    {
                        encryptedSong += curr;
                    }
                    else if (char.IsUpper(curr))
                    {
                        int currAsNum = (int)curr;
                        currAsNum += key;

                        if (currAsNum > 90)
                        {
                            currAsNum -= 26;
                        }
                        curr = (char)currAsNum;
                        encryptedSong += curr;
                    }
                }

                Console.WriteLine($"Successful encryption: {encryptedArtist}@{encryptedSong}");
            }
        }
    }
}
