using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDP_DAA
{
    public class Tree
    {
        public List<PartialSolution> generatedNodes = new List<PartialSolution>();
        public List<PartialSolution> expandableNodes = new List<PartialSolution>();
        Problem problema;
        List<List<double>> distanceMatrix;

        double bestUpperBound;

        int currentDepth = 0;
        int finalDepth;
        bool depth;

        public Tree (Problem problema, ref List<List<double>> distanceMatrix, int m, bool depth)
        {
            this.distanceMatrix = distanceMatrix;
            finalDepth = m;
            this.depth = depth;
            this.problema = problema;
        }

        public PartialSolution GetNextNode()
        {
            int minIndex = -1;
            if (!depth)
            {
                double min = double.MaxValue;
                for (int i = 0; i < expandableNodes.Count; i++)
                {
                    if (expandableNodes[i].upperBound < min)
                    {
                        min = expandableNodes[i].upperBound;
                        minIndex = i;
                    }
                }
            }
            else
            {
                double maxDepth = -1;
                for (int i = 0; i < expandableNodes.Count; i++)
                {
                    if (expandableNodes[i].level > maxDepth)
                    {
                        maxDepth = expandableNodes[i].upperBound;
                        minIndex = i;
                    }
                }
            }
            return expandableNodes[minIndex];
        }
        public void InitializeActiveNodes()
        {
            currentDepth += 1;
            for (int i = 0; i < problema.set.Count - finalDepth + 1; i++)
            {
                List<int> subSet = new List<int>();
                subSet.Add(i);

                List<int> candidates = Enumerable.Range(0, problema.set.Count).ToList();
                candidates.Remove(i);

                PartialSolution newNode = new PartialSolution(subSet, ref distanceMatrix, i);
                newNode.CalculateUpperBound(candidates);
                generatedNodes.Add(newNode);
                expandableNodes.Add(newNode);
            }
        }

        public void Prune()
        {
            for(int i = 0; i < expandableNodes.Count; i++)
            {
                if(expandableNodes[i].upperBound <  bestUpperBound)
                {
                    expandableNodes.RemoveAt(i);
                }
            }
        }

        public void ExpandNode(PartialSolution node)
        {
            expandableNodes.Remove(node);

            int numberOfNodes = distanceMatrix.Count - (finalDepth - node.id - node.indexList.Count);
            for(int i = node.id + 1; i < numberOfNodes + 1 + node.id; i++)
            {

            }

            for (int i = 0; i < problema.set.Count - finalDepth + 1; i++)
            {
                List<int> subSet = new List<int>();
                subSet.Add(i);

                List<int> candidates = Enumerable.Range(0, problema.set.Count).ToList();
                candidates.Remove(i);

                PartialSolution newNode = new PartialSolution(subSet, ref distanceMatrix, i);
                newNode.CalculateUpperBound(candidates);
                generatedNodes.Add(newNode);
                expandableNodes.Add(newNode);
            }

        }
    }
}
