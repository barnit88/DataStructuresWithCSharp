﻿using System;
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
    public class DoublyLinkedList<T> 
    {
        private int Size = 0;
        private Node<T> Head = null;
        private Node<T> Tail = null;
        //Internal Node class to represent data
        private class Node<T>
        {
#nullable enable
            //Node data
            public T? data;
#nullable disable
            //Previous and Next nodes
            public Node<T> prev, next;
            public Node(T data, Node<T> prev, Node<T> next)
            {
                this.data = data;
                this.prev = prev;
                this.next = next;
            }
            public override string ToString()
            {
                return data.ToString();
            }
        }
        //Empty Linked List - O(n)
        public void Clear()
        {
            Node<T> traverse = Head;
            while(traverse != null)
            {
                Node<T> next = traverse.next;
                traverse.prev = traverse.next = null;
                traverse.data = default;
                traverse = next;
            }
            this.Head = this.Tail = traverse = null;
        }

        public void Add(T item)
        {
            if(this.Head == null)
                this.Head = this.Tail 
                    = new Node<T>(item, null, null);
            else
            {
                Node<T> traverse = this.Head;
                while(traverse.next != null)
                {
                    traverse = traverse.next;
                }
                traverse.next = new Node<T>(item, traverse, null);
                this.Tail = traverse.next;
            }
        }
    }
    
}
