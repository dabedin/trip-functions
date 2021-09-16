using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
   

    public static class GetTrip
    { 
        [Function("GetTripFromRoute")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", 
            Route = "GetTripFromRoute/{id}")] HttpRequestData req,
            FunctionContext executionContext,
            [CosmosDBInput(
                "tripservice",
                "trips",
                ConnectionStringSetting = "CosmosDbConnectionString",
                Id = "{id}",
                PartitionKey = "{id}")] Trip trip)
        {
            var logger = executionContext.GetLogger("GetTripFromRoute");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            HttpResponseData response;

            if (trip == null)
            {
                logger.LogInformation("Trip not found");

                response = req.CreateResponse(HttpStatusCode.NotFound);
                response.WriteString("Trip not found");
            }
            else
            {
                logger.LogInformation($"Found Trip {trip.id}, content={trip.content}");
                
                response = req.CreateResponse(HttpStatusCode.OK);
                response.WriteAsJsonAsync<Trip>(trip);
            }

            return response;
        }

    }
}
