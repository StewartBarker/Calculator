using Barker.Calculator.Core;
using NUnit.Framework;

namespace Tests
{
    public class ParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanDoSimpleIntAddition()
        {
            var expression = "1+1";
            var result = Parser.Parse(expression);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CanDoSimpleIntSubtraction()
        {
            var expression = "4-1";
            var result = Parser.Parse(expression);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void CanDoSimpleIntMultiplication()
        {
            var expression = "5*5";
            var result = Parser.Parse(expression);
            Assert.AreEqual(25, result);
        }

        [Test]
        public void CanDoSimpleIntDivision()
        {
            var expression = "6/3";
            var result = Parser.Parse(expression);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CanDoSimpleFloatAddition()
        {
            var expression = "1.5+1.4";
            var result = Parser.Parse(expression);
            Assert.AreEqual(2.9, result);
        }

        [Test]
        public void CanDoSimpleFloatSubtraction()
        {
            var expression = "4.5-1.5";
            var result = Parser.Parse(expression);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void CanDoSimpleFloatMultiplication()
        {
            var expression = "5.5*5.6";
            var result = Parser.Parse(expression);
            Assert.AreEqual(30.8, result);
        }

        [Test]
        public void CanDoSimpleFloatDivision()
        {
            var expression = "6.75/3";
            var result = Parser.Parse(expression);
            Assert.AreEqual(2.25, result);
        }
    }
}