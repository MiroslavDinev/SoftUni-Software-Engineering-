using System;
using System.IO;

namespace _05SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("05. Slice File/sliceMe.txt", FileMode.Open))
            {
                var partLength = Math.Ceiling((double)reader.Length / 4);

                for (int i = 1; i <= 4; i++)
                {
                    var currName = $"Part-{i}.txt";

                    long currentPeaceSize = 0;

                    using (var writer = new FileStream(currName, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while (true)
                        {
                            //if (writer.Read(buffer,0,buffer.Length)!=buffer.Length)
                            //{
                            //    break;
                            //}

                            currentPeaceSize += buffer.Length;
                            writer.Write(buffer, 0, buffer.Length);

                            if (currentPeaceSize>= partLength)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
