using System;
using System.Collections.Generic;

namespace Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Hashtable<string, int>(10);

            t1.insert("rad", 10);
            t1.insert("abc", 11);
            t1.insert("abcd", 5);
            t1.insert("bcd", 3);
            t1.insert("b", 6);
            t1.insert("a", 7);

            t1.insert("q", 101);
            t1.insert("c", 114);
            t1.insert("d", 53);
            t1.insert("e", 36);
            t1.insert("j", 63);
            t1.insert("i", 72);


            t1.insert("o", 363);
            t1.insert("n", 634);
            t1.insert("m", 725);


            Console.WriteLine(t1.Search("rad"));
            Console.WriteLine(t1.Search("abc"));
            Console.WriteLine(t1.Search("abcd"));
            Console.WriteLine(t1.Search("b"));
            Console.WriteLine(t1.Search("bcd"));
            Console.WriteLine(t1.Search("a"));
            Console.WriteLine(t1.Search("q"));
            Console.WriteLine(t1.Search("awrawer"));
            Console.WriteLine(t1.Search("vasdf"));
            Console.WriteLine(t1.Search("wew"));
            Console.WriteLine(t1.Search(""));


            var a = Console.ReadLine();
        }


        public class Bucket<k, v>
        {
            public v Value { get; set; }
            public k Key { get; set; }
            public Bucket(k key, v value)
            {
                Value = value;
                Key = key;
            }
        }

        public class Hashtable<k, v>
        {
            public int l { get; set; }
            public float u { get; set; }
            public Bucket<k, v>[] A { get; set; }

            public Hashtable(int size)
            {
                l = size;
                u = 0;
                A = new Bucket<k, v>[size];
            }

            public void insert(k K, v v)
            {
                int hash = K.GetHashCode();
                int I = hash % l;
                if (I < 0)
                {
                    I = I * -1;
                }

                if (A[I] == null)
                {
                    A[I] = new Bucket<k, v>(K, v);

                }
                else
                {
                    if (u / l > 0.7)
                    {
                        resize();
                    }
                    var j = true;
                    var init = I;
                    while (I < l && j)
                    {
                        if (A[I] == null)
                        {
                            A[I] = new Bucket<k, v>(K, v);
                            j = false;
                        }
                        I++;
                    }
                    I = 0;
                    while (I < init && j)
                    {
                        if (A[I] == null)
                        {
                            A[I] = new Bucket<k, v>(K, v);
                            j = false;
                        }
                        I++;
                    }
                }

                u++;

            }

            public float loadfactor()
            {
                return u / l;
            }

            public void resize()
            {
                var TempA = new Bucket<k, v>[l * 2];
                for (int i = 0; i < l; i++)
                {
                    TempA[i] = A[i];
                }
                A = TempA;
                l = l * 2;
            }

            public string Search(k key)
            {
                for (int i = 0; i < l; i++)
                {
                    if (A[i] != null && A[i].Key.Equals(key))
                    {
                        return $"{A[i].Value}";
                    }
                }
                return $"Key is invalid or is not bound to a bucket";
            }

        }

    }




}
