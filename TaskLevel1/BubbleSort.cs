﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel1
{
    public class BubbleSort : ISortAlgorithm
    {
        public static string Name => "BubbleSort";
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }
        public static void Sort2(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
    }
}
