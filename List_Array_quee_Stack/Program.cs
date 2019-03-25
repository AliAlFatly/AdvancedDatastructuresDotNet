using System;
using System.Collections.Generic;

namespace Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var Test1 = new SortedList<int>();
            Test1.Insert(3);
            Test1.Insert(2);
            Test1.Insert(1);
            Test1.Insert(8);
            Test1.Insert(6);
            Test1.Insert(3);
            Test1.Print();
            Test1.Insert(9);
            //Test1.Delete(0);
            //Test1.Delete(9);
            Test1.Print();
            Console.WriteLine(Test1.Search(2));
            Console.WriteLine(Test1.Search(1));

            Console.WriteLine("-----");

            var Test2 = new DoubleLinkedList<int>();
            Test2.InsertBeginning(3);
            Test2.InsertBeginning(4);
            Test2.InsertAfter(4, 5);
            Test2.InsertEnd(8);
            Test2.InsertBefore(8, 9);
            Test2.InsertBeginning(3);
            Test2.Delete(9);
            Test2.Print();

            Console.WriteLine("-----");

            var T3 = new Stack<int>(5);
            T3.push(4);
            Console.WriteLine(T3.peek());
            T3.push(5);
            T3.push(1);
            Console.WriteLine(T3.peek());
            T3.pop();
            Console.WriteLine(T3.peek());

            Console.WriteLine("-----");

            var T4 = new DynamicStack<int>();
            //T4.pop();

            T4.push(4);
            Console.WriteLine(T4.peek());
            T4.push(5);
            T4.push(1);
            Console.WriteLine(T4.peek());
            T4.pop();
            Console.WriteLine(T4.peek());

            Console.WriteLine("-----");


            var T5 = new Quee<int>(5);
            //T4.pop();

            T5.QueeItem(4);
            T5.QueeItem(5);
            T5.QueeItem(6);
            T5.QueeItem(7);
            T5.QueeItem(5);
            T5.QueeItem(1);
            Console.WriteLine(T5.peek());
            var a1 = T5.Dequee();
            var a2 = T5.Dequee();
            var a3 = T5.Dequee();
            var a4 = T5.Dequee();
            var a5 = T5.Dequee();
            var a6 = T5.Dequee();
            Console.WriteLine(a1);
            Console.WriteLine(a2);
            Console.WriteLine(a3);
            Console.WriteLine(a4);
            Console.WriteLine(a5);
            Console.WriteLine(a6);


            Console.WriteLine("-----");

            var T6 = new DynamicQuee<int>();
            //T4.pop();

            T6.Quee(4);
            T6.Quee(5);
            T6.Quee(6);
            T6.Quee(7);
            T6.Quee(5);
            T6.Quee(1);
            Console.WriteLine(T6.peek());
            var b1 = T6.Dequee();
            var b2 = T6.Dequee();
            var b3 = T6.Dequee();
            var b4 = T6.Dequee();
            var b5 = T6.Dequee();
            var b6 = T6.Dequee();
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine(b3);
            Console.WriteLine(b4);
            Console.WriteLine(b5);
            Console.WriteLine(b6);





            var a = Console.ReadLine();

        }

        public class Node<T>
        {
            public T v { get; set; } //v
            public Node<T> n { get; set; } //next

            public Node(T value, Node<T> next)
            {
                v = value;
                n = next;
            }
        }

        public class SortedList<T> where T : IComparable
        {
            public Node<T> Start { get; set; }

            public void Print()
            {
                var PrintStart = Start;
                if (PrintStart == null)
                {
                    Console.WriteLine("List is empty");
                }
                else
                {

                    while (PrintStart != null)
                    {
                        Console.WriteLine(Convert.ToString(PrintStart.v));
                        PrintStart = PrintStart.n;
                    }
                }
            }

            public void Insert(T v)
            {
                if (Start == null || Start.v.CompareTo(v) == 1)
                {
                    this.Start = new Node<T>(v, Start);
                }
                else
                {
                    var InsertStart = Start;
                    while (InsertStart.n != null && InsertStart.n.v.CompareTo(v) == -1)
                    {
                        InsertStart = InsertStart.n;
                    }
                    InsertStart.n = new Node<T>(v, InsertStart.n);
                }

            }

            public void Delete(T v)
            {
                if (Start == null | Start.v.CompareTo(v) == -1)
                {

                }
                if (Start.v.CompareTo(v) == 0)
                {
                    Start = Start.n;
                }
                else if (Start.v.CompareTo(v) == -1)
                {
                    var TempStart = Start;
                    while (TempStart.n != null && TempStart.n.v.CompareTo(v) == -1)
                    {
                        if (TempStart.n.v.CompareTo(v) == 0)
                        {
                            TempStart.n = TempStart.n.n;
                        }
                        TempStart = TempStart.n;
                    }

                }

            }

            public string Search(T v)
            {
                if (Start == null)
                {
                    return "the list is empty";
                }
                if (Start.v.CompareTo(v) == 1)
                {
                    return $"the value {v} doesnt exist in the list";
                }
                else
                {
                    var TempSearch = Start;
                    while (TempSearch != null && TempSearch.v.CompareTo(v) != 0)
                    {
                        if (TempSearch.v.CompareTo(v) == 0)
                        {
                            return $"The value {TempSearch.v} exists in the list";
                        }
                        TempSearch = TempSearch.n;
                    }
                    return $"the value {v} doesnt exist in the list";
                }
            }
        }

        public class DoubleNode<T> where T : IComparable
        {
            public T v { get; set; }
            public DoubleNode<T> next { get; set; }
            public DoubleNode<T> prev { get; set; }
            public DoubleNode(T Value, DoubleNode<T> Next, DoubleNode<T> Prev)
            {
                v = Value;
                next = Next;
                prev = Prev;
            }
        }

        public class DoubleLinkedList<T> where T : IComparable
        {
            public DoubleNode<T> First { get; set; }
            public DoubleNode<T> Last { get; set; }

            public void Print()
            {
                if (First == null)
                {
                    Console.WriteLine("List is empty");
                }
                else
                {
                    var PrintNode = First;
                    while (PrintNode != null)
                    {
                        Console.WriteLine(Convert.ToString(First.v));
                        PrintNode = PrintNode.next;
                    }
                }
            }

            public int Count()
            {
                var i = 0;
                var c = First;
                while (c != null)
                {
                    c = c.next;
                    i++;
                }
                return i;
            }

            public void InsertAfter(T after, T v)
            {
                if (First == null)
                {
                    Console.WriteLine("The list is empty, the after Doesnt exist");
                }
                else if (First.v.CompareTo(after) == 0)
                {
                    First.next = new DoubleNode<T>(v, First.next, First);
                    if (First.next.next != null)
                    {
                        First.next.next.prev = First.next;
                    }
                }
                else
                {
                    var TempInsert = First;
                    while (TempInsert.next != null && TempInsert.next.v.CompareTo(after) != 0)
                    {
                        TempInsert = TempInsert.next;
                    }
                    if (TempInsert.next.v.CompareTo(after) == 0)
                    {
                        TempInsert.next = new DoubleNode<T>(v, TempInsert.next, TempInsert);
                        if (TempInsert.next.next != null)
                        {
                            TempInsert.next.next.prev = TempInsert.next;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The list doenst comtain the after value");
                    }
                }
            }

            public void InsertBefore(T before, T v)
            {
                if (Last == null)
                {
                    Console.WriteLine("the list is empty");
                }
                else if (Last.v.CompareTo(before) == 0)
                {
                    Last.prev = new DoubleNode<T>(v, Last, Last.prev);
                    if (Last.prev.prev != null)
                    {
                        Last.prev.prev.next = Last.prev;
                    }
                }
                else
                {
                    var TempBackInsert = Last;
                    while (TempBackInsert.prev != null && TempBackInsert.prev.v.CompareTo(before) != 0)
                    {
                        TempBackInsert = TempBackInsert.prev;
                    }
                    if (TempBackInsert.prev.v.CompareTo(before) == 0)
                    {
                        TempBackInsert.prev = new DoubleNode<T>(v, TempBackInsert, TempBackInsert.prev);
                        if (TempBackInsert.prev.prev != null)
                        {
                            TempBackInsert.prev.prev.next = TempBackInsert.prev;
                        }
                    }
                    else
                    {
                        Console.WriteLine("the before value doenst exist in the list");
                    }
                }
            }

            public void InsertBeginning(T v)
            {
                if (First == null)
                {
                    First = new DoubleNode<T>(v, null, null);
                    Last = First;
                }
                else
                {
                    First.prev = new DoubleNode<T>(v, First, null);
                    First = First.prev;
                }
            }

            public void InsertEnd(T v)
            {
                if (Last == null)
                {
                    Last = new DoubleNode<T>(v, null, null);
                    First = Last;
                }
                else
                {
                    Last.next = new DoubleNode<T>(v, null, Last);
                    Last = Last.next;
                }
            }

            public void Delete(T v)
            {

                if (First == null)
                {

                }
                else if (First.v.CompareTo(v) == 0)
                {
                    First = First.next;
                    First.prev.next = null;
                    First.prev = null;
                }
                else
                {
                    var TempDelete = First;
                    while (TempDelete.next != null && TempDelete.next.v.CompareTo(v) != 0)
                    {
                        TempDelete = TempDelete.next;
                    }
                    if (TempDelete.next.v.CompareTo(v) == 0)
                    {
                        if (TempDelete.next.next == null)
                        {
                            TempDelete.next = TempDelete.next.next;
                        }
                        else
                        {
                            TempDelete.next.next.prev = TempDelete;
                            TempDelete.next = TempDelete.next.next;
                        }
                    }
                }

            }
        }


        public class Stack<T> where T : IComparable
        {
            public T[] S { get; set; }
            public int Top { get; set; }

            public Stack(int size)
            {
                S = new T[size];
                Top = -1;
            }

            public bool isEmpty()
            {
                if (S == null)
                {
                    return true;
                }
                return false;
            }

            public T pop()
            {
                if (!isEmpty())
                {
                    Top = Top - 1;
                    return S[Top];
                }
                return S[Top];
            }

            public void push(T v)
            {
                if (Top + 1 > S.Length - 1)
                {
                    var TempStack = new T[S.Length * 2];
                    for (int i = 0; i < S.Length; i++)
                    {
                        TempStack[i] = S[i];
                    }
                    S = TempStack;
                }
                S[Top + 1] = v;
                Top++;
            }

            public string peek()
            {
                if (isEmpty())
                {
                    return "null";
                }
                return $"{S[Top]}";
            }
        }

        public class DynamicStack<T> where T : IComparable
        {
            public DoubleNode<T> Top { get; set; }

            public bool isEmpty()
            {
                if (Top == null)
                {
                    return true;
                }
                return false;
            }

            public T pop()
            {
                if (!isEmpty())
                {
                    Top = Top.prev;
                    Top.next.prev = Top.next.next;
                    Top.next = Top.next.next;
                    return Top.v;
                }
                return Top.v;
            }

            public void push(T v)
            {
                if (isEmpty())
                {
                    Top = new DoubleNode<T>(v, null, null);
                }
                else
                {
                    Top.next = new DoubleNode<T>(v, null, Top);
                    Top = Top.next;
                }
            }

            public string peek()
            {
                if (isEmpty())
                {
                    return "null";
                }
                return $"{Top.v}";
            }
        }




        public class Quee<T> where T : IComparable
        {
            public T[] Q { get; set; }
            public int Rear { get; set; }
            public int Front { get; set; }

            public Quee(int Size)
            {
                Q = new T[Size];
                Rear = -1;
                Front = -1;
            }

            public bool isEmpty()
            {
                if (Rear == -1 | Front == -1)
                {
                    return true;
                }
                if (Q[Rear] == null | Rear == -1 | Front == -1)
                {
                    return true;
                }
                return false;
            }

            public bool IsFull()
            {
                if (!isEmpty() && Rear - 1 == Front | Rear == 0 && Front == Q.Length || Front + 1 == Rear)
                {
                    return true;
                }
                return false;
            }

            public bool QueeCap()
            {
                if (Rear == 0 && Front != 0)
                {
                    return true;
                }
                return false;
            }

            public void resize()
            {
                var TempQuee = new T[Q.Length * 2];
                for (int i = 0; i < Q.Length; i++)
                {
                    TempQuee[i] = Q[i];
                }
                Q = TempQuee;
            }

            public T Dequee()
            {
                if (!isEmpty())
                {
                    //Q[Front] = null;
                    Front++;
                    if (Front != -1)
                    {
                        return Q[Front];
                    }
                    else
                    {
                        return default(T);
                    }
                }
                else
                {
                    return default(T);
                }

            }

            public void QueeItem(T v)
            {
                if (IsFull())
                {
                    resize();
                }

                if (isEmpty())
                {
                    Rear++;
                    Front++;
                    Q[Rear] = v;
                }
                else
                {
                    if (QueeCap())
                    {
                        Rear = Q.Length - 1;
                        Q[Rear] = v;
                    }
                    else
                    {
                        Rear++;
                        Q[Rear] = v;
                    }
                }
            }

            public T peek()
            {
                if (Front != -1)
                {
                    return Q[Front];
                }
                else
                {
                    return default(T);
                }
            }

        }

        public class DynamicQuee<T> where T : IComparable
        {
            public DoubleNode<T> Rear { get; set; }
            public DoubleNode<T> Front { get; set; }

            public bool isEmpty()
            {
                if (Rear == null || Front == null)
                {
                    return true;
                }
                return false;
            }

            public T Dequee()
            {
                if (isEmpty())
                {
                    return default(T);
                }
                else if (Rear == Front)
                {
                    Rear = Rear.prev;
                    Front = Front.prev;
                    return default(T);
                }
                else
                {
                    Front = Front.prev;
                    Front.next.prev = Front.next.next;
                    Front.next = Front.next.next;
                    return Front.v;
                }
            }

            public void Quee(T v)
            {
                if (isEmpty())
                {
                    Rear = new DoubleNode<T>(v, null, null);
                    Front = Rear;
                }
                else
                {
                    Rear.prev = new DoubleNode<T>(v, Rear, null);
                    Rear = Rear.prev;
                }
            }

            public T peek()
            {
                return Front.v;
            }

        }

    }





}
