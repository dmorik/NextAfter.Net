// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NextAfter.Net.Testing
{
    [TestFixture]
    internal sealed class TestDouble : TestBase
    {
        [Test]
        public void Next_Zero()
        {
            var result = Next.Double(0.0);

            Assert.That(result, Is.EqualTo(double.Epsilon));
        }

        [Test]
        public void Prev_Zero()
        {
            var result = Previous.Double(0.0);

            Assert.That(result, Is.EqualTo(-double.Epsilon));
        }

        [Test]
        public void Prev_MinusEpsilon()
        {
            var result = Previous.Double(-double.Epsilon);

            Assert.That(result, Is.LessThan(-double.Epsilon));
        }
        
        [Test]
        public void Prev_PlusEpsilon()
        {
            var result = Previous.Double(double.Epsilon);

            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void Next_MaxDouble()
        {
            var result = Next.Double(double.MaxValue);

            Assert.That(result, Is.EqualTo(double.PositiveInfinity));
        }
        
        [Test]
        public void Next_MinDouble()
        {
            var result = Next.Double(double.MinValue);

            Assert.That(result, Is.GreaterThan(double.MinValue));
        }

        [Test]
        public void Prev_MinDouble()
        {
            var result = Previous.Double(double.MinValue);

            Assert.That(result, Is.EqualTo(double.NegativeInfinity));
        }
        
        [Test]
        public void Prev_MaxDouble()
        {
            var result = Previous.Double(double.MaxValue);

            Assert.That(result, Is.LessThan(double.MaxValue));
        }

        [Test]
        public void Prev_Nan()
        {
            var result = Previous.Double(double.NaN);

            Assert.That(double.IsNaN(result), Is.True);
        }

        [Test]
        public void Next_Nan()
        {
            var result = Next.Double(double.NaN);

            Assert.That(double.IsNaN(result), Is.True);
        }

        [Test]
        public void Prev_PositiveInf()
        {
            var result = Previous.Double(double.PositiveInfinity);

            Assert.That(double.IsPositiveInfinity(result), Is.True);
        }

        [Test]
        public void Next_PositiveInf()
        {
            var result = Next.Double(double.PositiveInfinity);

            Assert.That(double.IsPositiveInfinity(result), Is.True);
        }

        [Test]
        public void Prev_NegativeInf()
        {
            var result = Previous.Double(double.NegativeInfinity);

            Assert.That(double.IsNegativeInfinity(result), Is.True);
        }

        [Test]
        public void Next_NegativeInf()
        {
            var result = Next.Double(double.NegativeInfinity);

            Assert.That(double.IsNegativeInfinity(result), Is.True);
        }

        [Test]
        public void Next_MinusEpsilon()
        {
            var result = Next.Double(-double.Epsilon);

            Assert.That(result, Is.EqualTo(0.0));
        }
        
        [Test]
        public void Next_PlusEpsilon()
        {
            var result = Next.Double(double.Epsilon);

            Assert.That(result, Is.GreaterThan(double.Epsilon));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Prev_CommonNumbers()
        {
            var number = GenerateDoubleNumber();
            var result = Previous.Double(number);

            Assert.That(result, Is.LessThan(number));
            
            var middle = (number + result) * 0.5;
            
            Assert.That(middle.Equals(number) || middle.Equals(result), Is.True);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Next_CommonNumbers()
        {
            var number = GenerateDoubleNumber();
            var result = Next.Double(number);

            Assert.That(result, Is.GreaterThan(number));

            var middle = (number + result) * 0.5;
            
            Assert.That(middle.Equals(number) || middle.Equals(result), Is.True);
        }
    }
}