using LinkedList;
using System;

namespace QueueImplementation
{

    /// <summary>
    ///     ##### QUEUE #####
    /// 
    /// ### What is a Queue?
    /// A queue is a linear data structure that models 
    /// real world QUEUE by having two primary operations 
    /// ENQUEUE and DEQUEUE. QUEUE data structure is based on
    /// FIFO (First In First Out) principle. The element which
    /// is inserted in the QUEUE at first can be removed from
    /// the QUEUE first. QUEUE allows two operations ENQUEUE and 
    /// DEQUEUE. ENQUEUE is adding and DEQUEUE is removing.
    /// 
    /// ### When and Where is a QUEUE used?
    /// 1> Any waiting line models a queue, for example 
    /// a line at bank.
    /// 2> Can be usde to efficiently keep track of the most recently 
    /// added elements
    /// 3> Web server request managemenrt where you want first come
    /// first serve.
    /// 4> Breadth First Seach Graph Traversal.
    /// 
    /// 
    /// ### Complexity Analysis of QUEUE
    /// ENQUEUE :- O(1)
    /// DEQUEUE :- O(1)
    /// PEEKING :- O(1)
    /// CONTAINS :- O(n)
    /// REMOVAL :- O(n) // Remove From the QUEUE
    /// ISEMPTY :- O(1)
    /// ####
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        private DoublyLinkedList<T> linkedList = new();
        private int Size = 0;
        public void Enqueue(T item)
        {
            linkedList.AddLast(item);
            Size++;
        }
        public T Dequeue()
        {
            if (Size == 0)
                return default;
            T item = linkedList.RemoveFirst();
            Size--;
            return item;
        }
        public int Count()
        {
            return Size;
        }
        public bool Contains(T item)
        {
            if (Size == 0)
                throw new Exception("Empty Queue");
            return linkedList.GetIndexOf(item) > -1;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }
        public T Peek()
        {
            if(Size > 0)
                return linkedList.PeekLast();
            return default;
        }
        public void Clear()
        {
            linkedList.Clear();
            Size = linkedList.GetSize();
        }
    }

}
