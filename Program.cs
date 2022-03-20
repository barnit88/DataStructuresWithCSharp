using System;
using Arrays;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new Array<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);
            array.Add(10);
            Console.WriteLine(array.Size());
            array.RemoveAt(4);
            var x = array.Current;
            Console.WriteLine(array.Size());


            Console.WriteLine("Hello World!");
        }
    }
}
