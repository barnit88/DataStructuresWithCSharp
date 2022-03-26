using System;
using Xunit;
using LinkedList;
using System.Collections.Generic;
using Xunit.Extensions;
using DataStructure;

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
    public class DoublyLinkedListTest
    {
        //Intializing Class
        DoublyLinkedList<int> doublyIntegerList = new();
        DoublyLinkedList<string> doublyStringList = new();

        [Fact]
        public void IsEmpty_SizeIsZero_IntegerInput()
        {
            int actual = doublyIntegerList.GetSize();
            int expected = 0;
            Assert.Equal(expected, actual);
            Assert.Throws<Exception>(() => doublyIntegerList.PeekFirst());
            Assert.Throws<Exception>(() => doublyIntegerList.PeekLast());
        }

        [Fact]
        public void AddFirst_AddSingleElement()
        {
            int item = 1;
            doublyIntegerList.AddFirst(item);
            if (doublyIntegerList.GetSize() == 1)
            {
                Assert.Equal(item, doublyIntegerList.PeekFirst());
                Assert.Equal(item, doublyIntegerList.PeekLast());
            }
            else
            {
                Assert.Equal(item, doublyIntegerList.PeekFirst());
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void AddFirst_AddMultipleElementAtFirst(int[] integerArray)
        {
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddFirst(value);
            }
            var expectedSize = integerArray.Length;
            var actualSize = doublyIntegerList.GetSize();
            Assert.Equal(expectedSize, actualSize);
            Assert.False(doublyIntegerList.IsEmpty());
            Assert.Equal(doublyIntegerList.PeekFirst(), integerArray[integerArray.Length - 1]);
            Assert.Equal(doublyIntegerList.PeekLast(), integerArray[0]);
            int index = integerArray.Length - 1;
            foreach (int value in doublyIntegerList)
            {
                Assert.Equal(value, integerArray[index]);
                index--;
            }
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void AddLast_AddMultipleElementAtLast(int[] integerArray)
        {
            
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddLast(value);
            }
            var expectedSize = integerArray.Length;
            var actualSize = doublyIntegerList.GetSize();
            Assert.Equal(expectedSize, actualSize);
            Assert.False(doublyIntegerList.IsEmpty());
            Assert.Equal(doublyIntegerList.PeekLast(), integerArray[integerArray.Length - 1]);
            Assert.Equal(doublyIntegerList.PeekFirst(), integerArray[0]);
            int index = 0;
            foreach (int value in doublyIntegerList)
            {
                Assert.Equal(value, integerArray[index]);
                index++;
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void PeekFirst_CheckFirstElementAddedUsingAddFirst(int[] integerArray)
        {
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddFirst(value);
            }
            var expectedSize = integerArray.Length;
            var actualSize = doublyIntegerList.GetSize();
            Assert.Equal(expectedSize, actualSize);
            Assert.False(doublyIntegerList.IsEmpty());
            Assert.Equal(doublyIntegerList.PeekFirst(), integerArray[integerArray.Length-1]);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void PeekFirst_CheckFirstElementAddedUsingAddLast(int[] integerArray)
        {
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddLast(value);
            }
            var expectedSize = integerArray.Length;
            var actualSize = doublyIntegerList.GetSize();
            Assert.Equal(expectedSize, actualSize);
            Assert.False(doublyIntegerList.IsEmpty());
            Assert.Equal(doublyIntegerList.PeekFirst(), integerArray[0]);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void Peeklast_CheckLastElementAddedUsingAddFirst(int[] integerArray)
        {
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddFirst(value);
            }
            var expectedSize = integerArray.Length;
            var actualSize = doublyIntegerList.GetSize();
            Assert.Equal(expectedSize, actualSize);
            Assert.False(doublyIntegerList.IsEmpty());
            Assert.Equal(doublyIntegerList.PeekLast(), integerArray[0]);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void Peeklast_CheckLastElementAddedUsingAddLast(int[] integerArray)
        {
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddLast(value);
            }
            var expectedSize = integerArray.Length;
            var actualSize = doublyIntegerList.GetSize();
            Assert.Equal(expectedSize, actualSize);
            Assert.False(doublyIntegerList.IsEmpty());
            Assert.Equal(doublyIntegerList.PeekLast(), integerArray[integerArray.Length - 1]);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void Remove_RemoveElement(int[] integerArray)
        {
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddLast(value);
            }
            Random random = new Random();
            int randomNumber = random.Next(0, integerArray.Length - 1);
            Assert.True(doublyIntegerList.Remove(integerArray[randomNumber]));
            //Assert.True(doublyIntegerList.Remove(integerArray[3]));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void RemoveFirst_RemoveElementFromHead(int[] integerArray)
        {
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddLast(value);
            }
            Assert.Equal(integerArray[0],doublyIntegerList.RemoveFirst());
            var actual = doublyIntegerList.GetSize();
            Assert.Equal(integerArray.Length, actual + 1);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 1230, 1231, 12, 31, 231, 3, 1231, 32 })]
        [InlineData(new int[] { 12, 31, 23, 23, 213, 2, 13, 12 })]
        public void Removelast_RemoveElementFromTail (int[] integerArray)
        {
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddLast(value);
            }
            Assert.Equal(integerArray[integerArray.Length-1], doublyIntegerList.RemoveLast());
            var actual = doublyIntegerList.GetSize();
            Assert.Equal(integerArray.Length, actual + 1);
        }

    }

}
