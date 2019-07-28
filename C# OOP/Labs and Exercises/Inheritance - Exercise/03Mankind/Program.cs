using System;

namespace _03Mankind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] studentArgs = Console.ReadLine().Split();
            string firstName = studentArgs[0];
            string lastName = studentArgs[1];
            string facultyNumber = studentArgs[2];

            string[] workerProps = Console.ReadLine().Split();
            string workerFirstName = workerProps[0];
            string workerLastName = workerProps[1];
            double workerSalary = double.Parse(workerProps[2]);
            double workerHours = double.Parse(workerProps[3]);

            try
            {
                Student student = new Student(firstName, lastName, facultyNumber);
                Worker worker = new Worker(workerFirstName, workerLastName, workerSalary, workerHours);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
