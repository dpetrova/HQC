using System;
using System.Diagnostics;

public class Assertions
{
    public static void Main()
    {
        int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null.");
        Debug.Assert(arr.Length > 0, "Array to be sorted not initialized.");
        Debug.Assert(arr.Length > 1, "Array has only one element and is already sorted.");
        for (var index = 0; index < arr.Length - 1; index++)
        {
            var minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int i = 1; i < arr.Length; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i - 1]) >= 0, "The array is not sorted properly.");
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null.");
        Debug.Assert(arr.Length > 0, "Array to be searched is not initialized.");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Index is out of range.");
        Debug.Assert(endIndex >= startIndex && endIndex < arr.Length, "Index is out of range.");
        var minElementIndex = startIndex;
        for (var i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        var oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null.");
        Debug.Assert(arr.Length > 0, "Array to be searched is not initialized.");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Index is out of range.");
        Debug.Assert(endIndex >= startIndex && endIndex < arr.Length, "Index is out of range.");
        while (startIndex <= endIndex)
        {
            var midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
               return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the left half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }
}