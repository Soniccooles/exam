using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestsPrograms.TaskLevel3.ExternalSortAlgorithms
{
    public class KWayMergeSort
    {
        public void Sort(string inputFile, string outputFile, int k)
        {
            List<string> tempFiles = SplitFile(inputFile, k);
            MergeFiles(tempFiles, outputFile);
        }

        private List<string> SplitFile(string inputFile, int k)
        {
            List<string> tempFiles = new List<string>();
            using (StreamReader reader = new StreamReader(inputFile))
            {
                int totalLines = File.ReadAllLines(inputFile).Length;
                int chunkSize = totalLines / k;
                int remaining = totalLines % k;

                for (int i = 0; i < k; i++)
                {
                    List<int> chunk = new List<int>();
                    int currentChunkSize = chunkSize + (i < remaining ? 1 : 0);

                    for (int j = 0; j < currentChunkSize && !reader.EndOfStream; j++)
                    {
                        chunk.Add(int.Parse(reader.ReadLine()));
                    }

                    chunk.Sort();
                    string tempFile = Path.GetTempFileName();
                    File.WriteAllLines(tempFile, chunk.Select(x => x.ToString()));
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