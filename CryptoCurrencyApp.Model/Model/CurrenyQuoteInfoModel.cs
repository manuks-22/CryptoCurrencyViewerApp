using Newtonsoft.Json;

namespace CryptoCurrencyApp.Model.Model
{
    public class CurrenyQuoteInfoModel
    {
        /// <summary>
        /// Gets or sets the Price property.
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
