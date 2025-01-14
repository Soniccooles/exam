using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel2.Other
{
    internal class RadixSort : ISortAlgorithm
    {
        public static string Name => "RadixSort";
        public static void Sort(int[] array, int numBase = 10)
        {
            int max = array.Max();
            for (int exp = 1; max / exp > 0; exp *= numBase)
            {
                CountingSort(array, exp, numBase);
            }
            Console.WriteLine(string.Join(", ", array));
        }

        public static void CountingSort(int[] array, int exp, int numBase)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[numBase];
            for (int i = 0; i < n; i++)
                count[array[i] / exp % numBase]++;

            for (int i = 1; i < numBase; i++)
                count[i] += count[i-1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[array[i] / exp % numBase] - 1] = array[i];
                count[array[i]/exp % numBase]--;
            }

            for (int i = 0; i < n; i++)
                array[i] = output[i];
        }
    }
}
