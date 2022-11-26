using System;

namespace NextAfter.Net.Testing
{
    internal class TestBase
    {
        protected const int RepeatCount = (int)1e6;
        
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private static readonly double MinDoubleLogValue = Math.Log(double.Epsilon) + 1.0;
        private static readonly double MaxDoubleLogValue = Math.Log(double.MaxValue) - 1.0;
        private static readonly float MinSingleLogValue = (float)(Math.Log(float.Epsilon) + 1.0);
        private static readonly float MaxSingleLogValue = (float)(Math.Log(float.MaxValue) - 1.0);

        private static double GenerateNumberByLogInterval(double minLog, double maxLog)
        {
            var numberSign = Random.NextDouble() >= 0.5 ? 1.0 : -1.0;
            var randomNumber = Random.NextDouble();
            var numberLogValue = minLog * (1.0 - randomNumber) + maxLog * randomNumber;
            var numberAbsValue = Math.Exp(numberLogValue);

            return numberSign * numberAbsValue;
        }
        
        protected static double GenerateDoubleNumber()
        {
            return GenerateNumberByLogInterval(MinDoubleLogValue, MaxDoubleLogValue);
        }

        protected static float GenerateSingleNumber()
        {
            return (float)GenerateNumberByLogInterval(MinSingleLogValue, MaxSingleLogValue);
        }
    }
}