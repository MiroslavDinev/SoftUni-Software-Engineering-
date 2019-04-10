using System;
using System.Linq;

namespace _11ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input.Split();

                if (command[0] == "exchange")
                {
                    int indexToExchange = int.Parse(command[1]);

                    if (indexToExchange >= array.Length || indexToExchange < 0)
                    {

                        Console.WriteLine("Invalid index");
                        continue;

                    }
                    else
                    {
                        Exchange(array, indexToExchange);
                    }

                }

                else if (command[0] == "max")
                {
                    string typeNum = command[1];
                    int index = -1;

                    if (typeNum == "even")
                    {
                        index = GetIndexOfMaxEvenOrOddElements(array, 0);
                    }
                    else
                    {
                        index = GetIndexOfMaxEvenOrOddElements(array, 1);
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }
                    Console.WriteLine(index);
                }

                else if (command[0] == "min")
                {
                    string typeNum = command[1];
                    int index = -1;

                    if (typeNum == "even")
                    {
                        index = GetIndexOfMinEvenOrOddElements(array, 0);
                    }
                    else
                    {
                        index = GetIndexOfMinEvenOrOddElements(array, 1);
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }

                    Console.WriteLine(index);
                }

                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);
                    string typeNum = command[2];
                    int[] result = new int[0];

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (typeNum == "even")
                    {
                        result = FirstCountEvenOrOddElements(array, count, 0);
                    }
                    else
                    {
                        result = FirstCountEvenOrOddElements(array, count, 1);
                    }

                    Console.WriteLine("[" + string.Join(", ", result) + "]");
                }

                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    string typeNum = command[2];
                    int[] result = new int[0];

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (typeNum == "even")
                    {
                        result = LastCountEvenOrOddElements(array, count, 0);
                    }
                    else
                    {
                        result = LastCountEvenOrOddElements(array, count, 1);
                    }

                    Console.WriteLine("[" + string.Join(", ", result) + "]");
                }
            }

            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        public static void Exchange(int[] arr, int index)
        {


            for (int i = 0; i <= index; i++)
            {
                int firstNum = arr[0];

                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length - 1] = firstNum;
            }
        }

        public static int GetIndexOfMaxEvenOrOddElements(int[] arr, int divisionResult)
        {
            int index = -1;
            int maxNum = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= maxNum && arr[i] % 2 == divisionResult)
                {
                    maxNum = arr[i];
                    index = i;
                }
            }
            return index;
        }

        public static int GetIndexOfMinEvenOrOddElements(int[] arr, int divisionResult)
        {
            int index = -1;
            int minNum = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= minNum && arr[i] % 2 == divisionResult)
                {
                    minNum = arr[i];
                    index = i;
                }
            }
            return index;
        }

        public static int[] FirstCountEvenOrOddElements(int[] arr, int neededCount, int divisionResult)
        {
            int[] resultArr = new int[neededCount];
            int currentCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == divisionResult && currentCount < neededCount)
                {
                    resultArr[currentCount] = arr[i];
                    currentCount++;
                }
            }

            if (currentCount >= neededCount)
            {
                return resultArr;
            }
            else
            {
                int[] tempArr = new int[currentCount];
                Array.Copy(resultArr, tempArr, currentCount);
                return tempArr;
            }
        }

        public static int[] LastCountEvenOrOddElements(int[] arr, int neededCount, int divisionResult)
        {
            int[] resultArr = new int[neededCount];
            int currCount = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] % 2 == divisionResult && currCount < neededCount)
                {
                    resultArr[currCount] = arr[i];
                    currCount++;
                }
            }

            if (currCount >= neededCount)
            {
                return resultArr.Reverse().ToArray();
            }
            else
            {
                int[] tempArr = new int[currCount];
                Array.Copy(resultArr, tempArr, currCount);
                return tempArr.Reverse().ToArray();
            }
        }
    }
}
