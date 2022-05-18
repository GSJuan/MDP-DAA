using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class PartialSolution
    {
        public List<int> indexList;
        int level;
        double upperBound;
        List<List<double>> distanceMatrix;
        double diversity = 0;

        public PartialSolution(List<int> indexList, double upperBound)
        {
            level = indexList.Count;
            this.upperBound = upperBound;            
        }

        public PartialSolution(List<int> indexList, double upperBound, ref List<List<double>> distanceMatrix)
        {
            level = indexList.Count;
            this.upperBound = upperBound;
            this.distanceMatrix = distanceMatrix;
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
                }
            }
        }
        internal double getCost()
        {
            return diversity;
        }
    }
}
