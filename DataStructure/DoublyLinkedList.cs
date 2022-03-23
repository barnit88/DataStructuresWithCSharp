using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    /// <summary>
    /// ####What is a Linked List?
    /// A linked list is a sequential list of nodes
    /// that holds that and also points to the other 
    /// nodes also containing data.Every node containing 
    /// data has a pointer that points to another node.
    /// Note :- Last node of the linked list points to
    /// the node containing null
    /// 
    /// ####Where are Linked List used?
    /// 1> Used in many List, Queue And Stack implementations.
    /// 2> Great for creating Circular List.
    /// 3> Can easily model real world objects such as Trains.
    /// 4> Used in separate chaining, which is present certain 
    ///     Hashtable implementations to deal with hashing collisons.
    /// 5> Other used in the implementation of adjacency lists for 
    ///     graphs.
    /// 
    /// ####Terminology Used in Linked List
    /// HEAD :- The first node in the Linked List.
    /// TAIL :- The last node in the Linked List.
    /// POINTER :- Reference to another node
    /// NODE :- An object containing data and pointer.
    /// 
    /// #### Singly VS Doubly Linked List
    /// #Singly Linked List
    /// Singly Linked List only hold a reference to the next node.
    /// In the implementation you always maintain a reference to the 
    /// HEAD of the Linked Lisrt and a reference to the TAIL of the 
    /// Linked List for quick additions and removals of nodes.
    /// -Pros
    /// 1> Uses less memory 
    /// 2> Simpler Implementation  
    /// -Cons
    /// 1> Cannot easily access previous nodes.
    /// 
    /// #Doubly Linked List
    /// With a Doubly Linked List each node holds a reference to the 
    /// next and previous node.In the implementation you always maintain 
    /// a reference to the HEAD and the TAIL of the doubly Linked List to 
    /// do quick additions/removals from both ends of the lists.
    /// -Pros
    /// 1> Can be traversed backwards.
    /// -Cons
    /// 1> Takes 2x memory then Singly Linked List.
    /// 
    /// 
    /// #### Complexity Analysis Singly Linked List
    /// SEARCH :- O(n)
    /// INSERT AT HEAD :- O(1)
    /// INSERT AT TAIL :- O(1)
    /// REMOVE AT HEAD :- O(1)
    /// REMOVE AT TAIL :- O(1) // Seek to the value at 
    ///                        // end to specify new TAIL
    /// REMOVE IN MIDDLE :-O(n)
    /// 
    /// #### Complexity Analysis Doubly Linked List
    /// SEARCH :- O(n)
    /// INSERT AT HEAD :- O(1)
    /// INSERT AT TAIL :- O(1)
    /// REMOVE AT HEAD :- O(1)
    /// REMOVE AT TAIL :- O(1)
    /// REMOVE IN MIDDLE :-O(n)
    ///  
    /// </summary>
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private int Size = 0;
        private Node<T> Head = null;
        private Node<T> Tail = null;
        //Internal Node class to represent data
        private class Node<T>
        {
            //Node data
            public T Data;
            //Previous and Next nodes
            public Node<T> Prev, Next;
            public Node(T data, Node<T> prev, Node<T> next)
            {
                this.Data = data;
                this.Prev = prev;
                this.Next = next;
            }
            public override string ToString()
            {
                return Data.ToString();
            }
        }
        //Clear Linked List - O(n)
        public void Clear()
        {
            Node<T> traverse = Head;
            while (traverse != null)
            {
                Node<T> next = traverse.Next;
                traverse.Prev = traverse.Next = null;
                traverse.Data = default;
                traverse = next;
            }
            this.Head = this.Tail = traverse = null;
        }
        //Check if List is Empty
        public bool IsEmpty()
        {
            return this.Size == 0;
        }
        //Size of List
        public int GetSize()
        {
            return Size;
        }
        //Adding at TAIL - O(1)
        public void AddLast(T item)
        {
            if (this.Head == null)
                this.Head = this.Tail
                    = new Node<T>(item, null, null);
            else
            {
                //Node<T> traverse = this.Head;
                //while (traverse.Next != null)
                //{
                //    traverse = traverse.Next;
                //}
                //traverse.Next = new Node<T>(item, traverse, null);
                //this.Tail = traverse.Next;
                this.Tail.Next = new Node<T>(item, this.Tail, null);
                this.Tail = this.Tail.Next;
                //traverse.Next = new Node<T>(item, traverse, null);
            }
            Size++;
        }
        //Adding at HEAD - O(1)
        public void AddFirst(T item)
        {
            if (this.Head == null)
                this.Head = this.Tail
                    = new Node<T>(item, null, null);
            else
            {
                this.Head.Prev = new Node<T>(item, null, Head);
                this.Head = this.Head.Prev;
            }
            Size++;
        }
        //Removing Given Item :- O(n)
        public bool Remove(T item)
        {
            Node<T> traverse = this.Head;
            //for(traverse = this.Head; traverse != null; traverse = traverse.Next)
            while (traverse.Next != null)
            {
                if (traverse.Data.Equals(item))
                {
                    if (traverse.Next == null)
                        traverse.Prev.Next = null;
                    else if (traverse.Prev == null)
                        traverse.Next.Prev = null;
                    else
                    {
                        traverse.Prev.Next = traverse.Next;
                        traverse.Next.Prev = traverse.Prev;
                    }
                    traverse.Next = null;
                    traverse.Prev = null;
                    traverse.Data = default;
                    Size--;
                    return true;
                }
                traverse = traverse.Next;
            }
            return false;
        }
        //Removing First Item :- O(1)
        public T RemoveFirst()
        {
            if (IsEmpty())
                throw new Exception("List is empty.");
            T remove = this.Head.Data;
            if (this.Head.Next != null)
            {
                this.Head.Next.Prev = null;
                this.Head = this.Head.Next;
            }
            else
            {
                this.Head = this.Tail = null;
            }
            Size--;
            return remove;
        }
        //Removing Last Item :- O(1)
        public T RemoveLast()
        {
            if (GetSize() == 0)
                throw new ArgumentOutOfRangeException();

            Node<T> remove = this.Tail;
            if (this.Head.Next == null)
                this.Head = this.Tail = null;
            else
            {
                this.Tail.Prev.Next = null;
                this.Tail = this.Tail.Prev;
            }
            Size--;
            return remove.Data;
        }
        //Get index of item
        public int GetIndexOf(T item)
        {
            int index = 0;
            if (GetSize() == 0)
            {
                return -1;
            }
            Node<T> traverse = this.Head;
            for (traverse = this.Head; traverse.Next != null; traverse = traverse.Next)
            {
                index++;
                if (item.Equals(traverse.Data))
                {
                    return index;
                }
            }
            return -1;
        }
        //Get Head Data
        public T PeekFirst()
        {
            if (IsEmpty())
                throw new Exception("Empty List");
            return this.Head.Data;
        }
        //Get Tail Data
        public T PeekLast()
        {
            if (IsEmpty())
                throw new Exception("Empty List");
            return this.Tail.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] dataArray = new T[Size];
            int index = 0;
            for (Node<T> traverse = Head; traverse != null; traverse = traverse.Next)
            {
                dataArray[index] = traverse.Data;
                index++;
            }
            return dataArray.OfType<T>().GetEnumerator();
        }

        public IEnumerable<T> GetReverseEnumerator()
        {
            T[] dataArray = new T[Size];
            int index = 0;
            for (Node<T> traverse = Tail; traverse != null; traverse = traverse.Prev)
            {
                dataArray[index] = traverse.Data;
                index++;
            }
            return dataArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


    }

}
