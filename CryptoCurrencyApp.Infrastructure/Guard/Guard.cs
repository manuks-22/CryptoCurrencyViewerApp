using System;

namespace CryptoCurrencyApp.Infrastructure.Guard
{
    public static class Guard
    {
        /// <summary>
        /// Guards against a null exception and raises "<see cref="ArgumentNullException"/>".
        /// </summary>
        /// <param name="property">The property to be verified</param>
        /// <param name="propertyName">The name of the property</param>
        public static void AgainstNull(object property, string propertyName)
        { 
            if (property == null)
            {
                throw new ArgumentNullException(@$"The property {propertyName} is null.");
            }
        }

        /// <summary>
        /// Guards against a null or empty and raises "<see cref="ArgumentException"/>".
        /// </summary>
        /// <param name="property">The property to be verified</param>
        /// <param name="propertyName">The name of the property</param>
        public static void AgainstNullOrEmpty(object property, string propertyName)
        {
            AgainstNull(property, propertyName);

            if (property is string value && string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@$"The property {propertyName} is empty.");
            }
        } 
    }
}
