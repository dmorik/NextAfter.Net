﻿using System;

namespace NextAfter.Net
{
    public static class Next
    {
        /// <summary>
        /// Returns the next representable double number.
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <returns>The next representable double number.</returns>
        public static double Double(double number)
        {
            if (double.IsNaN(number) || double.IsInfinity(number))
                return number;

            if (number == 0.0)
                return double.Epsilon;

            var result = number >= 0.0
                ? BitConverter.Int64BitsToDouble(BitConverter.DoubleToInt64Bits(number) + 1)
                : -BitConverter.Int64BitsToDouble(BitConverter.DoubleToInt64Bits(-number) - 1);

            return result;
        }
        
        /// <summary>
        /// Returns the next representable single number.
        /// </summary>
        /// <param name="number">Single number.</param>
        /// <returns>The next representable single number.</returns>
        public static float Single(float number)
        {
            if (float.IsNaN(number) || float.IsInfinity(number))
                return number;

            if (number == 0.0)
                return float.Epsilon;

            var result = number >= 0.0
                ? Int32BitsToSingle(SingleToInt32Bits(number) + 1)
                : -Int32BitsToSingle(SingleToInt32Bits(-number) - 1);

            return result;
        }

        private static int SingleToInt32Bits(float number)
        {
            return BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
        }

        private static float Int32BitsToSingle(int number)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(number), 0);
        }
    }
}
