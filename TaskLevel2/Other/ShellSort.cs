using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestsPrograms.TaskLevel2.Other
{
    public class ShellSort : ISortAlgorithm
    {
        public static string Name => "ShellSort";
        public static void Sort(int[] array)
        {
            int gap = array.Length / 2;
            while (gap > 0)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
                gap /= 2;
            }
            Console.WriteLine(string.Join(", ", array));
        }
        public static void Sort2(int[] array)
        {
            
        }
    }
}
