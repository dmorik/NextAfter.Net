// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace NextAfter.Net.Testing
{
    [Parallelizable(ParallelScope.All)]
    internal class TestBase
    {
        protected const int RepeatCount = (int)1e6;
        
        private static readonly Random Random = Random.Shared;

        protected static double GenerateDoubleNumber()
        {
            var bytes = new byte[sizeof(double)];

            Random.NextBytes(bytes);

            var result = BitConverter.ToDouble(bytes);

            while (!double.IsNormal(result)
                // for middle calculating
                || result < double.MinValue * 0.5
                // for middle calculating
                || result > double.MaxValue * 0.5)
            {
                Random.NextBytes(bytes);

                result = BitConverter.ToDouble(bytes);
            }

            return result;
        }

        protected static float GenerateSingleNumber()
        {
            var bytes = new byte[sizeof(float)];

            Random.NextBytes(bytes);

            var result = BitConverter.ToSingle(bytes);

            while (!float.IsNormal(result)
                // for middle calculating
                || result < float.MinValue * 0.5f
                // for middle calculating
                || result > float.MaxValue * 0.5f)
            {
                Random.NextBytes(bytes);

                result = BitConverter.ToSingle(bytes);
            }

            return result;
        }
    }
}