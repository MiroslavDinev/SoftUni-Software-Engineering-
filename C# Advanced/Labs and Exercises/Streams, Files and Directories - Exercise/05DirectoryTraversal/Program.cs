using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _05DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path);

            Dictionary<string, List<FileInfo>> extensionFileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                string extension = fileInfo.Extension;

                if (!extensionFileInfo.ContainsKey(extension))
                {
                    extensionFileInfo.Add(extension, new List<FileInfo>());
                }

                extensionFileInfo[extension].Add(fileInfo);
            }

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            using (var writer = new StreamWriter(pathToDesktop))
            {
                foreach (var kvp in extensionFileInfo.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
                {
                    string ext = kvp.Key;

                    writer.WriteLine(ext);

                    var info = kvp.Value;

                    foreach (var file in info.OrderBy(f=>f.Length))
                    {
                        writer.WriteLine($"--{file.Name} - {file.Length / 1024:f3}kb");
                    }
                }
            }
        }
    }
}
