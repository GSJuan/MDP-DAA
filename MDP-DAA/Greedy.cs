using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class Greedy
    {
        /**
         * Contructive Greedy Algorithm for maximum diversity problem
         * given the gravity center gc, 
         * 1: Elem = gc;
         * 2: S = ∅;
         * 3: sc = center(Elem);
         * 4: repeat
         * 5: Obtener el elemento s∗ ∈ Elem más alejado de sc;
         * 6: S = S ∪ {s∗};
         * 7: Elem = Elem − {s∗};
         * 8: Obtener sc = centro(S);
         * 9: until (|S| = m)
         * 10: Devolver S;
         */
        
        public Solution GreedyConstruction(Problem ogProblem, int m)
        {
            Utils util = new Utils();
            Problem problem = new Problem(ogProblem);
            List<double> center = util.Center(problem);            
            Solution solution = new Solution();
            do
            {
                double maxDistance = 0;
                List<double> furthestElement = new List<double>();

                for (int i = 0; i < problem.set.Count; i++)
                {
                    double distance = util.Distance(problem.set[i], center);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        furthestElement = problem.set[i];
                    }
                }
                solution.AddElement(new List<double> (furthestElement));
                problem.RemoveElement(furthestElement);
                center = util.Center(solution);
            } while (solution.nbElements < m);

            solution.distance = util.CalculateDistance(solution);
            return solution;
        }
    }
}
