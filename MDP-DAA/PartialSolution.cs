using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class PartialSolution
    {
        public List<int> indexList;
        public int level;
        public double upperBound = 0;
        List<List<double>> distanceMatrix;
        double diversity = 0;
        public int id = 0;
        int m = 0;

        public PartialSolution(List<int> indexList, ref List<List<double>> distanceMatrix, int m)
        {
            level = indexList.Count;
            this.distanceMatrix = distanceMatrix;
            this.indexList = indexList;
            this.m = m;
            calculateCost();
        }

        public PartialSolution(List<int> indexList, ref List<List<double>> distanceMatrix, int id, int m)
        {
            level = indexList.Count;
            this.distanceMatrix = distanceMatrix;
            this.indexList = indexList;
            this.id = id;
            this.m = m;
            calculateCost();
        }

        internal bool IsComplete()
        {
            if (level == m)
            {
                return true;
            }
            return false;
        }
        
        internal void calculateCost()
        {
            for (int i = 0; i < indexList.Count - 1; i++)
            {
                for (int j = i + 1; j < indexList.Count; j++)
                {
                    diversity += distanceMatrix[indexList[i]][indexList[j]];
                    upperBound += diversity;
                }
            }
        }
        internal double getCost()
        {
            return diversity;
        }
        public void CalculateUpperBound(List<int> candidates, int m)
        {
            double max = 0;
            for (int i = 0; i < indexList.Count; i++)
            {
                double currentDistance = 0;
                for (int j = 0; j < candidates.Count; j++)
                {
                    currentDistance = distanceMatrix[indexList[i]][candidates[j]];
                    if (currentDistance > max)
                        max = currentDistance;
                }                
            }

            for (int i = 0; i < candidates.Count; i++)
            {
                double totalAdd = 0;
                for (int j = i + 1; j < candidates.Count; j++)
                {
                    totalAdd = distanceMatrix[candidates[i]][candidates[j]];
                    if (totalAdd > max)
                        max = totalAdd;
                }                
            }
            int weight = indexList.Count * (m - indexList.Count);
            weight += ((m - indexList.Count) * ((m - indexList.Count) - 1)) / 2;
            upperBound += (max * weight);
        }
    }
}
