using System;
using Arrays;
using LinkedList;
using BinaryHeap;
using QueueImplementation;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class Program
    {
        static void Main(string[] args)
        {


            int[] arr = { 1, 2, 3, 4, 5, 56, 67, 12 };
            List<int> arrList = new List<int>(){ 1, 2, 3, 4, 5, 56, 67, 12 };
            Console.WriteLine(arrList);
            //MinHeap<int> minHeap = new MinHeap<int>(arr);
            //MinHeap<int> minHeap1 = new MinHeap<int>(arrList);
            //minHeap.Insert(1);
            //minHeap.Insert(10);
            //minHeap.Insert(100);
            //minHeap.Insert(2);
            //minHeap.Insert(3);
            //minHeap.Insert(5);
            //minHeap.Insert(6);
            //Console.WriteLine(minHeap.Contains(3));
            //Console.WriteLine("---------");
            //foreach(var x in minHeap)
            //{
            //    Console.WriteLine(x);
            //}
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        static void DoublyLinkedList()
        {
            DoublyLinkedList<int> integerlist = new DoublyLinkedList<int>();
            integerlist.AddFirst(9);
            integerlist.AddFirst(8);
            integerlist.AddFirst(7);
            integerlist.AddFirst(6);
            integerlist.AddFirst(5);
            integerlist.AddFirst(4);
            integerlist.AddFirst(3);
            integerlist.AddFirst(2);
            integerlist.AddFirst(1);
            foreach (int data in integerlist)
            {
                Console.WriteLine(data);
            }
            var datas = integerlist.GetReverseEnumerator();
            foreach (var da in datas)
            {
                Console.WriteLine(da);
            }
            integerlist = null;
        }
        private class Person : IComparable
        {
            public string firstName;
            public string lastName;
       
            public int CompareTo(object obj)
            {
                return this.firstName.CompareTo(((Person)obj).firstName);
            }

            public override int GetHashCode()
            {
                return firstName.GetHashCode();
            }

        }
    }
}
