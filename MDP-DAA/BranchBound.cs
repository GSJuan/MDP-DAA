using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDP_DAA
{
    public class BranchBound
    {
        double lowerBound = 0;
        private Solution initialSolution;
        List<List<double>> distanceMatrix;
        public bool depth = false;
        
        public BranchBound(List<List<double>> distanceMatrix, Solution solucion, bool depth)
        {
            this.lowerBound = solucion.diversity;
            this.initialSolution = solucion;
            this.distanceMatrix = distanceMatrix;
            this.depth = depth;
        }
        
        public Solution Solve(Problem problema, int m) 
        {
            Utils util = new Utils();
            Tree tree = new Tree(problema, m, depth); // true en profundidad, false por cota
            tree.bestUpperBound = lowerBound;
            tree.InitializeActiveNodes();

            while (tree.expandableNodes.Count > 0)
            {
                PartialSolution currentNode = tree.GetNextNode();
                /*
                if (currentNode.IsComplete())
                {
                    if (currentNode.upperBound > lowerBound)
                    {
                        lowerBound = currentNode.upperBound;
                        Console.WriteLine("Lower bound: " + lowerBound);
                    }
                    
                }
                else
                {
                    tree.ExpandNode(currentNode);
                    tree.Prune();
                }*/
                
                tree.ExpandNode(currentNode);
                tree.Prune();
               

            }
            if(tree.bestSolution != null)
            {
                return util.convertToSolution(problema, tree.bestSolution);
            }

            return this.initialSolution;       
        }   
    }
}