using System;
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

                Problem problema = new Problem(filePath);
            }
        }
    }
}
