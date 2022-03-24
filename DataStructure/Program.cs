using System;
using Arrays;
using LinkedList;

namespace DataStructure
{
    public class Program
    {
        static void Main(string[] args)
        {

            StackImplementation.Stack<int> stack = new();
            Console.WriteLine(stack.Peek());
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
    }
}
