using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel1
{
    internal class InsertionSort : ISortAlgorithm
    {
        public static string Name => "InsertionSort";
        public static void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
            Console.WriteLine(string.Join(", ", array));
        }
        public static void Sort2(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    array[j+1] = array[j];
                    j--;
                }
                array[j+1] = temp;
            }
        }
    }
}
