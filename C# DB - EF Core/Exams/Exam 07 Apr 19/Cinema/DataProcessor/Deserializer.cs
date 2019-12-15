namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDTOs = JsonConvert.DeserializeObject<ImportMoviesDto[]>(jsonString);

            var sb = new StringBuilder();

            var movies = new List<Movie>();

            foreach (var movieDto in moviesDTOs)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidEnum = Enum.TryParse(movieDto.Genre, out Genre genre);

                if(!isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var allTitles = context.Movies
                    .Select(m => m.Title)
                    .ToHashSet();

                if(allTitles.Contains(movieDto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = TimeSpan.ParseExact(movieDto.Duration, "c", null),
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                movies.Add(movie);
                sb.AppendLine(String.Format(SuccessfulImportMovie, movie.Title, movieDto.Genre, movie.Rating.ToString("f2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsAndSeatsDTOs = JsonConvert.DeserializeObject<ImportHallsAndSeatsDto[]>(jsonString);

            var sb = new StringBuilder();

            var halls = new List<Hall>();

            foreach (var hallAndSeatDto in hallsAndSeatsDTOs)
            {
                if(!IsValid(hallAndSeatDto) || hallAndSeatDto.Seats<=0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallAndSeatDto.Name,
                    Is3D = hallAndSeatDto.Is3D,
                    Is4Dx = hallAndSeatDto.Is4Dx
                };

                for (int i = 1; i <= hallAndSeatDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat
                    {
                        HallId = hall.Id
                    });
                }

                halls.Add(hall);

                string projectionType = string.Empty;

                if(hall.Is3D==true && hall.Is4Dx==true)
                {
                    projectionType = "4Dx/3D";
                }
                else if(hall.Is3D == true && hall.Is4Dx == false)
                {
                    projectionType = "3D";
                }
                else if(hall.Is3D == false && hall.Is4Dx == true)
                {
                    projectionType = "4Dx";
                }
                else
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]), new XmlRootAttribute("Projections"));

            var projectionsDTOs = (ImportProjectionsDto[]) xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var projections = new List<Projection>();

            var validMoviesIds = context.Movies
                .Select(m => m.Id)
                .ToHashSet();

            var validHallsIds = context.Halls
                .Select(h => h.Id)
                .ToHashSet();

            foreach (var projectionDto in projectionsDTOs)
            {
                if(!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(!validMoviesIds.Contains(projectionDto.MovieId) || !validHallsIds.Contains(projectionDto.HallId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    HallId = projectionDto.HallId,
                    MovieId = projectionDto.MovieId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                var movie = context.Movies.Find(projectionDto.MovieId);

                projections.Add(projection);
                sb.AppendLine(String.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerTicketsDto[]), new XmlRootAttribute("Customers"));

            var customersTicketsDTOs = (ImportCustomerTicketsDto[]) xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var customers = new List<Customer>();

            var validProjectionsIds = context.Projections
                .Select(p => p.Id)
                .ToHashSet();

            foreach (var customerTicketDto in customersTicketsDTOs)
            {
                if(!IsValid(customerTicketDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidTicket = true;

                foreach (var ticketDto in customerTicketDto.Tickets)
                {
                    if(!validProjectionsIds.Contains(ticketDto.ProjectionId) || !IsValid(ticketDto))
                    {
                        isValidTicket = false;
                        sb.AppendLine(ErrorMessage);
                        break; ;
                    }                   
                }

                if(!isValidTicket)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerTicketDto.FirstName,
                    LastName = customerTicketDto.LastName,
                    Age = customerTicketDto.Age,
                    Balance = customerTicketDto.Balance
                };

                foreach (var ticketDto in customerTicketDto.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price,
                        CustomerId = customer.Id
                    });
                }

                customers.Add(customer);
                sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
            }

            context.Customers.AddRange(customers);
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