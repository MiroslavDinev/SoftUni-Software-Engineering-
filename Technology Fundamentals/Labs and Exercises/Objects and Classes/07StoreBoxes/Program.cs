using System;
using System.Linq;
using System.Collections.Generic;

namespace _07StoreBoxes
{
    
    public class Box
    {   
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity { get; set; }
        public double ItemPrice { get; set; }
        public double PriceForABox { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> result = new List<Box>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();

                string serialNum = tokens[0];
                string itemName = tokens[1];
                int itemQuantity = int.Parse(tokens[2]);
                double itemPrice = double.Parse(tokens[3]);

                double pricePerBox = itemPrice * itemQuantity;

                var storeBox = new Box
                {
                    SerialNumber = serialNum,
                    Item = itemName,
                    ItemQuantity = itemQuantity,
                    ItemPrice = itemPrice,
                    PriceForABox = pricePerBox
                };

                result.Add(storeBox);
            }

            foreach (var currBox in result.OrderByDescending(x=>x.PriceForABox))
            {
                Console.WriteLine(currBox.SerialNumber);
                Console.WriteLine($"-- {currBox.Item} - ${currBox.ItemPrice:f2}: {currBox.ItemQuantity}");
                Console.WriteLine($"-- ${currBox.PriceForABox:f2}");
            }
        }
    }
}
