using System;
using System.Linq;

namespace CryptoCurrencyApp.TestInfrastructure.TestFixtures
{
    public static class StringFixture
    {
        /// <summary>
        /// Generates a random string value.
        /// </summary>
        /// <returns></returns>
        public static string GetFixture()
        {
            Random random = new();
            var randomLength = random.Next(5, 25);

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, randomLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
