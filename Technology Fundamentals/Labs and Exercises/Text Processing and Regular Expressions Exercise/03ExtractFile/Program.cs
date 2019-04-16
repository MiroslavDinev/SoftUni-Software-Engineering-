using System;
using System.Linq;

namespace _03ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int indexOfFileAndExt = input.LastIndexOf("\\") +1;
            int indexOfExtOnly = input.LastIndexOf(".") + 1;
            string extOnly = input.Substring(indexOfExtOnly);
            string fileOnly = input.Substring(indexOfFileAndExt);
            int indexOfExtInFile = fileOnly.LastIndexOf(".");
            fileOnly = fileOnly.Remove(indexOfExtInFile);
            
            Console.WriteLine($"File name: {fileOnly}");
            Console.WriteLine($"File extension: {extOnly}");
        }
    }
}
