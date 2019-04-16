using System;
using System.Text.RegularExpressions;

namespace _12SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            //string regex = @"^%[A-Z][a-z]+%<\w+>(\w+)?\|\d+\|(\w+)?\d+\.?\d+\$";

            //double totalIncome = 0;

            //while (true)
            //{
            //    string command = Console.ReadLine();

            //    if (command == "end of shift")
            //    {
            //        break;
            //    }

            //    bool isMatch = Regex.IsMatch(command, regex);

            //    if (isMatch)
            //    {
            //        int startName = command.IndexOf('%') + 1;
            //        int endName = command.LastIndexOf('%') - 1;
            //        int nameLen = endName - startName + 1;

            //        string name = command.Substring(startName, nameLen);

            //        int startProduct = command.IndexOf('<') + 1;
            //        int endProduct = command.LastIndexOf('>') - 1;
            //        int productLen = endProduct - startProduct + 1;

            //        string product = command.Substring(startProduct, productLen);

            //        int startCount = command.IndexOf('|') + 1;
            //        int endCount = command.LastIndexOf('|') - 1;
            //        int countLen = endCount - startCount + 1;
            //        string countAsString = command.Substring(startCount, countLen);

            //        int count = int.Parse(countAsString);

            //        string priceBackwards = string.Empty;

            //        for (int i = command.Length - 2; i >= 0; i--)
            //        {
            //            char currSymbol = command[i];

            //            if (char.IsDigit(currSymbol) || currSymbol == '.')
            //            {
            //                priceBackwards += currSymbol;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }

            //        string priceReversed = string.Empty;

            //        for (int i = priceBackwards.Length - 1; i >= 0; i--)
            //        {
            //            priceReversed += priceBackwards[i];
            //        }

            //        double price = double.Parse(priceReversed);

            //        double totalPrice = price * count;

            //        totalIncome += totalPrice;

            //        Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
            //    }
            //}

            //if (totalIncome == 0)
            //{
            //    Console.WriteLine($"Total income: {totalIncome:f2}");
            //    return;
            //}

            //Console.WriteLine($"Total income: {totalIncome:f2}");

            // gornoto 70 izcqlo moe ima problem s regexa neshto,a s regexa otdolu e 90
            // dolnoto 100

            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+)\$";
            double totalIncome = 0;

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end of shift")
                {
                    break;
                }

                if (Regex.IsMatch(line, pattern))
                {
                    Match match = Regex.Match(line, pattern);
                    var customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double money = price * count;
                    Console.WriteLine($"{customer}: {product} - {money:F2}");
                    totalIncome += money;
                }
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
