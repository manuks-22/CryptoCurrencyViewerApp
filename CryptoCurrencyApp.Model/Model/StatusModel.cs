using Newtonsoft.Json;

namespace CryptoCurrencyApp.Model.Model
{
    public class StatusModel : IModel
    {
        /// <summary>
        /// Gets or sets the ErrorCode property.
        /// </summary>
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the ErrorMessage property.
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
