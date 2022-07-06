using System;

namespace CryptoCurrencyApp.TestInfrastructure.TestFixtures
{
    public static class DoubleFixture
    {
        /// <summary>
        /// Generates a random double value.
        /// </summary>
        /// <returns></returns>
        public static double GetFixture()
        {
            Random random = new();
            return random.NextDouble();
        }
    }
}
