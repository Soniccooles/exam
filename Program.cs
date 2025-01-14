using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsPrograms.TaskLevel1;
using TestsPrograms.TaskLevel2.Linked;
using TestsPrograms.TaskLevel2.Other;
using TestsPrograms.TaskLevel3;
using TestsPrograms.TaskLevel3.BFSandDFS;
using TestsPrograms.TaskLevel3.ExternalSortAlgorithms;
using TestsPrograms.TaskLevel3.SpanningTreeAndDijkstra;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestsPrograms
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите категорию заданий: 1, 2 или 3");
            string key = Console.ReadLine();
            switch (key)
            {
                case "1": Task1(); break;
                case "2": Task2(); break;
                case "3": Task3(); break;
            }
        }
        public static void Task1()
        {
            Console.Write("Сколько чисел будет в массиве: ");
            int size = int.Parse(Console.ReadLine());

            Random random = new Random();

            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 101); // Случайное число от 1 до 100
            }

            Console.WriteLine("Ваш массив: " + string.Join(", ", array) + "\n");

            Console.WriteLine("Введите число для двоичного поиска: ");
            int key = int.Parse(Console.ReadLine());

            Console.WriteLine("BubbleSort");
            BubbleSort.Sort(array);

            Console.WriteLine("\n" + "InsertionSort");
            InsertionSort.Sort(array);

            Console.WriteLine("\n" + "SelectionSort");
            SelectionSort.Sort(array);

            Console.WriteLine("\n" + "CocktailSort");
            CocktailSort.Sort(array);

            
            Console.WriteLine("\n" + "BinarySearch");
            Console.WriteLine(BinarySearch.Search(array, key));
            Console.WriteLine("\n" + "Нажмите любую клавишу чтобы вернуться в меню");
            Console.ReadLine();
            MainMenu();
        }
        public static void Task2()
        {
            Console.Write("Сколько чисел будет в массиве: ");
            int size = int.Parse(Console.ReadLine());

            Random random = new Random();

            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 10001); // Случайное число от 1 до 100
            }
            int[] array2 = new int[size]; int[] array3 = new int[size]; int[] array4 = new int[size];

            Array.Copy(array, array2, array.Length);
            Array.Copy(array, array3, array.Length);
            Array.Copy(array, array4, array.Length);

            Console.WriteLine("\n" + "ShellSort");
            ShellSort.Sort(array);

            Console.WriteLine("\n" + "QuickSort");
            QuickSort.StartQuickSort(array2, 0, array.Length - 1);

            Console.WriteLine("\n" + "TreeSort");
            TreeSort.Sort(array3);

            Console.WriteLine("\n" + "RadixSort");
            RadixSort.Sort(array4);

            Console.WriteLine("\n" + "LinkedQueue");
            MyQueue linkedQueue = new MyQueue();
            foreach (var integer in array) linkedQueue.Enqueue(integer);
            linkedQueue.Print(); 
            Console.Write("Peek: " + linkedQueue.Peek()); 
            while (linkedQueue.Count > 0) linkedQueue.Dequeue();
            Console.Write(" isEmpty: " + linkedQueue.IsEmpty());

            Console.WriteLine("\n" + "LinkedStack");
            MyStack linkedStack = new MyStack();
            foreach (var integer in array) linkedStack.Push(integer);
            linkedStack.Print(); 
            Console.Write("Peek: " + linkedStack.Peek());
            while (linkedStack.Count > 1) linkedStack.Pop();
            Console.Write(" isEmpty: " + linkedStack.IsEmpty());


            Console.WriteLine("\n" + "Нажмите любую клавишу чтобы вернуться в меню");
            Console.ReadLine();
            MainMenu();
        }

        public static void Task3()
        {
            // Единый граф (матрица смежности)
            int[,] graph = new int[,]
            {
                { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };

            // Список рёбер для Kruskal
            List<Edge> edges = new List<Edge>
            {
                new Edge { Source = 0, Destination = 1, Weight = 4 },
                new Edge { Source = 0, Destination = 7, Weight = 8 },
                new Edge { Source = 1, Destination = 2, Weight = 8 },
                new Edge { Source = 1, Destination = 7, Weight = 11 },
                new Edge { Source = 2, Destination = 3, Weight = 7 },
                new Edge { Source = 2, Destination = 5, Weight = 4 },
                new Edge { Source = 2, Destination = 8, Weight = 2 },
                new Edge { Source = 3, Destination = 4, Weight = 9 },
                new Edge { Source = 3, Destination = 5, Weight = 14 },
                new Edge { Source = 4, Destination = 5, Weight = 10 },
                new Edge { Source = 5, Destination = 6, Weight = 2 },
                new Edge { Source = 6, Destination = 7, Weight = 1 },
                new Edge { Source = 6, Destination = 8, Weight = 6 },
                new Edge { Source = 7, Destination = 8, Weight = 7 }
            };

            // Проверка BFS
            BFSAlgorithm bfs = new BFSAlgorithm(9); // 9 вершин
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] != 0)
                    {
                        bfs.AddEdge(i, j);
                    }
                }
            }

            Console.WriteLine("\n" + "BFS");
            Console.WriteLine("Обход графа с вершины 0:");
            bfs.BFS(0);

            // Проверка DFS
            DFSAlgorithm dfs = new DFSAlgorithm(9); // 9 вершин
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] != 0)
                    {
                        dfs.AddEdge(i, j);
                    }
                }
            }

            Console.WriteLine("\n" + "DFS");
            Console.WriteLine("Обход графа с вершины 0:");
            dfs.DFS(0);

            // Проверка Kruskal
            KruskalAlgorithm kruskal = new KruskalAlgorithm();
            Console.WriteLine("\n" + "KruskalAlgorithm");
            kruskal.KruskalMinSpanningTree(9, edges);

            // Проверка Prim
            PrimAlgorithm prim = new PrimAlgorithm();
            Console.WriteLine("\n" + "PrimAlgorithm");
            prim.PrimMST(graph, 9);

            // Проверка Dijkstra
            Console.WriteLine("\n" + "DijkstraAlgorithm");
            DijkstraAlgorithm.Dijkstra(graph, 0);

            // Пример использования NaturalMergeSort
            string inputFile = "input.txt";
            string outputFileNatural = "output_natural.txt";

            // Создаем входной файл с данными
            int[] naturalMergeArray = { 34, 7, 23, 32, 5, 62, 34, 12, 45, 3, 54, 23, 43, 65, 21 };
            File.WriteAllLines(inputFile, naturalMergeArray.Select(x => x.ToString()));

            NaturalMergeSort naturalMergeSort = new NaturalMergeSort();
            naturalMergeSort.Sort(inputFile, outputFileNatural);

            // Читаем отсортированный файл и выводим результат
            string[] sortedArrayNatural = File.ReadAllLines(outputFileNatural);
            Console.WriteLine("Отсортированный массив (NaturalMergeSort): " + string.Join(", ", sortedArrayNatural));

            // Пример использования DirectMergeSort
            string outputFile = "output_direct.txt";
            int blockSize = 5;

            // Создаем входной файл с данными
            int[] directMergeArray = { 34, 7, 23, 32, 5, 62, 34, 12, 45, 3, 54, 23, 43, 65, 21 };
            File.WriteAllLines(inputFile, directMergeArray.Select(x => x.ToString()));

            DirectMergeSort directMergeSort = new DirectMergeSort();
            directMergeSort.Sort(inputFile, outputFile, blockSize);

            // Читаем отсортированный файл и выводим результат
            string[] sortedArrayDirect = File.ReadAllLines(outputFile);
            Console.WriteLine("Отсортированный массив (DirectMergeSort): " + string.Join(", ", sortedArrayDirect));

            // Пример использования KWayMergeSort
            string outputFileKWay = "output_kway.txt";
            int k = 3;

            KWayMergeSort kWayMergeSort = new KWayMergeSort();
            kWayMergeSort.Sort(inputFile, outputFileKWay, k);

            // Читаем отсортированный файл и выводим результат
            string[] sortedArrayKWay = File.ReadAllLines(outputFileKWay);
            Console.WriteLine("Отсортированный массив (KWayMergeSort): " + string.Join(", ", sortedArrayKWay));

            Console.WriteLine("\n" + "Нажмите любую клавишу чтобы вернуться в меню");
            Console.ReadLine();
            MainMenu();
        }
    }
}
