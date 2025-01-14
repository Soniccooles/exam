using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel2.HashTables
{
    internal class ChainHashTable
    {
        private List<int>[] table;
        public ChainHashTable(int size)
        {
            table = new List<int>[size];
            for (int i = 0; i < size; i++)
                table[i] = new List<int>();
        }
        private int Hash(int key) => key % table.Length;

        public void Insert(int key)
        {
            int index = Hash(key);
            table[index].Add(key);
        }
        public bool Search(int key)
        {
            int index = Hash(key);
            return table[index].Contains(key);
        }
        public void Remove(int key)
        {
            int index = Hash(key);
            table[index].Remove(key);
        }
    }
}
