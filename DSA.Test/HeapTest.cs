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

    }

}
