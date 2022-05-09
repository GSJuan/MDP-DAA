using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class Solution
    {
        public int nbElements = 0;
        public int dimension = 0;
        public List<List<double>> set = new List<List<double>>();
        public double distance = 0;

        public Solution() { }
        public Solution(List<List<double>> set, int nbElements, int dimension)
        {
            this.set = set;
            this.nbElements = nbElements;
            this.dimension = dimension;
        }

        public Solution(Solution solution)
        {
            this.set = solution.set;
            this.nbElements = solution.nbElements;
            this.dimension = solution.dimension;
        }

        public Solution(List<double> element)
        {
            AddElement(element);
        }

        public void AddElement(List<double> element)
        {
            this.set.Add(element);
            this.nbElements++;
            this.dimension = element.Count;
        }

        public void Print()
        {
            Console.WriteLine("Solution :");
            
            for (int i = 0; i < this.nbElements; i++)
            {
                for (int j = 0; j < this.dimension; j++)
                {
                    Console.Write(this.set[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Distance: " + this.distance);
            Console.WriteLine();
        }

        public override string ToString()
        {
            string elements = "";
            for (int i = 0; i < this.nbElements; i++)
            {
                for (int j = 0; j < this.dimension; j++)
                {
                    elements += (this.set[i][j] + " ");
                }
                elements += "// ";
            }
            return elements;
        }
    }
}
