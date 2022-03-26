using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImplementation
{
    /// <summary>
    /// #####Stack#####
    /// 
    /// ### What is a Stack?
    /// A stack is a one-ended linear data structure which models 
    /// a real world stack. A Stack has two primary operation
    /// push and pop. All operation of stack is performed from the 
    /// Top Of Stack (TOS). Stack works on LIFO(Last In First Out) 
    /// principal.
    /// 
    /// ### When and Where is Stack Used?
    /// 1> Used by undo mechanism in text editor.
    /// 2> Used in compiler syntax checking for matching brackets and braces.
    /// 3> Can be used to model a pile of books or plates.
    /// 4> Used behind the scenes to support recursion by keeping track of 
    ///     previous function calls.
    /// 5> Can be used to do a Depth First Search (DFS) on a graph.
    /// 
    /// ### Complexity Analysis of Stack
    /// PUSH    :- O(1)
    /// POP     :- O(1)
    /// PEEKING :- O(1)
    /// SEARCHING :- O(n)
    /// SIZE    :- O(1)
    /// 
    /// 
    /// ### Implementing Stack using Doubly Linked List
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class Stack<T>
    {
        private int Size = 0;
        private DoublyLinkedList<T> linkedList = new();
        public void Push(T item)
        {
            linkedList.AddLast(item);
            Size++;
        }

        public T Pop()
        {
            if (Size == 0)
                throw new Exception("Empty Stack");
            T item = linkedList.RemoveLast();
            Size--;
            return item;
        }
        public T Peek()
        {
            if (Size == 0)
                return default;
            T item = linkedList.PeekLast();
            return item;
        }
        public void Clear()
        {
            if(Size > 0)
            {
                linkedList.Clear();
                Size = 0;
            }
        }
        public int Count()
        {
            return Size;
        }
    }

}
