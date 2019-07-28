using _09CollectionHierarchy.Models;
using System;

namespace _09CollectionHierarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            int removeOpsCount = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var item in words)
            {
                Console.Write(addCollection.Add(item) + " ");
            }

            Console.WriteLine();

            foreach (var item in words)
            {
                Console.Write(addRemoveCollection.Add(item) + " ");
            }

            Console.WriteLine();

            foreach (var item in words)
            {
                Console.Write(myList.Add(item) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeOpsCount; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeOpsCount; i++)
            {
                Console.Write(myList.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}
