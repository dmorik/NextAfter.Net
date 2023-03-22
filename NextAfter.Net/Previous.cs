// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NextAfter.Net
{
    /// <summary>
    /// The class that allows to get the previous representable numbers in floating point arithmetic.
    /// </summary>
    public static class Previous
    {
        /// <summary>
        /// Returns the previous representable double number.
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <returns>The previous representable double number.</returns>
        public static double Double(double number)
        {
            return -Next.Double(-number);
        }
        
        /// <summary>
        /// Returns the previous representable single number.
        /// </summary>
        /// <param name="number">Single number.</param>
        /// <returns>The previous representable single number.</returns>
        public static float Single(float number)
        {
            return -Next.Single(-number);
        }
    }
}