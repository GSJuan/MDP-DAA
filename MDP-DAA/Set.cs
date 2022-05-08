using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class Set
    {
        public int nbElements;
        public int dimension;
        public float[][] set;
        
        public Set(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            string[] firstLine = lines[0].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string[] secondLine = lines[1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            this.nbElements = int.Parse(firstLine[0]);
            this.dimension = int.Parse(secondLine[0]);
            
            set = new float[nbElements][];
            
            for (int i = 2; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    continue;
                }
                string[] line = lines[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                set[i - 2] = new float[this.dimension];
                for (int j = 0; j < line.Length; j++)
                {                    
                    set[i - 2][j] = float.Parse(line[j]);
                }                
            }
        }
        /**
         * Method to calculate the gravity center of the set
         * returns the gravity center array
         */
        public float[] Centre()
        {
            int setSize = this.nbElements; // n
            float[] sum = new float[this.dimension];
            for(int i = 0; i < setSize; i++)
            {
                for(int j = 0; j < this.dimension; j++)
                {
                    sum[j] += set[i][j];                        
                }                
            }            
            for (int j = 0; j < this.dimension; j++)
            {
                sum[j] = sum[j] / setSize;
            }

            return sum;
        }

        /**
         * Method to calculate the euclidean distance between to elements
         */
        public float Distance(float[] a, float[] b)
        {
            float sum = 0;
            for (int i = 0; i < this.dimension; i++)
            {
                sum += (a[i] - b[i]) * (a[i] - b[i]);
            }
            return (float)Math.Sqrt(sum);
        }
    }
}
