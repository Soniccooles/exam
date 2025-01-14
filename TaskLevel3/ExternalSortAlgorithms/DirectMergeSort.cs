using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestsPrograms.TaskLevel3.ExternalSortAlgorithms
{
    public class DirectMergeSort
    {
        public void Sort(string inputFile, string outputFile, int blockSize)
        {
            List<string> tempFiles = SplitFile(inputFile, blockSize);
            MergeFiles(tempFiles, outputFile);
        }

        private List<string> SplitFile(string inputFile, int blockSize)
        {
            List<string> tempFiles = new List<string>();
            using (StreamReader reader = new StreamReader(inputFile))
            {
                while (!reader.EndOfStream)
                {
                    List<int> block = new List<int>();
                    for (int i = 0; i < blockSize && !reader.EndOfStream; i++)
                    {
                        block.Add(int.Parse(reader.ReadLine()));
                    }
                    block.Sort();
                    string tempFile = Path.GetTempFileName();
                    File.WriteAllLines(tempFile, block.Select(x => x.ToString()));
                    tempFiles.Add(tempFile);
                }
            }
            return tempFiles;
        }

        private void MergeFiles(List<string> tempFiles, string outputFile)
        {
            var readers = tempFiles.Select(f => new StreamReader(f)).ToList();
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                SortedDictionary<(int, int), StreamReader> minHeap = new SortedDictionary<(int, int), StreamReader>();

                for (int i = 0; i < readers.Count; i++)
                {
                    if (!readers[i].EndOfStream)
                    {
                        int value = int.Parse(readers[i].ReadLine());
                        minHeap.Add((value, i), readers[i]);
                    }
                }

                while (minHeap.Count > 0)
                {
                    var min = minHeap.First();
                    writer.WriteLine(min.Key.Item1);
                    minHeap.Remove(min.Key);

                    if (!min.Value.EndOfStream)
                    {
                        int nextValue = int.Parse(min.Value.ReadLine());
                        int fileIndex = min.Key.Item2;
                        minHeap.Add((nextValue, fileIndex), min.Value);
                    }
                }
            }

            foreach (var reader in readers)
            {
                reader.Close();
            }

            foreach (var tempFile in tempFiles)
            {
                File.Delete(tempFile);
            }
        }
    }
}