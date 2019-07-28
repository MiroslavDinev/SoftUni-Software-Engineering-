using System;

namespace P03_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                string[] studentInfo = Console.ReadLine().Split();

                string action = studentInfo[0];

                if (action == "Create")
                {
                    string name = studentInfo[1];
                    int age = int.Parse(studentInfo[2]);
                    double grade = double.Parse(studentInfo[3]);

                    Student student = new Student(name, age, grade);

                    studentSystem.Add(name, student);
                }
                else if (action == "Show")
                {
                    var name = studentInfo[1];
                   
                    Student student = studentSystem.Get(name);

                    if(student!=null)
                    {
                        Console.WriteLine(student);
                    }
                                                     
                }
                else if (action == "Exit")
                {
                    break;
                }
            }
        }
    }
}
