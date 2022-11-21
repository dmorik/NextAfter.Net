using System;

namespace NextAfter.Net.Tests
{
    internal class Base
    {
        protected const int RepeatCount = (int)1e6;
        protected static readonly Random Random = new Random(DateTime.Now.Millisecond);
    }
}