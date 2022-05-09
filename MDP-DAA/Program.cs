using System;
using System.Collections.Generic;
using System.IO;

namespace MDP_DAA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string folderPath = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"instances\");

            foreach (string filePath in Directory.GetFiles(folderPath, "*.txt"))
            {
                Utils utils = new Utils();
                Problem problema = new Problem(filePath);
                List<double> centroid = utils.Centre(problema);

                for(int i = 0; i < centroid.Count; i++)
                {
                    Console.WriteLine(centroid[i]);
                }
            }
        }
    }
}
