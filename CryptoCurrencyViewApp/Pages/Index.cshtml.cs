using CryptoCurrencyApp.Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoCurrencyViewApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        [BindProperty]
        public string CryptoCurrencyToFetch { get; set; }

        public CrytoCurrencyRateDto CryptoCurrencyRates { get; set; } 

        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            ErrorMessage = string.Empty;
        }

        public async Task OnPost()
        {
            ErrorMessage = string.Empty;

            var response = await GetData($@"/CoinMarketCapCryptoCurrency");
            string responseContent;
            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                CryptoCurrencyRates = JsonConvert.DeserializeObject<CrytoCurrencyRateDto>(responseContent);

                if (CryptoCurrencyRates.Status.HasError)
                {
                    ErrorMessage = CryptoCurrencyRates.Status.ErrorMessage;
                }
            }
            else
            {
                ErrorMessage = "Error fetching data!";
            }
        }

        private async Task<HttpResponseMessage> GetData(string apiRoute)
        {
            var rootUrl = Request.Host;

            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("symbol", CryptoCurrencyToFetch);

            var apiUrl = $@"https://{rootUrl}{apiRoute}?{queryString}";
            HttpClient client = new HttpClient();

            return await client.GetAsync(apiUrl);
        }

    }
}
