using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel2.Other
{
    public class QuickSort : ISortAlgorithm
    {
        public static string Name => "QuickSort";

        public static void StartQuickSort(int[] array, int left, int right)
        {
            Sort(array, left, right);
            Console.WriteLine(string.Join(", ", array));
        }

        public static void Sort(int[] array, int left, int right)
        {
            int i = left, j = right;
            int pivot = array[(right + left) / 2];
            while (i <= j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j) Sort(array, left, j);
            if (i < right) Sort(array, i, right);
        }

        public static void Sort2(int[] array, int left, int right)
        {
            int i = left, j = right;
            int pivot = array[(left + right) / 2];
            while (i <= j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j) Sort2(array, left, j);
            if (i < right) Sort2(array, i, right);
        }
    }
}
