using Newtonsoft.Json;
using System;

namespace CryptoCurrencyApp.Model.Model
{
    public class ExchangeQuery : IModel, IEquatable<ExchangeQuery>
    {
        /// <summary>
        /// Gets or sets the Amount property.
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the FromCurrency property.
        /// </summary>
        [JsonProperty("from")]
        public string FromCurrency { get; set; }

        /// <summary>
        /// Gets or sets the ToCurrency property.
        /// </summary>
        [JsonProperty("to")]
        public string ToCurrency { get; set; }

        public bool Equals(ExchangeQuery other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && FromCurrency == other.FromCurrency && ToCurrency == other.ToCurrency;
        }
    }
}
