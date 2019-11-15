using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Tests
{
    [TestClass()]
    public class NumbersTestsMS
    {
        [TestMethod]
        public void Insert_Number_Test_15_15_0_0_Extend_15()
        {
            int extend = Numbers.InsertNumber(15, 15, 0, 0);
            Assert.AreEqual(extend, 15);
        }
        [TestMethod]
        public void Insert_Number_Test_8_15_0_0_Extend_9()
        {
            int extend = Numbers.InsertNumber(8, 15, 0, 0);
            Assert.AreEqual(extend, 9);
        }
        [TestMethod]
        public void Insert_Number_Test_8_15_3_8_Extend_120()
        {
            int extend = Numbers.InsertNumber(8, 15, 3, 8);
            Assert.AreEqual(extend, 120);
        }
        [TestMethod]
        public void Insert_Number_Test_568_53_8_11_Extend_1336()
        {
            int extend = Numbers.InsertNumber(568, 53, 8, 11);
            Assert.AreEqual(extend, 1336);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Exception_Test()
        {
            Numbers.InsertNumber(568, 53, 80, 11);
        }
    }
}