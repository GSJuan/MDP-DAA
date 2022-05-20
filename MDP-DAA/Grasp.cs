using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDP_DAA
{
    public class Grasp
    {      
        public Solution Solve(Problem problem, int m)
        {
            LocalSearch local = new LocalSearch(problem);
            Solution solution = GraspConstruction(problem, m);
            Solution bestSolution = solution;
            int limit = 0;
            while (limit <= 100)
            {
                limit++;
                Solution newSolution = local.Search(solution);
                if(newSolution.diversity > bestSolution.diversity) 
                {
                    bestSolution = newSolution;
                    limit = 0;
                }
                solution = GraspConstruction(problem, m);
            }
            return bestSolution;
        }

        public Solution GraspConstruction(Problem ogProblem, int m)
        {
            Random random = new Random();
            Utils util = new Utils();
            Problem problem = new Problem(ogProblem);
            List<double> center = util.Center(problem);
            Solution solution = new Solution();
            List<List<double>> used = new List<List<double>>();
            int RCL_SIZE = 3;
            do
            {
                List<List<double>> candidates = new List<List<double>>();
                while (candidates.Count < RCL_SIZE)
                {
                    double maxDistance = 0;
                    List<double> furthestElement = new List<double>();
                    for (int i = 0; i < problem.set.Count; i++)
                    {
                        List<double> element = problem.set[i];
                        double distance = util.Distance(element, center);
                        if (distance > maxDistance && !candidates.Any(candidateElement => candidateElement == element) && !used.Any(usedElement => usedElement == element))
                        {
                            maxDistance = distance;
                            furthestElement = element;
                        }                        
                    }
                    candidates.Add(furthestElement);
                }

                if (candidates.Count == 0)
                {
                    break;
                }

                List<double> candidate = candidates[random.Next(candidates.Count)];
                solution.AddElement(new List<double>(candidate));
                problem.RemoveElement(candidate);
                used.Add(candidate);
                center = util.Center(solution);
            } while (solution.nbElements < m);

            solution.diversity = util.CalculateDistance(solution);
            return solution;
        }
    }
}
