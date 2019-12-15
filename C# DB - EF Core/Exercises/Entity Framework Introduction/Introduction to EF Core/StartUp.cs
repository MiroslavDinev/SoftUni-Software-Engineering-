using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                string result = RemoveTown(context);
                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(f => f.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(d => d.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(f => f.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var nakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            nakov.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(a => new
                {
                    a.Address.AddressText
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine(employee.AddressText);
            }

            return sb.ToString().TrimEnd();
                
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(p => p.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,

                    Projects = e.EmployeesProjects
                    .Select(pr => new
                    {
                        ProjectName = pr.Project.Name,
                        StartDate = pr.Project.StartDate,
                        EndDate = pr.Project.EndDate
                    }).ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string endDate = string.Empty;

                    var hasEndDate = project.EndDate.HasValue;

                    if(!hasEndDate)
                    {
                        endDate = "not finished";
                    }
                    else
                    {
                        endDate = project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    }

                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(x => new
                {
                    AddressText = x.AddressText,
                    TownName = x.Town.Name,
                    EmployeesCount = x.Employees.Count
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {

            var employee = context.Employees
                .FirstOrDefault(x => x.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in context.Projects.Where(p=>p.EmployeesProjects.Any(ep=>ep.EmployeeId==employee.EmployeeId)).OrderBy(x=>x.Name))
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
                
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,

                    Employees = x.Employees
                    .Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        JobTitle = e.JobTitle
                    })
                    .OrderBy(z=>z.EmployeeFirstName)
                    .ThenBy(z=>z.EmployeeLastName)
                    .ToList()
                })
                .OrderBy(n => n.DepartmentName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
                
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .Take(10)
                .ToList()
                .OrderBy(p => p.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var project in projects)
            {
                var format = "M/d/yyyy h:mm:ss tt";
                result.AppendLine($"{project.Name}");
                result.AppendLine($"{project.Description}");
                result.AppendLine($"{project.StartDate.ToString()}");
            }

            return result.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design"
                || x.Department.Name == "Marketing" || x.Department.Name == "Information Services ")
                .ToList();
                
                

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees1 = context.Employees
                .Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design"
                || x.Department.Name == "Marketing" || x.Department.Name == "Information Services ")
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees1.OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(f => f.FirstName)
                .ThenBy(l => l.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .FirstOrDefault(x => x.ProjectId == 2);

            var employeeProjects = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(employeeProjects);
            context.Projects.Remove(project);
            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currProject in projects)
            {
                sb.AppendLine(currProject.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var seattle = context.Towns
                .FirstOrDefault(x => x.Name == "Seattle");

            int seattleId = seattle.TownId;

            var addressesToDelete = context.Addresses
                .Where(a => a.TownId == seattleId).ToList();

            int countOfAddresses = addressesToDelete.Count();

            var addressesIds = new List<int>();

            foreach (var address in addressesToDelete)
            {
                var addressId = address.AddressId;

                addressesIds.Add(addressId);
            }

            var employees = context.Employees
                .Where(x => x.Address != null && addressesIds.Contains((int)x.AddressId))
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToDelete);

            context.Towns.Remove(seattle);
            context.SaveChanges();

            return $"{countOfAddresses} addresses in Seattle were deleted";

        }
    }
}
