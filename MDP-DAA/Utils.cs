using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class Utils
    {
        /**
         * Method to calculate the euclidean distance between two elements
         */
        public double Distance(List<double> a, List<double> b)
        {
            double sum = 0;
            int size = a.Count;
            for (int i = 0; i < size; i++)
            {
                sum += (a[i] - b[i]) * (a[i] - b[i]);
            }
            return (float)Math.Sqrt(sum);
        }

        /**
         * Method to calculate the gravity center of the set
         * returns the gravity center array
         */
        public List<double> Center(Problem problem)
        {
            int setSize = problem.nbElements; // n
            List<double> sum = new List<double>();
            for (int j = 0; j < problem.dimension; j++)
            {
                sum.Add(0);
                for (int i = 0; i < setSize; i++)
                {
                    sum[j] += problem.set[i][j];
                }
            }
            for (int j = 0; j < problem.dimension; j++)
            {
                sum[j] = sum[j] / setSize;
            }
            
            return sum;
        }
        
        public List<double> Center(Solution solution)
        {
            int setSize = solution.nbElements; // n
            List<double> sum = new List<double>();
            for (int j = 0; j < solution.dimension; j++)
            {
                sum.Add(0);
                for (int i = 0; i < setSize; i++)
                {
                    sum[j] += solution.set[i][j];
                }
            }
            for (int j = 0; j < solution.dimension; j++)
            {
                sum[j] = sum[j] / setSize;
            }

            return sum;
        }

        public  double CalculateDistance(Solution solution)
        {
            double distance = 0;
            for (int i = 0; i < solution.nbElements - 1; i++)
            {
                for (int j = i + 1; j < solution.nbElements; j++)
                {
                    distance += Distance(solution.set[i], solution.set[j]);
                }
            }
            return distance;
        }
    }
}
