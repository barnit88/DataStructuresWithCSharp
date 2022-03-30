using BinaryHeap;
using LinkedList;
using System;
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
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T> 
    {

        private MinHeap<Node> minHeap;
        public PriorityQueue(){}
        /// <summary>
        /// Remove item from queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            return minHeap.Remove().Data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="item"></param>
        public void Enqueue(int priority,T item)
        {
            var node = new Node(priority, item);
            minHeap.Insert(node);
        }
        public void GetPriority(T item)
        {
            throw new NotImplementedException();
        }
        public bool IsInQueue(T item)
        {
            throw new NotImplementedException();
        }
        public void UpdatePriority(T item)
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
        T Dequeue();
        void Enqueue(int priority,T item);
        bool IsInQueue(T item);
        void GetPriority(T item);
        void UpdatePriority(T item);

    }
}

