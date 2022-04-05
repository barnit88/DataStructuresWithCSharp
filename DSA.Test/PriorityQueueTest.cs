using QueueImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace DSA.Test
{
    public class PriorityQueueTest
    {
        

        [Theory]
        [MemberData(nameof(Data))]
        [MemberData(nameof(Data1))]
        public void Enqueue_CheckEnqueue(Dictionary<int, string> data)
        {

            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
            foreach(var item in data)
            {
                priorityQueue.Enqueue(item.Key, item.Value);
            }
            Assert.Equal(data.Count, priorityQueue.Size);
        }

        [Theory]
        [MemberData(nameof(Data))]
        [MemberData(nameof(Data1))]
        public void Dequeue_CheckDequeue(Dictionary<int, string> data)
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
            foreach (var item in data)
            {
                priorityQueue.Enqueue(item.Key, item.Value);
            }
            var sortedData = data.OrderBy(x => x.Key);
            foreach(var sItem in sortedData)
            {
                Assert.Equal(sItem.Value, priorityQueue.Dequeue());
            }
        }
        public static IEnumerable<object[]> Data =>
             new List<object[]>
             {
                    new object[] { new Dictionary<int, string>() {
                        { 7, "Barnit Basnet" },
                        { 1, "Ram Karki" },
                        { 3, "Hari Shrestha" },
                        { 4, "Ramesh Kartik" },
                        { 2, "Henry Ford" },
                        { 5, "Gold D Roger" },
                        { 90, "Robert Khadka" },
                    }
                  }
             };
        public static IEnumerable<object[]> Data1 =>
             new List<object[]>
             {
                     new object[]{   new Dictionary<int, string>() {
                        { 112, "Barnit Basnet" },
                        { 1, "Ram Karki" },
                        { 23, "Hari Shrestha" },
                        { 3, "Ramesh Kartik" },
                        { 12, "Henry Ford" },
                        { 22, "Gold D Roger" },
                        { 341, "Robert Khadka" },
                    }
                    }
             };
    }
}
