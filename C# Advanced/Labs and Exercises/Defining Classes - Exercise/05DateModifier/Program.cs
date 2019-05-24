namespace _05DateModifier
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            string answer=dateModifier.DaysDifference(firstDate, secondDate);

            int result = int.Parse(answer);

            Console.WriteLine(Math.Abs(result));
        }
    }
}
