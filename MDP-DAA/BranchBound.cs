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
        
        BranchBound(List<List<double>> distanceMatrix, double lowerBound)
        {
            this.lowerBound = lowerBound;
            this.distanceMatrix = distanceMatrix;
        }
        
        public Solution Solve(Problem problema, int m) 
        {
            List<PartialSolution> activeNodes = InitializeActiveNodes(problema);

            while (activeNodes.Count > 0)
            {
                PartialSolution currentNode = activeNodes.First();
                activeNodes.Remove(currentNode);

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
                }
            }
            Solution solution = new Solution();
            return solution;            
        }

        private List<PartialSolution> Expand(PartialSolution currentNode, int m)
        {
            throw new NotImplementedException();
        }

        public List<PartialSolution> InitializeActiveNodes(Problem problema)
        {
            List<PartialSolution> activeNodes = new List<PartialSolution>();  
            
            for ( int i = 0; i < problema.set.Count; i++)
            {
                for (int j = i + 1; j < problema.set[i].Count; j++)
                {
                    List<int> subSet = new List<int>();
                    subSet.Add(i);
                    subSet.Add(j);

                    List<int> candidates = Enumerable.Range(0, problema.set.Count).ToList();
                    candidates.Remove(i);
                    candidates.Remove(j);
                    
                    double upperBound = CalculateUpperBound(subSet, candidates);
                    PartialSolution newNode = new PartialSolution(subSet, upperBound, ref distanceMatrix);
                    activeNodes.Add(newNode);
                }
            }

            return activeNodes;
        }
        
        public double CalculateUpperBound(List<int> partialSolution, List<int> candidates)
        {
            double upperBound = 0;

            for (int i = 0; i < partialSolution.Count - 1; i++)
            {
                for (int j = i + 1; j < partialSolution.Count; j++)
                {
                    upperBound += distanceMatrix[partialSolution[i]][partialSolution[j]];
                }
            }

            for (int i = 0; i < partialSolution.Count; i++)
            {                
                for (int j = 0; j < candidates.Count; j++)
                {
                    upperBound += distanceMatrix[partialSolution[i]][candidates[j]];
                }
            }
            return upperBound;
        }
    }
}