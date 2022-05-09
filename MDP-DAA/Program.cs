using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MDP_DAA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string folderPath = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"instances\");

            TableDrawing table = new TableDrawing(150);
            Stopwatch timer = new Stopwatch();

            table.PrintRow("Problema", "n elements", "K size", "m max elements", "z distance", "Time");
            table.PrintSeparatingLine();


            foreach (string filePath in Directory.GetFiles(folderPath, "*.txt"))
            {               
                Greedy greedy = new Greedy();
                string[] name = filePath.Split("\\");

                Problem problema = new Problem(filePath);

                for (int i = 2; i <= 5; i++)
                {                                  
                    timer.Restart();
                    Solution solution = greedy.GreedyConstruction(problema, i);
                    timer.Stop();
                    table.PrintRow(name[name.Length - 1], problema.nbElements.ToString(), problema.dimension.ToString(), i.ToString(), solution.distance.ToString(), $"{timer.ElapsedMilliseconds}" );
                    table.PrintLine();
                    Console.WriteLine(solution.ToString());
                    table.PrintLine();
                }

                table.PrintSeparatingLine();
            }
        }
    }
}
