using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoCurrencyApp.Model.Model
{
    public class CoinMarketCapCryptoCurrencyItemData : IModel
    {
        public CoinMarketCapCryptoCurrencyItemData()
        {
            DataList = new Dictionary<string, CryptoCurrencyDataModel>();
        }

        /// <summary>
        /// Gets or sets the Status property.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public StatusModel Status { get; set; }

        /// <summary>
        /// Gets or sets the DataList property.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public Dictionary<string, CryptoCurrencyDataModel> DataList { get; set; }

    }
}
