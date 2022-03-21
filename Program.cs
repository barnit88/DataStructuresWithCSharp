using System;
using Arrays;
using LinkedList;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> integerlist = new DoublyLinkedList<int>();
            integerlist.Add(1);
            integerlist.Add(2);
            integerlist.Add(3);
            integerlist.Add(4);
            integerlist.Add(5);
            integerlist.Add(6);
            integerlist.Clear();
            Console.WriteLine("Hello World!");
        }
    }
}
