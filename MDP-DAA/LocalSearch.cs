using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class LocalSearch
    {
        Problem problem;
        public Solution Search(Solution solution)
        {            
            bool improve;
            int firstIndex;
            int secondIndex;
            double bestDistance = solution.diversity;            
            do
            {
                Problem leftElements = this.problem - solution;
                improve = false;
                firstIndex = -1;
                secondIndex = -1;

                for (int i = 0; i < solution.nbElements; i++)
                {
                    for (int j = 0; j < leftElements.nbElements; j++)
                    {
                        double newDistance = solution.SimulateDistance(leftElements.set[j], i);
                        if (newDistance > bestDistance)
                        {
                            bestDistance = newDistance;
                            firstIndex = j;
                            secondIndex = i;
                        }
                    }
                }
                if (firstIndex != -1 && secondIndex != -1)
                {
                    solution.diversity = bestDistance;
                    (leftElements.set[firstIndex], solution.set[secondIndex]) = (solution.set[secondIndex], leftElements.set[firstIndex]);
                    improve = true;
                }

            } while (improve);

            return solution;            
        }
        public LocalSearch(Problem problem)
        {
            this.problem = problem;
        }
    }
}
