using System;
using System.IO;

namespace _04MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter("Output.txt"))
            {
                using (var reader1 = new StreamReader("04. Merge Files/FileOne.txt"))
                {
                    using (var reader2 = new StreamReader("04. Merge Files/FileTwo.txt"))
                    {
                        while (true)
                        {
                            string line1 = reader1.ReadLine();

                            if (line1 == null)
                            {
                                break;
                            }

                            writer.WriteLine(line1);

                            string line2 = reader2.ReadLine();

                            if (line2 == null)
                            {
                                break;
                            }

                            writer.WriteLine(line2);
                        }
                    }
                }
            }
        }
    }
}
