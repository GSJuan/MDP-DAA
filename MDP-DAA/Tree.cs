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
        public PartialSolution bestSolution;

        public double bestUpperBound = 0;
        int currentDepth = 0;
        int finalDepth;
        bool depth;

        public Tree (Problem problema, int m, bool depth)
        {
            this.distanceMatrix = problema.distanceMatrix;
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

                PartialSolution newNode = new PartialSolution(subSet, ref distanceMatrix, i, finalDepth);
                newNode.CalculateUpperBound(candidates, finalDepth);
                generatedNodes.Add(newNode);
                expandableNodes.Add(newNode);
            }
        }

        public void Prune()
        {
            for(int i = 0; i < expandableNodes.Count; i++)
            {
                if(expandableNodes[i].upperBound <  this.bestUpperBound)
                {
                    expandableNodes.RemoveAt(i);
                }
            }
        }

        public void ExpandNode(PartialSolution node)
        {
            this.expandableNodes.Remove(node);

            int numberOfNodes = (distanceMatrix.Count - (finalDepth - node.indexList.Count) - node.id);
            for(int i = node.id + 1; i < numberOfNodes + 1 + node.id; i++)
            {
                List<int> subSet = new List<int>(node.indexList);
                subSet.Add(i);
                
                List<int> candidates = Enumerable.Range(0, problema.set.Count).ToList();
                for (int j = 0; j < node.indexList.Count; j++)
                {
                    candidates.Remove(node.indexList[j]);
                }
                PartialSolution newNode = new PartialSolution(subSet, ref distanceMatrix, i, finalDepth);
                newNode.CalculateUpperBound(candidates, finalDepth);

                if (newNode.IsComplete())
                {
                    if (newNode.upperBound > this.bestUpperBound)
                    {
                        this.bestUpperBound = newNode.upperBound;
                        this.bestSolution = newNode;
                    }
                }
                else
                {
                    expandableNodes.Add(newNode);
                }
                generatedNodes.Add(newNode);
            }
        }
    }
}
