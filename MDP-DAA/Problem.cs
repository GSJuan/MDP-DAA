using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class Problem
    {
        public int nbElements;
        public int dimension;
        public List<List<double>> set = new List<List<double>>();
        
        public Problem(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            string[] firstLine = lines[0].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string[] secondLine = lines[1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            this.nbElements = int.Parse(firstLine[0]);
            this.dimension = int.Parse(secondLine[0]);
            
            for (int i = 2; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    continue;
                }
                this.set.Add(new List<double>());
                string[] line = lines[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < line.Length; j++)
                {                    
                    set[i - 2].Add(float.Parse(line[j]));
                }                
            }
        }        
    }
}
