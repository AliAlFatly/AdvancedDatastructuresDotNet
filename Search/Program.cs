using System;
using System.Collections.Generic;

namespace Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var A1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var A2 = new char[] { 'a', 'b', 'c', 'd', 'e' };

            Console.WriteLine(SequentialSearch(A1, 5));
            Console.WriteLine(SequentialSearch(A2, 'D')); //captial d

            Console.WriteLine(BinarySearch(A1, 5));
            Console.WriteLine(BinarySearch(A2, 'a'));
            Console.WriteLine(RecursiveBinarySearch(A1, 3, 0, A1.Length - 1));
            Console.WriteLine(RecursiveBinarySearch(A2, 'd', 0, A2.Length - 1));
            var a = Console.ReadLine();
        }

        public static string SequentialSearch<T>(T[] A, T v) where T : IComparable<T>
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i].Equals(v))
                {
                    return $"The value {A[i]} is found in the array at the index{i}";
                }
            }
            return $"The value {v} doesnt exist in the given array";
        }

        public static string BinarySearch<T>(T[] A, T v) where T : IComparable<T>
        {
            var low = 0;
            var high = A.Length - 1;
            while (low <= high)
            {
                var middle = (low + high) / 2;
                if (v.CompareTo(A[middle]) == 1)
                {
                    low = middle + 1;
                }
                else if (v.CompareTo(A[middle]) == -1)
                {
                    high = middle - 1;
                }
                else
                {
                    return $"the value {A[middle]} exists in the array at the index {middle}";
                }

            }
            return $"the value {v} Doesnt exist in the given array";
        }

        public static string RecursiveBinarySearch<T>(T[] A, T v, int low, int high) where T : IComparable<T>
        {
            var middle = (low + high) / 2;
            if (low > high)
            {
                return $"The value {v} was nout found in the array";
            }
            if (v.CompareTo(A[middle]) == 1)
            {
                return RecursiveBinarySearch(A, v, middle + 1, high);
            }
            else if (v.CompareTo(A[middle]) == -1)
            {
                return RecursiveBinarySearch(A, v, low, middle - 1);
            }
            else
            {
                return $"the value {A[middle]} was found at the index {middle}";
            }
        }


    }





}
