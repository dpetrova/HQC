//+----------------+------------------+------------------+------------------+
//|     method     |      n = 10      |     n = 1000     |    n = 100000    |
//+----------------+------------------+------------------+------------------+
//| Selection sort | 00:00:00.0007036 | 00:00:00.0362201 | 00:03:39.9990124 |
//| Insertion sort | 00:00:00.0005804 | 00:00:00.0161053 | 00:02:51.8839282 |
//| Merge sort     | 00:00:00.0010611 | 00:00:00.0015919 | 00:00:00.7756645 |
//+----------------+------------------+------------------+------------------+

namespace CompareSorting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal class Program
    {
        private static void Main()
        {
            var listWith10Elements = CreateRandomList(10);
            var listWith1000Elements = CreateRandomList(1000);
            var listWith100000Elements = CreateRandomList(100000);

            var stopwatch = new Stopwatch();

            Console.WriteLine("Test sorting of 10 elements:");
            stopwatch.Start();
            SelectionSort(listWith10Elements);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed selection sort: {0}", stopwatch.Elapsed);

            stopwatch.Restart();
            InsertionSort(listWith10Elements);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed insertion sort: {0}", stopwatch.Elapsed);
            

            stopwatch.Restart();
            MergeSort(listWith10Elements, 0, listWith10Elements.Count / 2);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed merge sort: {0}", stopwatch.Elapsed);
            Console.WriteLine();

            Console.WriteLine("Test sorting of 1000 elements:");
            stopwatch.Restart();
            SelectionSort(listWith1000Elements);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed selection sort: {0}", stopwatch.Elapsed);

            stopwatch.Restart();
            InsertionSort(listWith1000Elements);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed insertion sort: {0}", stopwatch.Elapsed);

            stopwatch.Restart();
            MergeSort(listWith1000Elements, 0, listWith1000Elements.Count / 2);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed merge sort: {0}", stopwatch.Elapsed);
            Console.WriteLine();

            Console.WriteLine("Test sorting of 100000 elements:");
            stopwatch.Restart();
            InsertionSort(listWith100000Elements);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed insertion sort: {0}", stopwatch.Elapsed);

            stopwatch.Restart();
            MergeSort(listWith100000Elements, 0, listWith100000Elements.Count / 2);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed merge sort: {0}", stopwatch.Elapsed);

            stopwatch.Restart();
            SelectionSort(listWith100000Elements);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed selection sort: {0}", stopwatch.Elapsed);
        }

        public static void SelectionSort(List<int> collection)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                var min = i;
                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j] < collection[min])
                    {
                        // find min value
                        min = j;
                    }

                    // then swap it with the beginning item of the unsorted list
                    var temp = collection[i];
                    collection[i] = collection[min];
                    collection[min] = temp;
                }
            }
        }

        public static void InsertionSort(List<int> collection)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                var targetIndex = i;

                while (targetIndex > 0)
                {
                    if (collection[targetIndex - 1].CompareTo(collection[targetIndex]) > 0)
                    {
                        var temp = collection[targetIndex - 1];
                        collection[targetIndex - 1] = collection[targetIndex];
                        collection[targetIndex] = temp;
                    }

                    targetIndex--;
                }
            }
        }

        public static void MergeSort(List<int> collection, int startIndex, int endIndex)
        {
            int mid;

            if (endIndex > startIndex)
            {
                mid = (endIndex + startIndex) / 2;
                MergeSort(collection, startIndex, mid);
                MergeSort(collection, mid + 1, endIndex);
                Merge(collection, startIndex, mid + 1, endIndex);
            }
        }

        public static void Merge(List<int> collection, int left, int mid, int right)
        {
            // Merge procedure takes theta(n) time
            var temp = new int[collection.Count];
            int i, leftEnd, lengthOfInput, tmpPos;
            leftEnd = mid - 1;
            tmpPos = left;
            lengthOfInput = right - left + 1;

            // selecting smaller element from left sorted array or right sorted array and placing them in temp array.
            while ((left <= leftEnd) && (mid <= right))
            {
                if (collection[left] <= collection[mid])
                {
                    temp[tmpPos++] = collection[left++];
                }
                else
                {
                    temp[tmpPos++] = collection[mid++];
                }
            }

            // placing remaining element in temp from left sorted array
            while (left <= leftEnd)
            {
                temp[tmpPos++] = collection[left++];
            }

            // placing remaining element in temp from right sorted array
            while (mid <= right)
            {
                temp[tmpPos++] = collection[mid++];
            }

            // placing temp array to input
            for (i = 0; i < lengthOfInput; i++)
            {
                collection[right] = temp[right];
                right--;
            }
        }

        private static List<int> CreateRandomList(int length)
        {
            var rand = new Random();
            var rndlist = new List<int>();

            for (var i = 0; i < length; i++)
            {
                rndlist.Add(rand.Next(1000));
            }

            return rndlist;
        }
    }
}