using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    // https://docs.microsoft.com/en-us/azure/azure-functions/functions-add-output-binding-cosmos-db-vs-code?tabs=isolated-process&pivots=programming-language-csharp#add-code-that-uses-the-output-binding
    public class MultiResponse
    {
        [CosmosDBOutput("tripservice", "trips",
            ConnectionStringSetting = "CosmosDbConnectionString", CreateIfNotExists = true)]
        public Trip Document { get; set; }
        public HttpResponseData HttpResponse { get; set; }
    }
    public class Trip {
        public string id { get; set; }
        public string content { get; set; }
    }
}