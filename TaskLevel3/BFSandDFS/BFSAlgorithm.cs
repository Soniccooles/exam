using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel3.BFSandDFS
{
    internal class BFSAlgorithm
    {
        private List<int>[] vList;
        public BFSAlgorithm(int size)
        {
            vList = new List<int>[size];
            for (int i = 0; i < size; i++)
                vList[i] = new List<int>();
        }

        public void AddEdge(int s, int e)
        {
            vList[s].Add(e);
        }

        public void BFS(int s)
        {
            bool[] visited = new bool[vList.Length];
            Queue<int> ints = new Queue<int>();
            visited[s] = true;
            ints.Enqueue(s);
            while (ints.Count > 0)
            {
                int current = ints.Dequeue();
                Console.Write(current + " ");
                foreach(var neighbour in vList[current])
                {
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        ints.Enqueue(neighbour);
                    }
                }
            }
        }
    }
}
