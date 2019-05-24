using System;
using System.Linq;
using System.Collections.Generic;

namespace _08BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];

                if (curr=='(' || curr=='[' || curr =='{')
                {
                    brackets.Push(curr);
                }
                else if (curr == ')')
                {
                    if (brackets.Count>0 && brackets.Peek()=='(')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (curr==']')
                {
                    if (brackets.Count > 0 && brackets.Peek() == '[')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (curr == '}')
                {
                    if (brackets.Count > 0 && brackets.Peek() == '{')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
