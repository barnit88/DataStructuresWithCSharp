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


            var priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(2,2);
            priorityQueue.Enqueue(2,2);
            priorityQueue.Enqueue(3,3);
            priorityQueue.Enqueue(43,43);
            priorityQueue.Enqueue(3,3);
            priorityQueue.Enqueue(4,5);
            priorityQueue.Enqueue(4,4);
            priorityQueue.Enqueue(5,6);
            priorityQueue.Enqueue(1,1);
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            //foreach(var item in priorityQueue)
            //{
            //    Console.WriteLine(item);
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
