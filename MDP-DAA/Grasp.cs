using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class Grasp
    {      
        public Solution Solve(Problem problem, int m)
        {
            Greedy greedy = new Greedy();
            LocalSearch local = new LocalSearch(problem);
            Solution solution = greedy.GreedyConstruction(problem, m);
            Solution bestSolution = solution;
            int limit = 0;
            while (limit <= 2000)
            {
                limit++;
                Solution newSolution = local.Search(solution);
                if(newSolution.distance > bestSolution.distance) 
                {
                    bestSolution = newSolution;
                }
                solution = greedy.GreedyConstruction(problem, m);
            }
            return bestSolution;
        }
    }
}
