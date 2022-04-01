using BinaryHeap;
using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueImplementation
{
    /// <summary>
    ///     #### PRIORITY QUEUE ####
    ///     
    /// ### What is an Priority Queue?
    /// A Priority Queue is an Abstract Data Type(ADT)
    /// that operates similar to a normal queue except
    /// that each element has certain priority. The priority 
    /// of the element in the queue determines the order in 
    /// which the elements are removed from the Priority Queue.
    /// NOTE :- Priority Queue only supports comparabnle data,
    /// meaning the data inserted into the priority queue must be
    /// ordered in some way either from least to greatest or
    /// greatest to least. This is so that we are able4 to 
    /// assign relative priorities to each element.
    /// 
    /// ### Abstract Data Type 
    /// Abstract Data Type is are those data type which can perform 
    /// certain set of operations but how doesn't care about how it is 
    /// implemented. It does not specify how data is to be stored in 
    /// the memory and what algorithms will be used for implementating 
    /// the operations.
    /// 
    /// ### What is a HEAP?
    /// A heap is a tree based Data Struture that statisfies the
    /// heap invariant (also called heap property): If A is a 
    /// parent node of B then A is ordered with respect to B for
    /// all nodes A, B in the heap.
    /// 
    /// ### When and where is A PQ used?
    /// 1> Used in certail implementations of Djikstra's
    /// shortest Path algorithm.
    /// 2> Anytime you need to dynamically fetch the next best
    /// or next worst element.
    /// 3> Used in Huffman coding( which is ofter used for 
    /// lossless data compression).
    /// 4> Best Firsdt Search (BFS) algorithms such as A*
    ///  use PQs to continously grab the next most promising 
    ///  node.
    ///  5> Use by minimum spanning tree (MST) algorithms.
    ///  
    /// ### Complexity PQ with Binary Heap
    /// BINARY HEAP CONSTRUCTION :- O(n)
    /// POLLING :- O(log(n))
    /// PEEKING :- O(1)
    /// ADDING :- O(log(n))
    /// NAIVE REMOVING :- O(n)
    /// NAIVE CONTAINS :- O(n)
    /// ADVANCED REMOVING WITH HELP OF HASH TABLE :- O(log(n))
    /// ADVANCED CONTAINS WITH HELP OF HASH TABLE :- O(1)
    /// 
    /// ### Turning Min PQ to Max PQ
    /// PROBLEM<:- Often the standar library of most programming
    /// languages only provide a min PQ which sorts by smallest
    /// elements first, but sometimes we need a MAX PQ.
    /// 
    /// Since elements in a priority queue are comparable 
    /// they implement some sort of Comparable interface 
    /// which we can simpy negate to acheive a Max heap.
    /// 
    /// ### Ways of Implementing a Priority Queue
    /// Priority Queue are ususally implemented with heaps 
    /// since heaps gives Priority Queue the best possible 
    /// time complexity.
    /// 
    /// The Priority Queue(PQ) is an Abstract Data Type(ADT),
    /// hence heaps are not teh only way to impelement PQs. As 
    /// an example, we could use an usorted list, but this 
    /// would not give us the best possible time complexity.
    /// 
    /// ### Priority Queue With Binary Heap
    /// There are many types of heaps we could use to 
    /// implement a priority queue including:
    /// 1> Binary Heap
    /// 2> Fibonacci Heap
    /// 3> Binomial Heap
    /// 4> Pairing Heap
    /// 
    /// ### Priority Queue With Binary Heap
    /// A binary heap is a  binary tree that supports the 
    /// Heap Invariant. A Binary Heap is either Min Heap or 
    /// Max Heap. A binary heap is typically represented as 
    /// array.
    /// ## Complete Binary Tree
    ///  A complete binary tree is a tree in which at every 
    ///  level except possibley the last level is completely 
    ///  filled and all the nodes are as far left as possible.
    /// 
    ///  # HEAP 
    ///  Heap is a Binary Tree where the value is 
    ///  inserted to the left most empty node and 
    ///  removed from the right most node and must 
    ///  follow the HEAP Invariant i.e The tree must 
    ///  be maximally balanced and every node must be
    ///  smaller then parent node for MAX Heap and 
    ///  greater then parnet node for MEAN Heap.
    ///  There are two types of HEAP and they are :
    ///  1> Min HEAP :- The parent must me smaller then
    ///  child node.
    ///  2> Max HEAP :- The parent must be greater then 
    ///  child node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> : IPriorityQueue<T>,IEnumerable<T> where T : IComparable<T> 
    {
        public int Size { get; private set; } = 0;
        private MinHeap<Node> minHeap;
        /// <summary>
        /// Default constructor that intializes priority queue with default capacity.
        /// </summary>
        public PriorityQueue(){
            minHeap = new MinHeap<Node>();
        }
        /// <summary>
        /// Remove object from PriorityQueue with highest prioirty
        /// </summary>
        /// <returns>Object that is removed from PriorityQueue</returns>
        public T Dequeue()
        {
            try
            {
                this.Size--;
                return minHeap.Remove().Data;
            }
            catch (Exception ex)
            {
                this.Size++;
                return default;
            }

        }
        /// <summary>
        /// Insert Object into PriorityQueue
        /// </summary>
        /// <param name="priority">Priority of Object</param>
        /// <param name="item">Object to be inserted into PriorityQueue</param>
        public void Enqueue(int priority,T item)
        {
            try
            {
                this.Size++;
                var node = new Node(priority, item);
                minHeap.Insert(node);
            }
            catch (Exception ex)
            {
                this.Size--;
            }
        }
        /// <summary>
        /// Searches the PriorityQueue for given object and returns the priority of the object
        /// </summary>
        /// <param name="item">Object</param>
        /// <returns>Returns priority of the first object that matches the given object</returns>
        public int GetPriority(T item)
        {
            foreach (var element in minHeap)
            {
                if (element.Data.CompareTo(item) == 0)
                    return element.Priority;
            }
            return -1;
        }
        /// <summary>
        /// Check if the object is in the Priority Queue
        /// </summary>
        /// <param name="item">Object that is to be checked in the Priority Queue</param>
        /// <returns>Return true if the given object is in the Priority Queue otherwise, false</returns>
        public bool IsInQueue(T item)
        {
            return GetPriority(item) > -1 ? true : false;
        }
        /// <summary>
        /// Updates the priority of the given object.
        /// For  multiple items that matches the same object, highest priority object in the priority queues priorty will be updated
        /// </summary>
        /// <param name="item">Objects whose priority is to be updated</param>
        /// <returns>Return true if priority is updates otherwise false</returns>
        public bool UpdatePriority(T item,int priority)
        {
            try
            {
                int index = 0;
                while (minHeap.HeapLength > index)
                {
                    if (minHeap[index].Data.CompareTo(item) == 0)
                    {
                        minHeap[index].Priority = priority;
                        return true;
                    }
                    index++;
                }
                return false;
            }
            catch (Exception ex) {
                return false;
            }

            //foreach (var element in minHeap)
            //{
            //    if (element.Data.CompareTo(item) == 0)
            //    {
            //        element.Priority = priority;
            //        return true;
            //    }
            //}
            //return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            T[] data = new T[minHeap.HeapLength];
            int index = 0;
            while(minHeap.HeapLength > 0)
            {
                data[index] = minHeap.Remove().Data;
                index++;
            }
            return ((IEnumerable<T>)data).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Each Node contains the data and priority of the data
        /// </summary>
        private class Node : IComparable
        {
            public Node(int priority,T data)
            {
                Priority = priority;
                Data = data;
            }
            /// <summary>
            /// Priority of the data
            /// </summary>
            public int Priority { get; set; }
            /// <summary>
            /// Item that holds data
            /// </summary>
            public T Data { get; set; }
            public int CompareTo(object obj)
            {
                return this.Priority.CompareTo(((Node)obj).Priority);
            }
        }
    }
    public interface IPriorityQueue<T>
    {
        int Size { get; }
        T Dequeue();
        void Enqueue(int priority,T item);
        bool IsInQueue(T item);
        int GetPriority(T item);
        bool UpdatePriority(T item,int priority);
    }
}

