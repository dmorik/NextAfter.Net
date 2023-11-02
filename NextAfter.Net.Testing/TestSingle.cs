// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NextAfter.Net.Testing
{
    [TestFixture]
    internal sealed class TestSingle : TestBase
    {
        [Test]
        public void Next_Zero()
        {
            var result = Next.Single(0.0f);

            Assert.IsTrue(result.Equals(float.Epsilon));
        }

        [Test]
        public void Prev_Zero()
        {
            var result = Previous.Single(0.0f);

            Assert.IsTrue(result.Equals(-float.Epsilon));
        }

        [Test]
        public void Prev_MinusEpsilon()
        {
            var result = Previous.Single(-float.Epsilon);

            Assert.IsTrue(result < -float.Epsilon);
        }
        
        [Test]
        public void Prev_PlusEpsilon()
        {
            var result = Previous.Single(float.Epsilon);

            Assert.IsTrue(result.Equals(0.0f));
        }

        [Test]
        public void Next_MaxFloat()
        {
            var result = Next.Single(float.MaxValue);

            Assert.IsTrue(result.Equals(float.PositiveInfinity));
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

            Assert.IsTrue(result.Equals(float.NegativeInfinity));
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

            Assert.IsTrue(result.Equals(0.0f));
        }
        
        [Test]
        public void Next_PlusEpsilon()
        {
            var result = Next.Single(float.Epsilon);

            Assert.IsTrue(result > float.Epsilon);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Prev_CommonNumbers()
        {
            var number = GenerateSingleNumber();
            var result = Previous.Single(number);

            Assert.IsTrue(result < number);
            
            var middle = (number + result) * 0.5f;
            
            Assert.IsTrue(middle.Equals(number) || middle.Equals(result));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Next_CommonNumbers()
        {
            var number = GenerateSingleNumber();
            var result = Next.Single(number);

            Assert.IsTrue(result > number);

            var middle = (number + result) * 0.5f;
            
            Assert.IsTrue(middle.Equals(number) || middle.Equals(result));
        }
    }
}