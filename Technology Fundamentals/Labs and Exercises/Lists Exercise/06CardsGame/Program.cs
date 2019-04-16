using System;
using System.Linq;
using System.Collections.Generic;

namespace _06CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstPlayerCards.Count!=0 && secondPlayerCards.Count!=0)
            {
                int currFirstPlayerCard = firstPlayerCards[0];
                int currSecondPlayerCard = secondPlayerCards[0];

                if (currFirstPlayerCard>currSecondPlayerCard)
                {
                    firstPlayerCards.Add(currFirstPlayerCard);
                    firstPlayerCards.Add(currSecondPlayerCard);

                    firstPlayerCards.Remove(currFirstPlayerCard);
                    secondPlayerCards.Remove(currSecondPlayerCard);
                }
                else if (currSecondPlayerCard>currFirstPlayerCard)
                {
                    secondPlayerCards.Add(currSecondPlayerCard);
                    secondPlayerCards.Add(currFirstPlayerCard);

                    firstPlayerCards.Remove(currFirstPlayerCard);
                    secondPlayerCards.Remove(currSecondPlayerCard);
                }
                else
                {
                    firstPlayerCards.Remove(currFirstPlayerCard);
                    secondPlayerCards.Remove(currSecondPlayerCard);
                }
            }

            if (firstPlayerCards.Count!=0)
            {
                int sum = firstPlayerCards.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                int sum = secondPlayerCards.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
