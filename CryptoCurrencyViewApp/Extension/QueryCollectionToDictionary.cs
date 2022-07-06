using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace CryptoCurrencyApp.Extension
{
    public static class QueryCollectionToDictionary
    {
        /// <summary>
        /// Extension method to convert <see cref="IQueryCollection"/> to Dictionary of query parameters.
        /// </summary>
        /// <param name="queryCollection">The query string collection</param>
        /// <returns></returns>
        public static Dictionary<string, string> ToParamDictionary(this IQueryCollection queryCollection)
        {
            var queryData = new Dictionary<string, string>();
            if (queryCollection != null && queryCollection.Any())
                queryCollection.ToList().ForEach(param => queryData.Add(param.Key, param.Value));
            return queryData;
        }
    }
}
