using System;
using NUnit.Framework;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace NextAfter.Net.Tests
{
    [TestFixture]
    internal class Double : Base
    {
        [Test]
        public void Next_Zero()
        {
            var result = Next.Double(0.0);

            Assert.IsTrue(result == double.Epsilon);
        }

        [Test]
        public void Prev_Zero()
        {
            var result = Previous.Double(0.0);

            Assert.IsTrue(result == -double.Epsilon);
        }

        [Test]
        public void Prev_MinusEpsilon()
        {
            var result = Previous.Double(-double.Epsilon);

            Assert.IsTrue(result < -double.Epsilon);
        }
        
        [Test]
        public void Prev_Epsilon()
        {
            var result = Previous.Double(double.Epsilon);

            Assert.IsTrue(result == 0.0);
        }

        [Test]
        public void Next_MaxDouble()
        {
            var result = Next.Double(double.MaxValue);

            Assert.IsTrue(result == double.PositiveInfinity);
        }
        
        [Test]
        public void Next_MinDouble()
        {
            var result = Next.Double(double.MinValue);

            Assert.IsTrue(result > double.MinValue);
        }

        [Test]
        public void Prev_MinDouble()
        {
            var result = Previous.Double(double.MinValue);

            Assert.IsTrue(result == double.NegativeInfinity);
        }
        
        [Test]
        public void Prev_MaxDouble()
        {
            var result = Previous.Double(double.MaxValue);

            Assert.IsTrue(result < double.MaxValue);
        }

        [Test]
        public void Prev_Nan()
        {
            var result = Previous.Double(double.NaN);

            Assert.IsTrue(double.IsNaN(result));
        }

        [Test]
        public void Next_Nan()
        {
            var result = Next.Double(double.NaN);

            Assert.IsTrue(double.IsNaN(result));
        }

        [Test]
        public void Prev_PositiveInf()
        {
            var result = Previous.Double(double.PositiveInfinity);

            Assert.IsTrue(double.IsPositiveInfinity(result));
        }

        [Test]
        public void Next_PositiveInf()
        {
            var result = Next.Double(double.PositiveInfinity);

            Assert.IsTrue(double.IsPositiveInfinity(result));
        }

        [Test]
        public void Prev_NegativeInf()
        {
            var result = Previous.Double(double.NegativeInfinity);

            Assert.IsTrue(double.IsNegativeInfinity(result));
        }

        [Test]
        public void Next_NegativeInf()
        {
            var result = Next.Double(double.NegativeInfinity);

            Assert.IsTrue(double.IsNegativeInfinity(result));
        }

        [Test]
        public void Next_MinusEpsilon()
        {
            var result = Next.Double(-double.Epsilon);

            Assert.IsTrue(result == 0.0);
        }
        
        [Test]
        public void Next_Epsilon()
        {
            var result = Next.Double(double.Epsilon);

            Assert.IsTrue(result > double.Epsilon);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Prev_CommonNumbers()
        {
            var number = GenerateNumber();
            var result = Previous.Double(number);

            Assert.IsTrue(result < number);
            
            var middle = (number + result) * 0.5;
            
            Assert.IsTrue(middle == number || middle == result);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Next_CommonNumbers()
        {
            var number = GenerateNumber();
            var result = Next.Double(number);

            Assert.IsTrue(result > number);

            var middle = (number + result) * 0.5;
            
            Assert.IsTrue(middle == number || middle == result);
        }

        private static readonly double _minLogValue = Math.Log(double.Epsilon) + 1.0;
        private static readonly double _maxLogValue = Math.Log(double.MaxValue) - 1.0;
        
        private static double GenerateNumber()
        {
            var numberSign = Random.NextDouble() >= 0.5 ? 1.0 : -1.0;
            var randomNumber = Random.NextDouble();
            var numberLogValue = _minLogValue * (1.0 - randomNumber) + _maxLogValue * randomNumber;
            var numberAbsValue = Math.Exp(numberLogValue);
            
            return numberSign * numberAbsValue;
        }
    }
}