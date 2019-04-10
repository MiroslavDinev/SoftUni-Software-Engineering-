using System;

namespace _03Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            if (persons <= capacity)
            {
                Console.WriteLine(1);

            }
            else
            {
                int fullCourses = persons / capacity;
                int additional = persons % capacity;
                if (additional > 0)
                {
                    fullCourses += 1;
                }
                Console.WriteLine(fullCourses);
            }
        }
    }
}
