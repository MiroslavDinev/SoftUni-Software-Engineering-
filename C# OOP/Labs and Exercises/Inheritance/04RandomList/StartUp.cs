using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("pesho");
            randomList.Add("gosho");
            randomList.Add("ivan");

            Console.WriteLine(randomList.RandomString()); 
        }
    }
}
