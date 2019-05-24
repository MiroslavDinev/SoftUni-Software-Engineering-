using System;
using System.IO;

namespace _04CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("../../../copyMe.png",FileMode.Open))
            {
                using (var writer = new FileStream("../../../result.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];

                        int size = reader.Read(buffer, 0, buffer.Length);

                        if (size==0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, size);
                    }                  
                }
            }
        }
    }
}
