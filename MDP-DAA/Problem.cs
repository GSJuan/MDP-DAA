using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class Problem
    {
        public int nbElements;
        public int dimension;
        public float[][] distanceMatrix;

        public Problem(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            string[] firstLine = lines[0].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string[] secondLine = lines[1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            nbElements = int.Parse(firstLine[0]);
            dimension = int.Parse(secondLine[0]);
            
            distanceMatrix = new float[nbElements][];
            
            for (int i = 2; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    continue;
                }
                string[] line = lines[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                distanceMatrix[i - 2] = new float[dimension];
                for (int j = 0; j < line.Length; j++)
                {
                    distanceMatrix[i - 2][j] = float.Parse(line[j]);
                }
                
            }
        }
    }
}
