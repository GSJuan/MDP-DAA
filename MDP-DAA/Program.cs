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

            TableDrawing table = new TableDrawing(100);
            Stopwatch timer = new Stopwatch();
            Utils util = new Utils();

            table.PrintRow("Problema", "n elements", "K size", "m max elements", "z distance", "Time");
            table.PrintSeparatingLine();


            foreach (string filePath in Directory.GetFiles(folderPath, "*.txt"))
            {               
                Greedy greedy = new Greedy();
                Grasp grasp = new Grasp();
                
                string[] name = filePath.Split("\\");

                Problem problema = new Problem(filePath);

                for (int i = 2; i <= 6; i++)
                {/*
                    timer.Restart();
                    Solution greedySolution = greedy.GreedyConstruction(problema, i);
                    timer.Stop();
                    table.PrintRow(name[name.Length - 1], problema.nbElements.ToString(), problema.dimension.ToString(), i.ToString(), greedySolution.diversity.ToString(), $"{timer.ElapsedMilliseconds}");
                    table.PrintLine();
                    */
                    timer.Restart();
                    Solution graspSolution = grasp.Solve(problema, i);
                    timer.Stop();
                    table.PrintRow(name[name.Length - 1], problema.nbElements.ToString(), problema.dimension.ToString(), i.ToString(), graspSolution.diversity.ToString(), $"{timer.ElapsedMilliseconds}");
                    table.PrintLine();
                    Console.WriteLine(graspSolution.ToString());
                    table.PrintLine();
                    /*
                    BranchBound branchBound = new BranchBound(problema.distanceMatrix, greedySolution, true);

                    timer.Restart();
                    Solution branchBoundSolution = branchBound.Solve(problema, i);
                    timer.Stop();
                    table.PrintRow(name[name.Length - 1], problema.nbElements.ToString(), problema.dimension.ToString(), i.ToString(), branchBoundSolution.diversity.ToString(), $"{timer.ElapsedMilliseconds}");
                    table.PrintLine();

                    //Console.WriteLine(branchBoundSolution.ToString());
                    */
                    table.PrintSeparatingLine();
                }
            }
        }
    }
}
