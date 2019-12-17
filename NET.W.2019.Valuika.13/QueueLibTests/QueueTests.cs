using NUnit.Framework;
using QueueLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test()]
        public void AddTest()
        {
            var queue = new Queue<int>();
            queue.Add(5);
            Assert.AreEqual(5,queue.Get());
        }

        [Test()]
        public void RemoveTest()
        {
            var queue = new Queue<int>();
            queue.Add(5);
            queue.Add(3);

            Assert.AreEqual(5, queue.Get());
            Assert.AreEqual(3, queue.Get());
        }
    }
}