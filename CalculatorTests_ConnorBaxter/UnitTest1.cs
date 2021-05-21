using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CalculatorTests_ConnorBaxter
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestSampleDataAddition()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "3";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("1 2 + p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestSampleDataSubtraction()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "-7";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("0 7 - p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestSampleDataMultiplication()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "12";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("3 4 * p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestSampleDataDivision()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "5";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("15 3 / p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestSampleDataThreeNumbers1()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "28";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("10 2 9 * + p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestSampleDataThreeNumbers2()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "29";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("10 2 * 9 + p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestSampleDataInvalidToken()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "Negative numbers are not allowed";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("3 -9 + p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestSampleDataDivisonByZero()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "Attempting to divide by zero";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("2 0 / p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestSampleDataEmptyStack()
        {
            using (var sw = new StringWriter())
            {
                const string expected = "Stack empty";
                Console.SetOut(sw);
                new Calculator_CB.Calculator().DecodeInputString("1 + p");
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }
    }
}
