namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDTOs = JsonConvert.DeserializeObject<ImportWritersDto[]>(jsonString);

            var sb = new StringBuilder();

            var writers = new List<Writer>();

            foreach (var writerDto in writersDTOs)
            {
                if(!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDTOs = JsonConvert.DeserializeObject<ImportProducersDto[]>(jsonString);

            var sb = new StringBuilder();

            var producers = new List<Producer>();

            foreach (var producerDto in producersDTOs)
            {
                if(!IsValid(producerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidAlbum = true;

                foreach (var albumDto in producerDto.Albums)
                {
                    if(!IsValid(albumDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        isValidAlbum = false;
                        break;
                    }
                }

                if(!isValidAlbum)
                {
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    producer.Albums.Add(new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    });
                }

                producers.Add(producer);

                if(producer.PhoneNumber!=null)
                {
                    sb.AppendLine(String.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(String.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }
                
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]), new XmlRootAttribute("Songs"));

            var songsDTOs = (ImportSongsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var songs = new List<Song>();

            foreach (var songDto in songsDTOs)
            {
                if(!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validAlbumIds = context.Albums
                    .Select(a => a.Id)
                    .ToHashSet();

                var validWriterIds = context.Writers
                    .Select(w => w.Id)
                    .ToHashSet();

                if(!validAlbumIds.Contains(songDto.AlbumId) || !validWriterIds.Contains(songDto.WriterId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidGenre = Enum.TryParse(songDto.Genre, out Genre genre);

                if(!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, "c", null),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = genre,
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };

                songs.Add(song);
                sb.AppendLine(String.Format(SuccessfullyImportedSong, song.Name, songDto.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongPerformersDto[]), new XmlRootAttribute("Performers"));

            var songPerformersDTOs = (ImportSongPerformersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var performers = new List<Performer>();

            foreach (var songPerformerDto in songPerformersDTOs)
            {
                if(!IsValid(songPerformerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validSongsIds = context.Songs
                    .Select(s => s.Id)
                    .ToHashSet();

                bool isValidSong = true;

                foreach (var songDto in songPerformerDto.PerformersSongs)
                {
                    if(!validSongsIds.Contains(songDto.Id))
                    {
                        sb.AppendLine(ErrorMessage);
                        isValidSong = false;
                        break; ;
                    }
                }

                if(!isValidSong)
                {
                    continue;
                }

                var performer = new Performer
                {
                    FirstName = songPerformerDto.FirstName,
                    LastName = songPerformerDto.LastName,
                    Age = songPerformerDto.Age,
                    NetWorth = songPerformerDto.NetWorth
                };

                

                foreach (var songDto in songPerformerDto.PerformersSongs)
                {
                    var song = context.Songs.Find(songDto.Id);

                    performer.PerformerSongs.Add(new SongPerformer
                    {
                        Performer = performer,
                        Song = song
                    });
                }

                performers.Add(performer);

                sb.AppendLine(String.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}