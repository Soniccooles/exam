using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel3.BFSandDFS
{
    public class DFSAlgorithm
    {
        private List<int>[] vList;

        public DFSAlgorithm(int size)
        {
            vList = new List<int>[size];
            for (int i = 0; i < vList.Length; i++)
                vList[i] = new List<int>();
        }

        public void AddEdge(int s, int e)
        {
            vList[s].Add(e);
        }

        public void DFS(int start)
        {
            bool[] visited = new bool[vList.Length];
            DFSUtil(start, visited);
        }

        private void DFSUtil(int start, bool[] visited)
        {
            visited[start] = true;
            Console.Write(start + " ");
            foreach (var neighbour in vList[start]) 
            {
                if (!visited[neighbour])
                    DFSUtil(neighbour, visited);
            }
        }
    }
}
