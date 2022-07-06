using System;

namespace CryptoCurrencyApp.TestInfrastructure.TestFixtures
{
    public static class IntFixture
    {
        /// <summary>
        /// Generates a random int value.
        /// </summary>
        /// <returns></returns>
        public static int GetFixture()
        {
            Random random = new();
            return random.Next();
        }
    }
}
