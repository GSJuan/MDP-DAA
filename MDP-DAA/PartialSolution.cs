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

        public PartialSolution(List<int> indexList, ref List<List<double>> distanceMatrix)
        {
            level = indexList.Count;
            this.distanceMatrix = distanceMatrix;
            calculateCost();
        }

        public PartialSolution(List<int> indexList, ref List<List<double>> distanceMatrix, int id)
        {
            level = indexList.Count;
            this.distanceMatrix = distanceMatrix;
            this.id = id;
            calculateCost();
        }

        internal bool IsComplete(int m)
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
        public void CalculateUpperBound(List<int> candidates)
        {
            double max = 0;
            for (int j = 0; j < candidates.Count; j++)
            {
                double totalAdd = 0;
                for (int i = 0; i < indexList.Count; i++)
                {
                    totalAdd += distanceMatrix[indexList[i]][candidates[j]];                    
                }
                if (totalAdd > max)
                    max = totalAdd;
            }
            upperBound += (max * candidates.Count);
        }
    }
}
