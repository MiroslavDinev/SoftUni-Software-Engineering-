namespace VaporStore.DataProcessor
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
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enum;
    using VaporStore.DataProcessor.ImportDtos;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesDTOs = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var sb = new StringBuilder();

            var games = new List<Game>();

            foreach (var gameDto in gamesDTOs)
            {
                if(!IsValid(gameDto) || gameDto.Tags.Length<1)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = GetDeveloper(gameDto.Developer, context);
                var genre = GetGenre(gameDto.Genre, context);

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre
                };

                foreach (var tagName in gameDto.Tags)
                {
                    var tag = GetTag(tagName, context);

                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = tag
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersDTOs = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var sb = new StringBuilder();

            var users = new List<User>();

            foreach (var userDto in usersDTOs)
            {
                if(!IsValid(userDto) || userDto.Cards.Count<1)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidCardType = true;

                foreach (var cardDto in userDto.Cards)
                {
                    var cardType = Enum.TryParse<CardType>(cardDto.Type, out CardType type);

                    if(!cardType || !IsValid(cardDto))
                    {
                        isValidCardType = false;
                        sb.AppendLine("Invalid Data");
                        break; ;
                    }
                }

                if(!isValidCardType)
                {
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    });
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            var purchasesDTOs = (ImportPurchaseDto[]) xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDTOs)
            {
                if(!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidPurchaseType = Enum.TryParse(purchaseDto.Type, out PurchaseType purchaseType);

                if(!isValidPurchaseType)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games
                    .Where(g => g.Name == purchaseDto.Title)
                    .FirstOrDefault();

                var card = context.Cards
                    .Where(c => c.Number == purchaseDto.Card)
                    .FirstOrDefault();

                var purchase = new Purchase
                {
                    Game = game,
                    Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchaseDto.Title} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
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

        private static Developer GetDeveloper(string developerName, VaporStoreDbContext context)
        {
            var developer = context.Developers
                .Where(d => d.Name == developerName)
                .FirstOrDefault();

            if(developer==null)
            {
                developer = new Developer
                {
                    Name = developerName
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }

        private static Genre GetGenre(string genreName, VaporStoreDbContext context)
        {
            var genre = context.Genres
                .Where(g => g.Name == genreName)
                .FirstOrDefault();

            if(genre==null)
            {
                genre = new Genre
                {
                    Name = genreName
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Tag GetTag(string tagName, VaporStoreDbContext context)
        {
            var tag = context.Tags
                .Where(t => t.Name == tagName)
                .FirstOrDefault();

            if(tag == null)
            {
                tag = new Tag
                {
                    Name = tagName
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }
    }
}