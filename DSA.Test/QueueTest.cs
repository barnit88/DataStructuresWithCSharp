using System;
using Xunit;
using LinkedList;
using System.Collections.Generic;
using Xunit.Extensions;

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
    public class QueueTest
    {
        QueueImplementation.Queue<int> queue= new();

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 54, 56 })]
        [InlineData(new int[] { 2,32,1323,1,123,1,31,31,678})]
        [InlineData(new int[] { 1,34,46,456,4,623,4,243,232,12,342})]
        public void Enqueue_CheckIfItemIsPushedIntoQueue(int[] items)
        {
            foreach (var item in items)
            {
                queue.Enqueue(item);
            }
            Assert.Equal(items.Length, queue.Count());
            Assert.Equal(items[items.Length-1], queue.Peek());
            Assert.Equal(items[0],queue.Dequeue());
        }
        
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 54, 56 })]
        [InlineData(new int[] { 123,34,43,756,5567,34,23})]
        [InlineData(new int[] { 234,423,4,3,523,3,234,42,213})]
        public void Dequeue_CheckIfItemIsPopedOutOfQueueu(int[] items)
        {
            foreach (var item in items)
            {
                queue.Enqueue(item);
            }
            Assert.Equal(items.Length, queue.Count());
            Assert.Equal(items[items.Length - 1], queue.Peek());
            Assert.Contains(queue.Peek(), items);
            Assert.Equal(items[items.Length-1], queue.Peek());
            for(int i = 0; i >= items.Length - 1; i++)
            {
                Assert.IsType<int>(queue.Peek());
                Assert.Equal(items[i],queue.Dequeue());

            }
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 54, 56 })]
        [InlineData(new int[] { 12, 31, 21, 31, 231, 1, 3, 34534 })]
        [InlineData(new int[] { 12, 235, 34, 334523, 234, 23, 2 })]
        public void Clear_CheckIfQueueIsCleared(int[] items)
        {
            foreach (var item in items)
            {
                queue.Enqueue(item);
            }
            Assert.Equal(items.Length, queue.Count());
            queue.Clear();
            Assert.NotEqual(items.Length, queue.Count());
            Assert.Equal(0, queue.Count());
            Assert.Equal(0, queue.Peek());
        }
    }
}
