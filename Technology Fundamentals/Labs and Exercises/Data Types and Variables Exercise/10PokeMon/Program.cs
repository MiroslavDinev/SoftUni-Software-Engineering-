using System;

namespace _10PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());

            int copyOfPokePower = pokePower;
            int counter = 0;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                counter++;

                if (pokePower == copyOfPokePower / 2)
                {
                    if (exhaustion != 0)
                    {
                        pokePower /= exhaustion;
                    }
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(counter);
        }
    }
}
