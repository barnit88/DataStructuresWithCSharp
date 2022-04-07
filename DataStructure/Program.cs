using System;
using Arrays;
using LinkedList;
using BinaryHeap;
using QueueImplementation;
using System.Collections;
using System.Collections.Generic;
using Tree;

namespace DataStructure
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(100);
            bst.Insert(2);
            bst.Insert(120);
            bst.Insert(22);
            bst.Insert(32);
            bst.Insert(89);
            bst.Remove(2);
            var person = new Person("Barnit", "basnet");
            Console.WriteLine(person.firstName);

            Check(person);
            Console.WriteLine(person.firstName);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        static void Check(Person data)
        {
            var x = data;
            x.firstName = "hari Parsad";
        }
        static void PriorityQueue()
        {
            var priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(2, 2);
            priorityQueue.Enqueue(2, 2);
            priorityQueue.Enqueue(3, 3);
            priorityQueue.Enqueue(43, 43);
            priorityQueue.Enqueue(3, 3);
            priorityQueue.Enqueue(4, 5);
            priorityQueue.Enqueue(4, 4);
            priorityQueue.Enqueue(5, 6);
            priorityQueue.Enqueue(1, 1);
            priorityQueue.UpdatePriority(43, 2);
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
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
            public Person(string name1, string name2)
            {
                firstName = name1;
                lastName = name2;

            }
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
