using System;

namespace CryptoCurrencyApp.TestInfrastructure.TestFixtures
{
    public static class DateTimeFixture
    {
        /// <summary>
        /// Generates a random date time.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetFixture()
        {
            Random random = new();
            var randomDays = random.Next(1, 5);
            var randomMins = random.Next(100, 500);

            var date = DateTime.Now.AddDays(-randomDays);
            date = date.AddMinutes(-randomMins);
            return date;
        }
    }
}
