using Newtonsoft.Json;
using System;

namespace CryptoCurrencyApp.Model.Model
{
    public class ExchangeRateModel : IModel, IEquatable<ExchangeRateModel>
    {
        /// <summary>
        /// Gets or sets the Result property.
        /// </summary>
        [JsonProperty("result")]
        public double Result { get; set; }

        /// <summary>
        /// Gets or sets the Query property.
        /// </summary>
        [JsonProperty("query")]
        public ExchangeQuery Query { get; set; }

        public bool Equals(ExchangeRateModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Result == other.Result && Query == other.Query;
        }
    }
}
