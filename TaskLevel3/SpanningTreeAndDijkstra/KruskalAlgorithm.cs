using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel3.SpanningTreeAndDijkstra
{
    public class Edge : IComparable<Edge>
    {
        public int Source, Destination, Weight;
        public int CompareTo(Edge other) => Weight.CompareTo(other.Weight);
    }

    public class  KruskalAlgorithm
    {
        int[] parent;
        public int Find(int i)
        {
            if (parent[i] == i) return i;
            return parent[i] = Find(parent[i]);
        }

        private void Union(int x, int y)
        {
            int xRoot = Find(x);
            int yRoot = Find(y);
            parent[xRoot] = yRoot;
        }

        public void KruskalMinSpanningTree(int vertices, List<Edge> edges)
        {
            edges.Sort();
            parent = new int[vertices];
            for (int i = 0; i < vertices; i++)
                parent[i] = i;
            List<Edge> mst = new List<Edge>();
            foreach( Edge edge in edges )
            {
                int x = Find(edge.Source);
                int y = Find(edge.Destination);
                if (x != y)
                {
                    mst.Add(edge);
                    Union(x, y);
                }
            }
            foreach(var edge in mst)
                Console.WriteLine(edge.Source + " <=> " + edge.Destination + " : " + edge.Weight);
        }
    }
}

