using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel1
{
    internal class BinarySearch
    {
        public static int Search(int[] array, int key)
        {
            int left = 0, right = array.Length;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == key)
                    return mid;
                if (array[mid] < key)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }

        public static int Search2(int[] array, int key)
        {
            int left = 0, right = array.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == key)
                    return mid;
                if (array[mid] < key)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }
    }
}
