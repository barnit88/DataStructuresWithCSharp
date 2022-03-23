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
    /// Fact is used to check single set of data 
    /// 
    /// Theory is used to pass multiple sets of data into 
    /// the test method using InlineData decorator
    /// </summary>
    public class LinkedListTest
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
        public void AddFirst_AddMultipleElement(int[] integerArray)
        {
            var x = nameof(data);
            foreach (int value in integerArray)
            {
                doublyIntegerList.AddFirst(value);
            }
        }
        //public static IEnumerable<object[]> person => new List<Person>(){new Person() { firstName = "barnit", lastName = "basnet" }};
        
        //[Theory]
        //[MemberData(nameof(person),null)]
        //public void AddFirsts_AddMultipleElement(Person person)
        //{
        //    var x = nameof(data);
        //    foreach (int value in integerArray)
        //    {
        //        doublyIntegerList.AddFirst(value);
        //    }
        //}
        //[Fact]
        //public void Test1()
        //{
        //    Assert.Equal(5, 5);
        //    Assert.NotEqual(5, 5);
        //}

        //[Theory]
        //[InlineData(1,2)]
        //public void Test2(int x , int y)
        //{
        //    Assert.Equal(5, 5);
        //    Assert.NotEqual(5, 5);
        //}


        //public void Test3(int x, int y)
        //{
        //    Assert.Equal(5, 5);
        //    Assert.NotEqual(5, 5);
        //}
    }

}
