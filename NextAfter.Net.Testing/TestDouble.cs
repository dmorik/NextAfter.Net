// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;

namespace NextAfter.Net.Testing
{
    [TestFixture]
    internal sealed class TestDouble : TestBase
    {
        [Test]
        public void Next_Zero()
        {
            var result = Next.Double(0.0);

            Assert.IsTrue(result.Equals(double.Epsilon));
        }

        [Test]
        public void Prev_Zero()
        {
            var result = Previous.Double(0.0);

            Assert.IsTrue(result.Equals(-double.Epsilon));
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

            Assert.IsTrue(result.Equals(0.0));
        }

        [Test]
        public void Next_MaxDouble()
        {
            var result = Next.Double(double.MaxValue);

            Assert.IsTrue(result.Equals(double.PositiveInfinity));
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

            Assert.IsTrue(result.Equals(double.NegativeInfinity));
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

            Assert.IsTrue(result.Equals(0.0));
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
            var number = GenerateDoubleNumber();
            var result = Previous.Double(number);

            Assert.IsTrue(result < number);
            
            var middle = (number + result) * 0.5;
            
            Assert.IsTrue(middle.Equals(number) || middle.Equals(result));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Next_CommonNumbers()
        {
            var number = GenerateDoubleNumber();
            var result = Next.Double(number);

            Assert.IsTrue(result > number);

            var middle = (number + result) * 0.5;
            
            Assert.IsTrue(middle.Equals(number) || middle.Equals(result));
        }
    }
}