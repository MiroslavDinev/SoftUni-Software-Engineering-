namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDTOs = JsonConvert.DeserializeObject<ImportDepartmentsDto[]>(jsonString);

            var sb = new StringBuilder();

            var departments = new List<Department>();

            foreach (var departmentDto in departmentsDTOs)
            {
                if(!IsValid(departmentDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidCell = true;

                foreach (var cellDto in departmentDto.Cells)
                {
                    if(!IsValid(cellDto))
                    {
                        sb.AppendLine("Invalid Data");
                        isValidCell = false;
                        break; ;
                    }
                }

                if(!isValidCell)
                {
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name
                };

                foreach (var cellDto in departmentDto.Cells)
                {
                    department.Cells.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDTOs = JsonConvert.DeserializeObject<ImportPrisonersDto[]>(jsonString);

            var sb = new StringBuilder();

            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDTOs)
            {
                if(!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isValidMail = true;

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if(!IsValid(mailDto))
                    {
                        isValidMail = false;
                        sb.AppendLine("Invalid Data");
                        break;
                    }
                }

                if(!isValidMail)
                {
                    continue;
                }

                DateTime? releaseDate = null;

                if(prisonerDto.ReleaseDate!=null)
                {
                    releaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                foreach (var mailDto in prisonerDto.Mails)
                {
                    prisoner.Mails.Add(new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            var officersDTOs = (ImportOfficerDto[]) xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var officers = new List<Officer>();

            foreach (var officerDto in officersDTOs)
            {
                if(!IsValid(officerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isValidPosition = Enum.TryParse(officerDto.Position, out Position position);
                bool isValidWeapon = Enum.TryParse(officerDto.Weapon, out Weapon weapon);

                if(isValidPosition==false || isValidWeapon==false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId
                };

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = prisonerDto.Id,
                        Officer = officer
                    });
                }

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
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