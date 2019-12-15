namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                    .Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(n => n.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(p => p.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(i => i.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonerNames = prisonersNames.Split(",").ToList();

            var prisoners = context.Prisoners
                .Where(p => prisonerNames.Contains(p.FullName))
                .Select(x => new ExportPrisonerDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails
                    .Select(m => new ExportMessagesDto
                    {
                        Description = ReverseText(m.Description)
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string ReverseText(string description)
        {
            var descriptionAsArray = description.ToCharArray();

            Array.Reverse(descriptionAsArray);

            return string.Join("", descriptionAsArray);
        }
    }
}