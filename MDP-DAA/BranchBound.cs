using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDP_DAA
{
    public class BranchBound
    {
        double lowerBound = 0;
        List<List<double>> distanceMatrix;
        bool depth;
        
        BranchBound(List<List<double>> distanceMatrix, double lowerBound)
        {
            this.lowerBound = lowerBound;
            this.distanceMatrix = distanceMatrix;
        }
        
        public Solution Solve(Problem problema, int m) 
        {
            Tree tree = new Tree(ref distanceMatrix, m, false); // true en profundidad, false por cota
            tree.InitializeActiveNodes(problema);

            while (tree.expandableNodes.Count > 0)
            {
                PartialSolution currentNode = tree.GetNextNode();

                /*
                if (currentNode.IsComplete(m))
                {
                    if (currentNode.getCost() > lowerBound)
                    {
                        lowerBound = currentNode.getCost();
                        Console.WriteLine("Lower bound: " + lowerBound);
                    }
                }
                else
                {
                    List<PartialSolution> newNodes = Expand(currentNode, m);
                    activeNodes.AddRange(newNodes);
                }*/

                tree.ExpandNode(currentNode);
                tree.Prune();

            }
            Solution solution = new Solution();
            return solution;            
        }

        private List<PartialSolution> Expand(PartialSolution currentNode)
        {
            throw new NotImplementedException();
        }        
    }
}