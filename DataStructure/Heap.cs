using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QueueImplementation;

namespace BinaryHeap
{
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
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> : Heap<T> where T : IComparable
    {
        /// <summary>
        /// Returns Capacity of Heap
        /// </summary>
        public override int HeapCapacity { get; set; } = 0;
        /// <summary>
        /// Returns actual length of Heap
        /// </summary>
        public override int HeapLength { get; set; } = 0;
        protected override T[] heap { get; set; }
        
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


                //queuedIndex.Enqueue(leftChild);
                //if (Contain(item, rightChild))
                //    return true;
                //queuedIndex.Enqueue(rightChild);
                //root = queuedIndex.Dequeue();
                //if (root > this.HeapLength)
                //    return false;
            }
        
            return false;
        }
        private bool Contain(T item,int index)
        {
            if(this.heap[index].CompareTo(item)== 0)
            {
                return true;
            }
            return false;
        }
        private bool ChildNodeContainsItem(T item, int parent)
        {
            if(this.heap[parent].CompareTo(item) < 0){
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        protected override void Heapify(int index)
        {
            if (index > HeapLength)
                return;
            int parent = GetParent(index);
            //Parent node exists
            if (parent >= 0 && parent != index)
            {
                //Parent node value is greated than child node
                //1 preceeded 2 returns -1
                if (this.heap[parent].CompareTo(this.heap[index]) > 0)
                {
                    Swap(parent, index);
                    Heapify(parent);
                }
            }
            int leftChild = LeftChild(index);
            int rightChild = RightChild(index);
            int smallestChild;
            if (leftChild >= this.HeapLength)
                return;
            if (rightChild >= this.HeapLength)
                smallestChild = leftChild;
            else
                smallestChild = this.heap[leftChild].CompareTo(this.heap[rightChild]) >= 0 ? leftChild : rightChild;
            
            if(this.heap[index].CompareTo(this.heap[smallestChild]) >= 0)
            {
                Swap(smallestChild, index);
                Heapify(smallestChild);
            }
        }
    }
    public class MaxHeap<T> : Heap<T> where T : IComparable
    {
        public override int HeapCapacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int HeapLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        protected override T[] heap { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        protected override void Heapify(int index)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Heap<T> : IHeap<T> , IEnumerable<T>
    {
        public Heap()
        {
            this.HeapCapacity = 64;
            this.heap = new T[this.HeapCapacity];
        }
        public abstract int HeapCapacity { get; set; }
        public abstract int HeapLength { get;  set; }
        protected abstract T[] heap { get; set; }
        public virtual void Swap(int x, int y)
        {
            T temp = this.heap[x];
            this.heap[x] = this.heap[y];
            this.heap[y] = temp;
        }
        public virtual int LeftChild(int index)
        {
            //2* index + 0 for 1 based heap
            //For zero based Heap
            return 2 *index +1;
        }
        /// <summary>
        /// Get the Right Child
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual int RightChild(int index)
        {
            //2*index +1 for 1 based Heap
            //For zero based Heap
            return 2 * index + 2;
        }
        public virtual int GetParent(int child)
        {
            // child/2 for 1 based Heap
            //For 0 based Heap
            return (child - 1) / 2;
        }
        protected abstract void Heapify(int index);
        public virtual void Insert(T element)
        {
            this.heap[this.HeapLength] = element;
            int temp = this.HeapLength;
            this.HeapLength++;
            Heapify(temp);
        }

        public virtual T Remove()
        {
            if (this.HeapLength <= 0)
                throw new Exception("Heap is empty");
            var elementRemove = this.heap[0];
            this.heap[0] = this.heap[this.HeapLength - 1];
            this.heap[this.HeapLength - 1] = default;
            this.HeapLength--;
            Heapify(this.HeapLength);
            return elementRemove;
        }

        public virtual T Peek()
        {
            if (HeapLength > 0)
                return heap[0];
            else
                return default;
        }
        public abstract bool Contains(T item);
        public virtual void DeleteHeap()
        {
            this.heap = null;
            this.HeapLength = default;
            this.HeapCapacity = default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = new T[this.HeapLength];
            for(int i = 0; i < this.HeapLength; i++)
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
        void Swap(int x, int y);
        int LeftChild(int index);
        int RightChild(int index);
        void Insert(T element);
        T Remove();
        T Peek();
        bool Contains(T item);
        void DeleteHeap();
    }
}
