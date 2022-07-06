using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoCurrencyApp.Model.Model
{
    public class CryptoCurrencyDataModel : IModel
    {
        /// <summary>
        /// Gets or sets the Id property.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Name property.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Symbol property.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the Quote property.
        /// </summary>
        [JsonProperty("quote")]
        public Dictionary<string, CurrenyQuoteInfoModel> Quote { get; set; }
    }


}
