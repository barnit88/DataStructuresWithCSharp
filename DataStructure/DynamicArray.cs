using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    /// <summary>
    /// ### Dynamic Array ###
    /// Dynamic array are arrays that can grow its size
    /// 
    /// A static array is a fixed length container containing n elements
    /// indexable from the range 0 to n-1.
    /// 
    /// Indexable means that every slot/index in the array can be referenced 
    /// with a number.
    /// 
    /// When and Where is a static Array Used?
    /// 1> Storing and Acccesing sequential data.
    /// 2> Temporarily storing objects.
    /// 3> Used by IO routines as buffers.
    /// 4> Lookup table and inverse lookup tables.
    /// 5> Can be used to return multiple values from a function.
    /// 6> Used in dynamic programming to cache answers to subproblems.Eg Knapsack problem 
    /// or coin change problem.
    /// 
    /// 
    /// #### Complexity Analysis Static Array
    /// Access :- O(1)
    /// Search :- O(n)
    /// Insertions :- N/A
    /// Appending :- N/A
    /// Deletion :- N/A
    /// 
    /// #### Complexity Analysis Dynamic Array
    /// Access :- O(1)
    /// Search :- O(n)
    /// Insertions :- O(n) //Insert at start index
    /// Appending :- O(1) //Append at Last index
    /// Deletion :- O(n) 
    /// 
    /// Example of a Dynamic Array From Static Array
    /// </summary>
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] arr;
        private int length = 0; //actual array length
        private int capacity = 0; // capacity of array 

        public DynamicArray()
        {
            this.arr = new T[8];
            this.capacity = 8;
            //Requires more processing time using LINQ
            //object[] objectArray = new object[10];
            //this.arr = objectArray.OfType<T>().ToArray();
        }
        public DynamicArray(int capacity)
        {
            if (capacity < 0)
                throw new Exception("Invalid Capacity " + capacity);
            this.arr = new T[capacity];
            this.capacity = capacity;
        }
        public int Size()
        {
            return length;
        }
        public bool IsEmpty()
        {
            return Size() == 0;
        }
        public void Clear()
        {
            this.arr = null;
            this.length = 0;
            this.capacity = 0;
        }
        public T this[int index] { 
            get { return arr[index]; } 
            set { arr[index] = value; }
        }
        public void Add(T item)
        {
            //Resize if capacity is full
            if(length+1 >= capacity)
            {
                ResizeArray();
            }
            this.arr[length] = item;
            this.length += 1;
        }
        public T RemoveAt(int index)
        {
            if (index < 0 || index > length)
                throw new IndexOutOfRangeException();
            T[] tempArr = new T[capacity];
            this.length -= 1;
            for(int i = 0,j=0; i < length; i++,j++)
            {
                if(i == index)
                {
                    j--;
                    continue;
                }
                tempArr[j] = this.arr[i];
            }
            this.arr = tempArr;
            return this.arr[index];
        }
        public bool Remove(T item)
        {
            for(int i = 0; i < length; i++)
            {
                if(this.arr[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (this.arr[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        private void ResizeArray()
        {
            if (this.capacity == 0)
                this.capacity = 1;
            else
                this.capacity *= 2;
            //Copying previous content into new Array
            T[] tempArr = new T[this.capacity];
            for (int i = 0; i < this.length; i++)
            {
                tempArr[i] = arr[i];
            }
            this.arr = tempArr;
        }
        public void Reset()
        {
            Clear();
        }
        public void Dispose()
        {
            GC.Collect();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return arr.OfType<T>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}