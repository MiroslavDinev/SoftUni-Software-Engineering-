using System;
using System.Linq;
using System.Collections.Generic;

namespace _10Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenTime = int.Parse(Console.ReadLine());
            int initalGreen = greenTime;
            int yellowTime = int.Parse(Console.ReadLine());
            int initialYellow = yellowTime;

            Queue<string> cars = new Queue<string>();

            int passed = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                else if (command == "green")
                {
                    while (cars.Any())
                    {
                        string carToPass = cars.Peek();
                        int lenOfCar = carToPass.Length;

                        if (greenTime<=0)
                        {
                            greenTime = initalGreen;
                            yellowTime = initialYellow;
                            break;
                        }

                        if (lenOfCar <= greenTime)
                        {
                            greenTime -= lenOfCar;
                            cars.Dequeue();
                            passed++;
                        }
                        else
                        {
                            if (lenOfCar <= greenTime + yellowTime)
                            {
                                int totalTime = greenTime + yellowTime;
                                totalTime -= lenOfCar;
                                greenTime = 0;
                                cars.Dequeue();
                                passed++;
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carToPass} was hit at {carToPass[greenTime + yellowTime]}.");
                                return;
                            }
                        }
                    }
                    
                }
                else
                {
                    cars.Enqueue(command);
                }
                greenTime = initalGreen;
                yellowTime = initialYellow;
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
