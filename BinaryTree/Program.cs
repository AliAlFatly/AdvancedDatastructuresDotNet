using System;
using System.Collections.Generic;

namespace Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new BinaryTree<int>();
            t1.Insert(5);
            t1.Insert(6);
            t1.Insert(8);
            t1.Insert(3);
            t1.Insert(9);
            t1.Insert(1);
            t1.Insert(2);
            t1.Insert(0);

            //t1.Delete(5); //delete werkt niet

            Console.WriteLine("--in order----");
            t1.InOrder(t1.Root);
            Console.WriteLine("--in order----");




            Console.WriteLine("--PreOrder----");
            t1.PreOrder(t1.Root);   
            Console.WriteLine("--PreOrder----");




            Console.WriteLine("--PostOrder----");
            t1.PostOrder(t1.Root);
            Console.WriteLine("--PostOrder----");

            Console.WriteLine(Convert.ToString(t1.Search(8)));



            Console.WriteLine(Convert.ToString(t1.IterativeSearch(8)));
            var a = Console.ReadLine();
        }

        public class BinaryNode<T> where T : IComparable
        {
            public T v { get; set; }
            public BinaryNode<T> l { get; set; }
            public BinaryNode<T> r { get; set; }

            public BinaryNode(T Value, BinaryNode<T> Left, BinaryNode<T> Right)
            {
                v = Value;
                l = Left;
                r = Right;
            }
        }

        public class BinaryTree<T> where T : IComparable
        {
            public BinaryNode<T> Root { get; set; }

            public void Insert(T v)
            {
                if (Root == null)
                {
                    Root = new BinaryNode<T>(v, null, null);
                }
                else if (Root.v.CompareTo(v) == -1) //root < v
                {
                    InsertRight(v, Root);
                    Console.WriteLine($"Value {v} is Inserted right");
                }
                else if (Root.v.CompareTo(v) == 1)
                {
                    InsertLeft(v, Root);
                    Console.WriteLine($"Value {v} is Inserted left");
                }
                else if (Root.v.Equals(v))
                {
                    Console.WriteLine("Value exists in the BinaryTree");
                }

            }

            public void InsertRight(T v, BinaryNode<T> r)
            {
                if(r.r == null)
                {
                    r.r = new BinaryNode<T>(v, null, null);
                }
                else if(r.r.v.CompareTo(v) == -1)
                {
                    InsertRight(v, r.r);
                }
                else if(r.r.v.CompareTo(v) == -1)
                {
                    InsertLeft(v, r.r);
                }
                else if(r.v.CompareTo(v) == 0)
                {
                    Console.WriteLine($"The value {v} already exists in the tree");
                }
            }

            public void InsertLeft(T v, BinaryNode<T> r)
            {
                if (r.l == null)
                {
                    r.l = new BinaryNode<T>(v, null, null);
                    //Console.WriteLine("Inserted:");
                }
                else if (r.l.v.CompareTo(v) == -1)
                {
                    InsertRight(v, r.l);
                    
                }
                else if (r.l.v.CompareTo(v) == 1)
                {
                    InsertLeft(v, r.l);
                }
                else if (Root.l.v.Equals(v))
                {
                    Console.WriteLine("Value exists in the BinaryTree");
                }
            }

            public T IterativeSearch(T v)
            {
                while (Root != null && !Root.v.Equals(v))
                {
                    if (Root.v.CompareTo(v) == -1)
                    {
                        Root = Root.r;
                    }
                    else
                    {
                        Root = Root.l;
                    }
                }
                return default(T); //if noting exists return null?
            }

            public T Search(T v)
            {
                if (Root == null)
                {
                    return default(T);
                }
                else if (Root.v.Equals(v))
                {
                    return Root.v;
                }
                else if (Root.v.CompareTo(v) == -1)
                {
                    return Search(v, Root.r);
                }
                else
                {
                    return Search(v, Root.l);
                }
            }

            public T Search(T v, BinaryNode<T> r)
            {
                if (r == null)
                {
                    return default(T);
                }
                else if (r.v.Equals(v))
                {
                    return r.v;
                }
                else if (r.v.CompareTo(v) == -1)
                {
                    return Search(v, r.r);
                }
                else
                {
                    return Search(v, r.l);
                }
            }
            //delete fix(not working as intended)
            public void Delete(T v)
            {
                if(Root.v.Equals(v))
                {
                    if(Root.r == null && Root.l == null)
                    {
                        Root = null;
                    }
                    else if(Root.l != null)
                    {
                        var TempRoot = Root.l;
                        while(TempRoot.r != null)
                        {
                            TempRoot = TempRoot.r;
                        }
                        Delete(TempRoot.v);
                        Root.v = TempRoot.v;                        
                    }
                    else
                    {
                        var TempRoot = Root.r;
                        while(TempRoot.l !=null)
                        {
                            TempRoot = TempRoot.l;
                        }
                        Delete(TempRoot.v);
                        Root.v = TempRoot.v;
                        
                    }
                }
                else
                {
                    while(Root != null && Root.v.CompareTo(v) != 0)
                    {
                        if(Root.v.CompareTo(v) == -1)
                        {
                            Root = Root.r;
                        }
                        else if(Root.v.CompareTo(v) == 1)
                        {
                            Root = Root.l;
                        }
                        else if(Root.v.CompareTo(v) == 0)
                        {
                            if (Root.r == null && Root.l == null)
                            {
                                Root = null;
                            }
                            else if (Root.l != null)
                            {
                                var TempRoot = Root.l;
                                while (TempRoot.r != null)
                                {
                                    TempRoot = TempRoot.r;
                                }
                                Delete(TempRoot.v);
                                Root.v = TempRoot.v;
                            }
                            else
                            {
                                var TempRoot = Root.r;
                                while (TempRoot.l != null)
                                {
                                    TempRoot = TempRoot.l;
                                }
                                Delete(TempRoot.v);
                                Root.v = TempRoot.v;

                            }
                        }
                        else
                        {
                            Console.WriteLine("The given value doesnt exist in the tree");
                        }

                    }
                }
                
                
            }

            

            public void PreOrder(BinaryNode<T> r)
            {
                if (r != null)
                {
                    Console.WriteLine(Convert.ToString(r.v));
                    PreOrder(r.l);
                    PreOrder(r.r);
                }
            }

            public void InOrder(BinaryNode<T> r)
            {
                if (r != null)
                {
                    InOrder(r.l);
                    Console.WriteLine(Convert.ToString(r.v));
                    InOrder(r.r);
                }
            }

            public void PostOrder(BinaryNode<T> r)
            {
                if (r != null)
                {
                    PostOrder(r.l);
                    PostOrder(r.r);
                    Console.Write(Convert.ToString(r.v));
                }
            }


        }


    }


}
