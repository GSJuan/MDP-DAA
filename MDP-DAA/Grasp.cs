using System;
using System.Collections.Generic;
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
            while (limit <= 20)
            {
                limit++;
                Solution newSolution = local.Search(solution);
                if(newSolution.diversity > bestSolution.diversity) 
                {
                    bestSolution = newSolution;
                    //limit = 0;
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
                        double distance = util.Distance(problem.set[i], center);
                        if (distance > maxDistance && !candidates.Contains(problem.set[i]))
                        {
                            maxDistance = distance;
                            furthestElement = problem.set[i];
                        }

                    }
                    candidates.Add(furthestElement);
                }

                List<double> candidate = candidates[random.Next(candidates.Count)];
                solution.AddElement(new List<double>(candidate));
                problem.RemoveElement(candidate);
                center = util.Center(solution);
            } while (solution.nbElements < m);

            solution.diversity = util.CalculateDistance(solution);
            return solution;
        }
    }
}
