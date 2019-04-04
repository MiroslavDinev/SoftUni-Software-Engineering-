using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06SafePasswordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());

            int counter = 0;

            for (char i = '#'; i <= '7'; i++)
            {
                if (i > '7')
                {
                    i = '#';
                }
                for (char k = '@'; k <= '`'; k++)
                {
                    if (k > '`')
                    {
                        k = '@';
                    }
                    for (int m = 1; m <= a; m++)
                    {

                        for (int x = 1; x <= b; x++)
                        {
                            for (char y = '@'; y <= '`'; y++)
                            {
                                if (y > '`')
                                {
                                    y = '@';
                                }
                                for (char z = '#'; z <= '7'; z++)
                                {

                                    if (z > '7')
                                    {
                                        z = '#';
                                    }




                                    counter++;

                                    if (counter > maxPasswords)
                                    {
                                        
                                       return;
                                    }
                                    
                                    else
                                    {
                                        Console.Write("{0}{1}{2}{3}{4}{5}|", i, k, m, x, y, z);

                                    }
                                    

                                    




                                    y++;
                                    if (y > '`')
                                    {
                                        y = '@';
                                    }

                                    x++;
                                    if (x>b)
                                    {
                                        x = 1;
                                        m++;
                                        if (m > a)
                                        {
                                            return;
                                        }
                                    }
                                    k++;
                                    if (k> '`')
                                    {
                                        k = '@';
                                    }
                                    i++;
                                    if (i > '7')
                                    {
                                        i = '#';
                                    }


                                    

                                    
                                }
                                

                            }
                            

                        }
                        
                    }
                    
                }
                
            }
        }
    }
}
