using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel2.HashTables
{
    internal class OpenAddressingHashTable
    {
        private int?[] table;
        public OpenAddressingHashTable(int size)
        {
            table = new int?[size];
        }
        private int Hash(int key) => key % table.Length;
        public void Insert(int key)
        {
            int index = Hash(key);
            while (table[index] != null)
            {
                index = (index + 1) % table.Length;
            }
            table[index] = key;
        }

        public bool Search(int key)
        {
            int index = Hash(key);
            int start = index;
            while (table[index] != null)
            {
                if (table[index] == key)
                    return true;
                index = (index + 1) % table.Length;
                if (index == start)
                    break;
            }
            return false;
        }
        public void Remove(int key)
        {
            int index = Hash(key);
            int start = index;
            while (table[index] != null)
            {
                if (table[index] == key)
                {
                    table[index] = null;
                    return;
                }
                index = (index + 1) % table.Length;
                if (index == start)
                    break;
            }
        }
    }

    public class OAHT
    {
        public int?[] table;
        public OAHT(int size)
        {
            table = new int?[size];
        }

        public int Hash(int key) => key % table.Length;

        public void Insert(int key)
        {
            int index = Hash(key);
            while (table[index] != null)
                index = (index + 1) % table.Length;
            table[index] = key;
        }
        
        public bool Search(int key)
        {
            int index = Hash(key);
            int start = index;
            while (table[index] != null)
            {
                if (table[index] == key)
                    return true;
                index = (index + 1) % table.Length;
                if (index == start)
                    break;
            }
            return false;
        }

        public void Remove(int key)
        {
            int index = Hash(key);
            int start = index;
            while (table[index] != null)
            {
                if (table[index] == key)
                {
                    table[index] = null;
                    return;
                }

                index = (index+1) % table.Length;
                if (index == start)
                    break;
            }
        }
    }
}
