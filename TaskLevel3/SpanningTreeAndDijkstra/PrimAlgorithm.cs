using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel3.SpanningTreeAndDijkstra
{
    internal class PrimAlgorithm
    {
        public void PrimMST(int[,] graph, int vertices)
        {
            int[] key = new int[vertices];
            bool[] included = new bool[vertices];
            int[] parent = new int[vertices];
            for (int i = 0; i < vertices; i++)
            {
                key[i] = int.MaxValue;
                included[i] = false;
            }
            key[0] = 0;
            parent[0] = -1;
            for (int count = 0; count < vertices - 1; count++)
            {
                int u = MinKey(key, included, vertices);
                included[u] = true;
                for (int v = 0; v < vertices; v++)
                {
                    if (graph[u, v] != 0 && !included[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            Console.WriteLine("Рёбра минимального остовного дерева:");
            for (int i = 1; i < vertices; i++)
                Console.WriteLine($"{parent[i]} - {i} : {graph[i, parent[i]]}");
        }
        private int MinKey(int[] key, bool[] included, int vertices)
        {
            int min = int.MaxValue, minIndex = -1;
            for (int v = 0; v < vertices; v++)
            {
                if (!included[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
    }
}
