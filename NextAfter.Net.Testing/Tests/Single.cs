using System;
using NUnit.Framework;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace NextAfter.Net.Tests
{
    [TestFixture]
    internal class Single : Base
    {
        [Test]
        public void Next_Zero()
        {
            var result = Next.Single(0.0f);

            Assert.IsTrue(result == float.Epsilon);
        }

        [Test]
        public void Prev_Zero()
        {
            var result = Previous.Single(0.0f);

            Assert.IsTrue(result == -float.Epsilon);
        }

        [Test]
        public void Prev_MinusEpsilon()
        {
            var result = Previous.Single(-float.Epsilon);

            Assert.IsTrue(result < -float.Epsilon);
        }
        
        [Test]
        public void Prev_Epsilon()
        {
            var result = Previous.Single(float.Epsilon);

            Assert.IsTrue(result == 0.0);
        }

        [Test]
        public void Next_MaxFloat()
        {
            var result = Next.Single(float.MaxValue);

            Assert.IsTrue(result == float.PositiveInfinity);
        }
        
        [Test]
        public void Next_MinFloat()
        {
            var result = Next.Single(float.MinValue);

            Assert.IsTrue(result > float.MinValue);
        }

        [Test]
        public void Prev_MinFloat()
        {
            var result = Previous.Single(float.MinValue);

            Assert.IsTrue(result == float.NegativeInfinity);
        }
        
        [Test]
        public void Prev_MaxFloat()
        {
            var result = Previous.Single(float.MaxValue);

            Assert.IsTrue(result < float.MaxValue);
        }

        [Test]
        public void Prev_Nan()
        {
            var result = Previous.Single(float.NaN);

            Assert.IsTrue(float.IsNaN(result));
        }

        [Test]
        public void Next_Nan()
        {
            var result = Next.Single(float.NaN);

            Assert.IsTrue(float.IsNaN(result));
        }

        [Test]
        public void Prev_PositiveInf()
        {
            var result = Previous.Single(float.PositiveInfinity);

            Assert.IsTrue(float.IsPositiveInfinity(result));
        }

        [Test]
        public void Next_PositiveInf()
        {
            var result = Next.Single(float.PositiveInfinity);

            Assert.IsTrue(float.IsPositiveInfinity(result));
        }

        [Test]
        public void Prev_NegativeInf()
        {
            var result = Previous.Single(float.NegativeInfinity);

            Assert.IsTrue(float.IsNegativeInfinity(result));
        }

        [Test]
        public void Next_NegativeInf()
        {
            var result = Next.Single(float.NegativeInfinity);

            Assert.IsTrue(float.IsNegativeInfinity(result));
        }

        [Test]
        public void Next_MinusEpsilon()
        {
            var result = Next.Single(-float.Epsilon);

            Assert.IsTrue(result == 0.0);
        }
        
        [Test]
        public void Next_Epsilon()
        {
            var result = Next.Single(float.Epsilon);

            Assert.IsTrue(result > float.Epsilon);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Prev_CommonNumbers()
        {
            var number = GenerateNumber();
            var result = Previous.Single(number);

            Assert.IsTrue(result < number);
            
            var middle = (number + result) * 0.5f;
            
            Assert.IsTrue(middle == number || middle == result);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Next_CommonNumbers()
        {
            var number = GenerateNumber();
            var result = Next.Single(number);

            Assert.IsTrue(result > number);

            var middle = (number + result) * 0.5f;
            
            Assert.IsTrue(middle == number || middle == result);
        }
        
        private static readonly float _minLogValue = (float)(Math.Log(float.Epsilon) + 1.0);
        private static readonly float _maxLogValue = (float)(Math.Log(float.MaxValue) - 1.0);
        
        private static float GenerateNumber()
        {
            var numberSign = Random.NextDouble() >= 0.5 ? 1.0 : -1.0;
            var randomNumber = Random.NextDouble();
            var numberLogValue = _minLogValue * (1.0 - randomNumber) + _maxLogValue * randomNumber;
            var numberAbsValue = Math.Exp(numberLogValue);
            
            return (float)(numberSign * numberAbsValue);
        }
    }
}