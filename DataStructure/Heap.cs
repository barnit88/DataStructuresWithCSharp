using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// A Binary Heap or Heap is a Tree based Data Structure 
/// where the tree is a complete Binary tree.
/// There are two types of Heap :- 
/// 1> Min Heap :- In Min Heap the element based at the 
/// parent node must be smaller then the child node.
/// Eg :-           2
///               /   \
///              3     5
///             / \   / \
///            4   6 7   9
///            
/// 2> Max Heap :- In Max Heap the element based at the parent
/// node must be greater then the child node.
/// Eg :-           100
///               /     \
///              98     78
///             /  \   /  \
///            5    4 3    2
///            
/// Removal operation of the Heap is performed on the root node of the Heap.
/// The root element is replaced with the last element of the Heap and 
/// last element is removed from the Heap and HeapLength is decreased by 1.
/// Heapify is performed inorder to satisfy the properties of Heap.
/// 
/// Heap insertion is always performed at the end of the Heap.
/// Heap size is increased by one and element to be added is placed on
/// the last node of the Heap.
/// 
/// Thus In Mean Heap, always minimum value are extracted while performing
/// removal opearation.
/// And in case of Max Heap always maximum values are extracted while 
/// performing insert operation.
/// </summary>
namespace BinaryHeap
{
    /// <summary>
    /// A Min Heap is a Binary Heap(Binary Tree Based Data Structure) where the parnet node is
    /// always smaller then the child nodes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> : Heap<T> where T : IComparable
    {
        /// <summary>
        /// Create Heap with given capacity
        /// </summary>
        /// <param name="capacity">Heap Capacity</param>
        public MinHeap(int capacity):base(capacity){}
        /// <summary>
        /// Create Heap with default capacity
        /// </summary>
        /// <param name="capacity">Heap Capacity</param>
        public MinHeap():base(){}
        /// <summary>
        /// Create Heap with enumerables
        /// </summary>
        /// <param name="collection">Enumerable</param>
        public MinHeap(IEnumerable<T> collection):base(collection){}
        /// <summary>
        /// Create heap with List
        /// </summary>
        /// <param name="collection">List of items</param>
        public MinHeap(List<T> collection):base(collection){}
        /// <summary>
        /// Capacity of Heap
        /// </summary>
        protected override int HeapCapacity { get; set; } = 0;
        /// <summary>
        /// Actual length of Heap
        /// </summary>
        public override int HeapLength { get; set; } = 0;
        /// <summary>
        /// Array as heap
        /// </summary>
        protected override List<T> heap { get; set; }
        /// <summary>
        /// Checks if element is in the Heap
        /// </summary>
        /// <param name="item">Element to check</param>
        /// <returns>Return true if element exist otherise false</returns>
        public override bool Contains(T item)
        {
            int root = 0;

            QueueImplementation.Queue<int> queuedIndex = new();
            if (this.HeapLength == 0)
                throw new Exception("Heap is empty");

            queuedIndex.Enqueue(root);
            while (queuedIndex.Count() > 0)
            {
                if (Contain(item, root))
                {
                    Console.WriteLine(root);
                    Console.WriteLine("Form Parent");
                    return true;
                }

                if (ChildNodeContainsItem(item, root))
                {
                    int leftChild = LeftChild(root);
                    int rightChild = RightChild(root);
                    if (Contain(item, leftChild))
                    {
                        Console.WriteLine(leftChild);
                        Console.WriteLine("Form Left Child");
                        return true;
                    }
                    queuedIndex.Enqueue(leftChild);
                    if (Contain(item, rightChild))
                    {
                        Console.WriteLine(rightChild);
                        Console.WriteLine("Form Right Child");
                        return true;
                    }
                    queuedIndex.Enqueue(rightChild);
                }
                root = queuedIndex.Dequeue();
            }

            return false;
        }
        /// <summary>
        /// Internal method to check if item is in the given heap index
        /// </summary>
        /// <param name="item">Item to check in heap</param>
        /// <param name="index">Index of heap</param>
        /// <returns>True if the item is in the given heap index otherwise false</returns>
        private bool Contain(T item, int index)
        {
            if (this.heap[index].CompareTo(item) == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if child nodes contains the given element
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="parent">Heap index</param>
        /// <returns>Returns true if the child of given heap index can probably contain the item otherwise false</returns>
        private bool ChildNodeContainsItem(T item, int parent)
        {
            //item is greated than heap parent item
            if (this.heap[parent].CompareTo(item) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Maintains the heap property.
        /// Incase of Min Heap Heapify Top checks if 
        /// parent element is smaller then the child. 
        /// If parent element is greater
        /// then the child it swaps parent with child . This process
        /// repeats until the parent is smaller then child
        /// </summary>
        /// <param name="index">Index</param>
        protected override void HeapifyTop(int index)
        {
            if (index >= HeapLength)
                return;
            int parent = GetParent(index);
            //Parent node exists
            if (parent >= 0 && parent != index)
            {
                //Parent node value is greated than child node
                //1 preceeded 2 returns -1
                if (this.heap[parent].CompareTo(this.heap[index]) > 0)
                {
                    //Swap index item with parent item
                    Swap(parent, index);
                    HeapifyTop(parent);
                }
            }
        }
        /// <summary>
        /// Maintains the heap property.
        /// Incase of Min Heap HeapifyBottom checks if child 
        /// element is greater then the parent. 
        /// If child element is smaller
        /// then the parent it swaps 
        /// parent with child . This process
        /// repeats until the child is greater then parent.
        /// </summary>
        /// <param name="index">Index</param>
        protected override void HeapifyBottom(int index)
        {
            
            int leftChild = LeftChild(index);
            int rightChild = RightChild(index);
            int smallestChild;
            if (leftChild >= this.HeapLength)
                return;
            if (rightChild >= this.HeapLength)
                smallestChild = leftChild;
            else
                smallestChild = this.heap[leftChild].CompareTo(this.heap[rightChild]) < 0 ? leftChild : rightChild;

            if (this.heap[index].CompareTo(this.heap[smallestChild]) > 0)
            {
                Swap(smallestChild, index);
                HeapifyBottom(smallestChild);
            }
        }
    }
    /// <summary>
    /// Max Heap. Max Heap is a binary heap that follows heap property.
    /// In the max heap, the parent element must be greater then the child elemenet
    /// </summary>
    /// <typeparam name="T">Type that are comparable</typeparam>
    public class MaxHeap<T> : Heap<T> where T : IComparable
    {
        /// <summary>
        /// Create Heap with given capacity
        /// </summary>
        /// <param name="capacity">Heap Capacity</param>
        public MaxHeap(int capacity) : base(capacity) { }
        /// <summary>
        /// Create Heap with default capacity
        /// </summary>
        /// <param name="capacity">Heap Capacity</param>
        public MaxHeap() : base() { }
        /// <summary>
        /// Create Heap with enumerables
        /// </summary>
        /// <param name="collection">Enumerable</param>
        public MaxHeap(IEnumerable<T> collection) : base(collection) { }
        /// <summary>
        /// Create heap with List
        /// </summary>
        /// <param name="collection">List of items</param>
        public MaxHeap(List<T> collection) : base(collection) { }
        /// <summary>
        /// Capacity of Heap
        /// </summary>
        protected override int HeapCapacity { get; set; } = 0;
        /// <summary>
        /// Capacity of Heap
        /// </summary>
        public override int HeapLength { get; set; } = 0;
        /// <summary>
        /// Array as heap
        /// </summary>
        protected override List<T> heap { get; set; }
        /// <summary>
        /// Checks if element is in the Heap
        /// </summary>
        /// <param name="item">Element to check</param>
        /// <returns>Return true if element exist otherise false</returns>
        public override bool Contains(T item)
        {
            int root = 0;

            QueueImplementation.Queue<int> queuedIndex = new();
            if (this.HeapLength == 0)
                throw new Exception("Heap is empty");

            queuedIndex.Enqueue(root);
            while (queuedIndex.Count() > 0)
            {
                if (Contain(item, root))
                {
                    Console.WriteLine(root);
                    Console.WriteLine("Form Parent");
                    return true;
                }

                if (ChildNodeContainsItem(item, root))
                {
                    int leftChild = LeftChild(root);
                    int rightChild = RightChild(root);
                    if (Contain(item, leftChild))
                    {
                        Console.WriteLine(leftChild);
                        Console.WriteLine("Form Left Child");
                        return true;
                    }
                    queuedIndex.Enqueue(leftChild);
                    if (Contain(item, rightChild))
                    {
                        Console.WriteLine(rightChild);
                        Console.WriteLine("Form Right Child");
                        return true;
                    }
                    queuedIndex.Enqueue(rightChild);
                }
                root = queuedIndex.Dequeue();
            }

            return false;
        }
        /// <summary>
        /// Maintains the heap property.
        /// Incase of MaxHeap HeapifyTop checks if parent 
        /// element is greatr then the child. If parent 
        /// element is smaller then the child it swaps 
        /// parent with child. This process
        /// repeats until the parent is greater then child.
        /// </summary>
        /// <param name="index">Index</param>
        protected override void HeapifyTop(int index)
        {
            if (index >= HeapLength)
                return;
            int parent = GetParent(index);
            //Parent node exists
            if (parent >= 0 && parent != index)
            {
                //Parent node value is smaller than child node
                //instance follows object in sorted order returns 1
                if (this.heap[parent].CompareTo(this.heap[index]) > 0)
                {
                    Swap(parent, index);
                    HeapifyTop(parent);
                }
            }
        }
        /// <summary>
        /// Maintains the heap property.
        /// Incase of MaxHeap HeapifyBottom checks if child element is 
        /// smaller then the parent. If child element is greater
        /// then the parent it swaps parent with child. This process
        /// repeats until the child is smaller then parent.
        /// </summary>
        /// <param name="index">Index</param>
        protected override void HeapifyBottom(int index)
        {
            int leftChild = LeftChild(index);
            int rightChild = RightChild(index);
            int largestChild;
            if (leftChild >= this.HeapLength)
                return;
            if (rightChild >= this.HeapLength)
                largestChild = leftChild;
            else
                largestChild = this.heap[leftChild].CompareTo(this.heap[rightChild]) >= 0 ? leftChild : rightChild;

            if (this.heap[index].CompareTo(this.heap[largestChild]) >= 0)
            {
                Swap(largestChild, index);
                HeapifyBottom(largestChild);
            }
        }
        /// <summary>
        /// Internal method to check if item is in the given heap index
        /// </summary>
        /// <param name="item">Item to check in heap</param>
        /// <param name="index">Index of heap</param>
        /// <returns>True if the item is in the given heap index otherwise false</returns>
        private bool Contain(T item, int index)
        {
            if (this.heap[index].CompareTo(item) == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if child nodes contains the given element
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="parent">Heap index</param>
        /// <returns>Returns true if the child of given heap index can probably contain the item otherwise false</returns>
        private bool ChildNodeContainsItem(T item, int parent)
        {
            if (this.heap[parent].CompareTo(item) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    /// <summary>
    /// Base Class for Heap
    /// </summary>
    /// <typeparam name="T">Type that are comparable </typeparam>
    public abstract class Heap<T> : IHeap<T>, IEnumerable<T> where T : IComparable
    {
        /// <summary>
        /// Create Heap with default Heap Capacity
        /// </summary>
        public Heap()
        {
            this.HeapCapacity = 64;
            this.heap = new List<T>(this.HeapCapacity);
        }
        /// <summary>
        /// Create Heap with default capacity
        /// </summary>
        /// <param name="capacity">Heap Capacity</param>
        public Heap(int capacity)
        {
            this.HeapCapacity = capacity;
            this.heap = new List<T>(this.HeapCapacity);
        }
        /// <summary>
        /// Create Heap with enumerables
        /// </summary>
        /// <param name="collection">Enumerable</param>
        public Heap(IEnumerable<T> collection)
        {
            this.heap = new List<T>();
            foreach(var item in collection)
            {
                Insert(item);
            }
            this.HeapCapacity = heap.Capacity;
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Return Heap element from index</returns>
        public T this[int index]
        {
            get { return this.heap[index]; }
        }
        /// <summary>
        /// Dynamic Array As Heap
        /// </summary>
        protected abstract List<T> heap { get; set; }
        /// <summary>
        /// Heap Capacity
        /// </summary>
        protected abstract int HeapCapacity { get; set; }
        /// <summary>
        /// Heap Length
        /// </summary>
        public abstract int HeapLength { get; set; }
        /// <summary>
        /// Swap Heap Item
        /// </summary>
        /// <param name="x">Index of item</param>
        /// <param name="y">Index of item</param>
        protected virtual void Swap(int x, int y)
        {
            T temp = this.heap[x];
            this.heap[x] = this.heap[y];
            this.heap[y] = temp;
        }
        /// <summary>
        /// Left Child
        /// </summary>
        /// <param name="index">Parent Index</param>
        /// <returns>Left Child index</returns>
        public virtual int LeftChild(int index)
        {
            //2* index + 0 for 1 based heap
            //For zero based Heap
            return 2 * index + 1;
        }
        /// <summary>
        /// Right Child
        /// </summary>
        /// <param name="index">Parent Index</param>
        /// <returns>Right Child Index</returns>
        public virtual int RightChild(int index)
        {
            //2*index +1 for 1 based Heap
            //For zero based Heap
            return 2 * index + 2;
        }
        /// <summary>
        /// Parent
        /// </summary>
        /// <param name="child">Child Index</param>
        /// <returns>Parent index</returns>
        public virtual int GetParent(int child)
        {
            // child/2 for 1 based Heap
            //For 0 based Heap
            return (child - 1) / 2;
        }
        protected abstract void HeapifyTop(int index);
        protected abstract void HeapifyBottom(int index);

        /// <summary>
        /// Insert item into Heap.
        /// Heap inserts item into the right most empty node
        /// </summary>
        /// <param name="element">Item</param>
        public virtual void Insert(T element)
        {
            this.heap.Add(element);
            int temp = this.HeapLength;
            this.HeapLength++;
            HeapifyTop(temp);
        }
        /// <summary>
        /// Remove item from Heap.
        /// Heap removes the item at the root
        /// </summary>
        /// <returns>Removed Item</returns>
        public virtual T Remove()
        {
            if (this.HeapLength <= 0)
                throw new Exception("Heap is empty");
            var elementRemove = this.heap[0];
            this.heap[0] = this.heap[this.HeapLength - 1];
            this.heap[this.HeapLength - 1] = default;
            this.HeapLength--;
            HeapifyBottom(0);
            return elementRemove;
        }
        /// <summary>
        /// Peek root of Heap
        /// </summary>
        /// <returns>Root item</returns>
        public virtual T Peek()
        {
            if (HeapLength > 0)
                return heap[0];
            else
                return default;
        }
        /// <summary>
        /// Checks if item is in Heap
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>True if heap contains item otherwise false</returns>
        public abstract bool Contains(T item);
        /// <summary>
        /// Delete Heap
        /// </summary>
        public virtual void DeleteHeap()
        {
            this.heap = null;
            this.HeapLength = default;
            this.HeapCapacity = default;
        }
        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = new T[this.HeapLength];
            for (int i = 0; i < this.HeapLength; i++)
            {
                arr[i] = this.heap[i];
            }
            return arr.OfType<T>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public interface IHeap<T>
    {
        int HeapLength { get; set; }
        int LeftChild(int index);
        int RightChild(int index);
        void Insert(T element);
        T Remove();
        T Peek();
        bool Contains(T item);
        void DeleteHeap();
    }
}
