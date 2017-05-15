using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public class CalcTest
    {
        
        [TestMethod]
        public void TestSum()
        {
            var test = new Calc();

            var result = test.Sum(1, 2);
            var result1 = test.Execute("sum", new object[] {10.1, 24.5});
            Assert.AreEqual(result,3);
            Assert.AreEqual(result1,10.1+24.5);
        }

        [TestMethod]
        public void TestDivide()
        {
            var test = new Calc();
            var result = test.Execute("divide", new object[] {111.12, 33.44});
            var result1 = test.Execute("divide", new object[] {12, 0});
            Assert.AreEqual(result1,Double.NaN);
            Assert.AreEqual(result, 111.12/ 33.44);
        }

        [TestMethod]
        public void TestDif()
        {
            var test = new Calc();
            var result = test.Execute("dif", new object[] { 12.5, 11.44 });
            var result1 = test.Execute("dif", new object[] { 11, 3 });
            Assert.AreEqual(result,12.5-11.44);
            Assert.AreEqual(result1,(double) 11 - 3);
        }

        [TestMethod]
        public void TestExponent()
        {
            var test = new Calc();
            var result = test.Execute("exponent", new object[] { 11, 3 });

            Assert.AreEqual(result,Math.Pow(11,3));
        }

        [TestMethod]
        public void TestMult()
        {
            var test = new Calc();
            var result = test.Execute("mult", new object[] { 11, 3 });

            Assert.AreEqual(result, (double)11 * 3);
        }
    }
}

