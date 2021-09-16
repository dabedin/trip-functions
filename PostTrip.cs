using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class PostTrip
    {
        [Function("PostTripMultipleOutput")]
        public static MultiResponse Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("PostTripMultipleOutput");
            logger.LogInformation("C# HTTP trigger function processed a request.");
            
            string randomId = System.Guid.NewGuid().ToString();

            Trip trip = new Trip
            {
                id = randomId,
                content = string.Format("arbitrary data of trip {0}", randomId)
            };

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync<Trip>(trip);

            // Return a response to both HTTP trigger and Azure Cosmos DB output binding.
            return new MultiResponse()
            {
                Document = trip, 
                HttpResponse = response
            };
        }
    }
}
