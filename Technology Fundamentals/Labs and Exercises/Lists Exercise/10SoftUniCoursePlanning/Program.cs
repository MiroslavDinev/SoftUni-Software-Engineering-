using System;
using System.Linq;
using System.Collections.Generic;

namespace _10SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLessons = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "course start")
                {
                    break;
                }

                string[] tokens = command.Split(":");

                string action = tokens[0];

                if (action == "Add")
                {
                    string lessonTitle = tokens[1];

                    if (initialLessons.Contains(lessonTitle)==false)
                    {
                        initialLessons.Add(lessonTitle);
                    }
                }
                else if (action == "Insert")
                {
                    string lessonTitle = tokens[1];
                    int index = int.Parse(tokens[2]);

                    if (initialLessons.Contains(lessonTitle) == false)
                    {
                        initialLessons.Insert(index, lessonTitle);
                    }
                }
                else if (action == "Remove")
                {
                    string lessonTitle = tokens[1];

                    if (initialLessons.Contains(lessonTitle) == true)
                    {
                        initialLessons.Remove(lessonTitle);
                    }
                    if (initialLessons.Contains($"{lessonTitle}-Exercise"))
                    {
                        initialLessons.Remove($"{lessonTitle}-Exercise");
                    }
                }
                else if (action=="Swap")
                {
                    string lessonTitleFirst = tokens[1];
                    string lessonTitleLast = tokens[2];

                    if (initialLessons.Contains(lessonTitleFirst)&& initialLessons.Contains(lessonTitleLast))
                    {
                        Swap(initialLessons, lessonTitleFirst, lessonTitleLast);

                        if (initialLessons.Contains($"{lessonTitleFirst}-Exercise"))
                        {
                            int indexOfInitialExercisePosition = initialLessons.IndexOf($"{lessonTitleFirst}-Exercise");
                            int indexOfFirstLesson = initialLessons.IndexOf(lessonTitleFirst);
                            initialLessons.Insert(indexOfFirstLesson + 1, $"{lessonTitleFirst}-Exercise");
                            initialLessons.RemoveAt(indexOfInitialExercisePosition + 1);
                        }
                        else if (initialLessons.Contains($"{lessonTitleLast}-Exercise"))
                        {
                            int indexOfInitialExercisePosition = initialLessons.IndexOf($"{lessonTitleLast}-Exercise");
                            int indexOfLastLesson = initialLessons.IndexOf(lessonTitleLast);
                            initialLessons.Insert(indexOfLastLesson + 1, $"{lessonTitleLast}-Exercise");
                            initialLessons.RemoveAt(indexOfInitialExercisePosition+1);
                            
                        }
                    }
                    if (initialLessons.Contains($"{lessonTitleFirst}-Exercise")&&initialLessons.Contains($"{lessonTitleLast}-Exercise"))
                    {
                        Swap(initialLessons, $"{lessonTitleFirst}-Exercise", $"{lessonTitleLast}-Exercise");
                    }
                    

                }
                else if (action == "Exercise")
                {
                    string lessonTitle = tokens[1];

                    if (initialLessons.Contains(lessonTitle)==true && initialLessons.Contains($"{lessonTitle}-Exercise")==false)
                    {
                        int lessonIndex = initialLessons.IndexOf(lessonTitle);
                        initialLessons.Insert(lessonIndex + 1, $"{lessonTitle}-Exercise");
                    }
                    else if (initialLessons.Contains(lessonTitle)==false)
                    {
                        initialLessons.Add(lessonTitle);
                        initialLessons.Add($"{lessonTitle}-Exercise");
                    }
                }
            }

            for (int i = 0; i < initialLessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{initialLessons[i]}");
            }
        }

        private static void Swap(List<string> initialLessons, string lessonTitleFirst, string lessonTitleLast)
        {
            int indexFirstLesson = initialLessons.IndexOf(lessonTitleFirst);
            int indexSecondLesson = initialLessons.IndexOf(lessonTitleLast);

            initialLessons.RemoveAt(indexFirstLesson);
            initialLessons.Insert(indexFirstLesson, lessonTitleLast);

            initialLessons.RemoveAt(indexSecondLesson);
            initialLessons.Insert(indexSecondLesson, lessonTitleFirst);
        }
    }
}
