using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestsPrograms.TaskLevel3.ExternalSortAlgorithms
{
    public class NaturalMergeSort
    {
        public void Sort(string inputFile, string outputFile)
        {
            List<string> tempFiles = SplitFile(inputFile);
            MergeFiles(tempFiles, outputFile);
        }

        private List<string> SplitFile(string inputFile)
        {
            List<string> tempFiles = new List<string>();
            using (StreamReader reader = new StreamReader(inputFile))
            {
                List<int> sequence = new List<int>();
                string tempFile = Path.GetTempFileName();
                tempFiles.Add(tempFile);
                StreamWriter writer = new StreamWriter(tempFile);

                string line;
                int prevValue = int.MinValue;

                while ((line = reader.ReadLine()) != null)
                {
                    int currentValue = int.Parse(line);

                    if (currentValue < prevValue)
                    {
                        // Конец текущей последовательности
                        writer.Close();
                        tempFile = Path.GetTempFileName();
                        tempFiles.Add(tempFile);
                        writer = new StreamWriter(tempFile);
                    }

                    writer.WriteLine(currentValue);
                    prevValue = currentValue;
                }

                writer.Close();
            }

            return tempFiles;
        }

        private void MergeFiles(List<string> tempFiles, string outputFile)
        {
            var readers = tempFiles.Select(f => new StreamReader(f)).ToList();
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                // Используем SortedDictionary с ключом (число, индекс файла)
                SortedDictionary<(int, int), StreamReader> minHeap = new SortedDictionary<(int, int), StreamReader>();

                // Добавляем первые элементы из каждого файла
                for (int i = 0; i < readers.Count; i++)
                {
                    if (!readers[i].EndOfStream)
                    {
                        int value = int.Parse(readers[i].ReadLine());
                        minHeap.Add((value, i), readers[i]); // Используем (value, i) как уникальный ключ
                    }
                }

                while (minHeap.Count > 0)
                {
                    // Извлекаем минимальный элемент
                    var min = minHeap.First();
                    writer.WriteLine(min.Key.Item1); // Записываем число
                    minHeap.Remove(min.Key);

                    // Читаем следующее число из того же файла
                    if (!min.Value.EndOfStream)
                    {
                        int nextValue = int.Parse(min.Value.ReadLine());
                        int fileIndex = min.Key.Item2; // Используем тот же индекс файла
                        minHeap.Add((nextValue, fileIndex), min.Value);
                    }
                }
            }

            // Закрываем все StreamReader
            foreach (var reader in readers)
            {
                reader.Close();
            }

            // Удаляем временные файлы
            foreach (var tempFile in tempFiles)
            {
                File.Delete(tempFile);
            }
        }
    }
}