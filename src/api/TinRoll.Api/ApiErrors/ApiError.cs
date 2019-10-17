using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TinRoll.Api.ApiErrors
{
    public class ApiError
    {
        //https://medium.com/@matteocontrini/consistent-error-responses-in-asp-net-core-web-apis-bb70b435d1f8
        public int StatusCode { get; private set; }

        public string StatusDescription { get; private set; }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; private set; }

        public ApiError(int statusCode, string statusDescription)
        {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

        public ApiError(int statusCode, string statusDescription, string message)
            : this(statusCode, statusDescription)
        {
            Message = message;
        }
    }
}
