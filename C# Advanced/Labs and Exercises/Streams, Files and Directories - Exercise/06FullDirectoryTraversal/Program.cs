using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _06FullDirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            Dictionary<string, List<FileInfo>> extensionFileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                string ext = info.Extension;

                if (!extensionFileInfo.ContainsKey(ext))
                {
                    extensionFileInfo.Add(ext, new List<FileInfo>());
                }

                extensionFileInfo[ext].Add(info);
            }

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            using (var writer = new StreamWriter(pathToDesktop))
            {
                foreach (var kvp in extensionFileInfo.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
                {
                    string ext = kvp.Key;

                    writer.WriteLine(ext);

                    var info = kvp.Value;

                    foreach (var currInfo in info.OrderBy(f=>f.Length))
                    {
                        writer.WriteLine($"--{currInfo.Name} - {currInfo.Length / 1024:f3}kb");
                    }
                }
            }
        }
    }
}
