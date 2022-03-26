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
    public class StackTest
    {
        StackImplementation.Stack<int> stack = new();

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 54, 56 })]
        [InlineData(new int[] { 2,32,1323,1,123,1,31,31,678})]
        [InlineData(new int[] { 1,34,46,456,4,623,4,243,232,12,342})]
        public void Push_CheckIfItemIsPushedIntoStack(int[] items)
        {
            foreach (var item in items)
            {
                stack.Push(item);
            }
            Assert.Equal(items.Length, stack.Count());
            Assert.Equal(items[items.Length-1], stack.Peek());
            Assert.Contains(stack.Pop(),items);
        }
        
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 54, 56 })]
        [InlineData(new int[] { 123,34,43,756,5567,34,23})]
        [InlineData(new int[] { 234,423,4,3,523,3,234,42,213})]
        public void Pop_CheckIfItemIsPopedOutOfStack(int[] items)
        {
            foreach (var item in items)
            {
                stack.Push(item);
            }
            Assert.Equal(items.Length, stack.Count());
            Assert.Equal(items[items.Length - 1], stack.Peek());
            Assert.Contains(stack.Peek(), items);
            Assert.Equal(items[items.Length-1], stack.Peek());
            for(int i = items.Length-1; i >= 0; i--)
            {
                Assert.IsType<int>(stack.Peek());
                Assert.Equal(items[i],stack.Pop());

            }
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 54, 56 })]
        [InlineData(new int[] { 12,31,21,31,231,1,3,34534})]
        [InlineData(new int[] { 12,235,34,334523,234,23,2 })]
        public void Clear_CheckIfStackIsCleared(int[] items)
        {
            foreach(var item in items)
            {
                stack.Push(item);
            }
            Assert.Equal(items.Length, stack.Count());
            stack.Clear();
            Assert.NotEqual(items.Length, stack.Count());
            Assert.Equal(0, stack.Count());
            Assert.Equal(0, stack.Peek());
        }




     

    }

}
