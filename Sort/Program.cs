using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var A1 = new int[] { 0, 3, 6, 8, 19, 4, 7, 6, 5, 1, 2 };
            var A2 = new char[] { 'b', 'e', 'q', 'y', 'a', 'c' }; //char filter not working?

            InsertionSorting(A2);

            BubbleSorting(A1);

            foreach (var i in A1)
            {
                Console.WriteLine(Convert.ToString(i));
            }

            foreach (var i in A2)
            {
                Console.WriteLine(Convert.ToString(i));
            }

            var a = Console.ReadLine();

        }

        public static void InsertionSorting<T>(T[] A) where T : IComparable<T>
        {
            for (int i = 0; i < A.Length; i++)
            {
                var Key = A[i];
                var j = i - 1;
                while (j > -1 && A[j].CompareTo(Key) == 1)
                {
                    A[j + 1] = A[j];
                    j--;
                }
                A[j + 1] = Key;
            }
        }

        public static void BubbleSorting<T>(T[] A) where T : IComparable<T>
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = A.Length - 1; j > i; j--)
                {
                    if (A[j - 1].CompareTo(A[j]) == 1)
                    {
                        var key = A[j];
                        A[j] = A[j - 1];
                        A[j - 1] = key;
                    }
                }

            }

        }

    }


}
