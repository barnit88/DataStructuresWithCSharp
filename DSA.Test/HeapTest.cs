using System;
using Xunit;
using LinkedList;
using System.Collections.Generic;
using Xunit.Extensions;
using BinaryHeap;

namespace DSA.Test
{
    /// <summary>
    /// Unit Testing
    /// 
    /// Fact is doesnt allows to pass data
    /// 
    /// Theory is used to pass multiple sets of data into 
    /// the test method using InlineData decorator
    /// </summary>
    public class HeapTest
    {
        MinHeap<int> minHeap;

      
        [Theory]
        [InlineData(new int[] { 1, 2, 10, 2, 3, 4, 5, 200, 22, 14, 123, 12 })]
        [InlineData(new int[] { 2, 3, 4, 5, 200, 22, 14, 123, 12 })]
        [InlineData(new int[] { 10, 2, 5, 200, 22, 14, 123, 12 })]
        public void HeapLength_CheckHeapLength(int[] arr)
        {
            minHeap = new MinHeap<int>(arr);
            Assert.NotEqual(0,minHeap.HeapLength);
            Assert.Equal(arr.Length, minHeap.HeapLength);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 10, 2, 3, 4, 5, 200, 22, 14, 123, 12 })]
        [InlineData(new int[] { 2, 3, 4, 5, 200, 22, 14, 123, 12 })]
        [InlineData(new int[] { 10, 2, 5, 200, 22, 14, 123, 12 })]
        public void Insert_CheckInsertionInHeap(int[] arr)
        {
            minHeap = new MinHeap<int>();
            foreach(var item in arr)
            {
                minHeap.Insert(item);
            }
            int root = 0;
            Func<int, int> leftChild = (root) =>
             {
                 return root * 2 + 1;
             };
            Func<int, int> rightChild = (root) =>
            {
                return root * 2 + 2;
            };
            while (root < arr.Length)
            {
                if(minHeap.HeapLength > leftChild(root))
                    Assert.True(minHeap[root] <= minHeap[leftChild(root)]);
                if(minHeap.HeapLength > rightChild(root))
                    Assert.True(minHeap[root] <= minHeap[rightChild(root)]);
                root++;
            }
        }

        [Fact]
        public void Constructor_CheckConstructorWithCapacityAsParameter()
        {
            var heap = new MinHeap<int>(2);
            Assert.Throws<Exception>(() =>
            {
                if((heap.Peek()).GetType() == typeof(int)){
                    throw new Exception("Trying out Assert.Exception");
                }
            });
            Assert.Equal(0, heap.HeapLength);
            Assert.Equal(0, heap.Peek());
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 2, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 36, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 36, 41, 5, 65, 67 })]
        public void Constructor_CheckOverloadedConstrutorAcceptionCollection(int[] arr)
        {
            minHeap = new MinHeap<int>(arr);
            Assert.Equal(arr.Length,minHeap.HeapLength);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 2, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 36, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 36, 41, 5, 65, 67 })]
        public void Contains_CheckIfContainsReturnTrue(int[] arr)
        {
            minHeap = new MinHeap<int>();
            foreach (var item in arr)
            {
                minHeap.Insert(item);
            }
            Assert.True(minHeap.Contains(arr[0]));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 2, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 36, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 36, 41, 5, 65, 67 })]
        public void Remove_CheckIfItemIsRemoved(int[] arr)
        {
            minHeap = new MinHeap<int>(arr);
            foreach(var item in arr)
            {
                Assert.Contains(minHeap.Remove(), arr);
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 2, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 3, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 36, 4, 5, 65, 67 })]
        [InlineData(new int[] { 2, 23, 36, 41, 5, 65, 67 })]
        public void Peek_CheckIfPeekIsWorkingOrNot(int[] arr)
        {
            minHeap = new MinHeap<int>(arr);
            Assert.Contains(minHeap.Peek(), arr);
            Assert.Equal(arr[0], minHeap.Peek());
            
        }



    }

}
