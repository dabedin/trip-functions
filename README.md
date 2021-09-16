# trip-functions

A basic example of Azure Functions adopting the isolated process in .Net 5 https://docs.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide.
* **PostTrip** class has a Function using the CosmosDBOutput, in addition to the HttpResponseData, via a multiple output binding https://docs.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide#multiple-output-bindings
* **GetTrip** class rely on CosmosDBInput to retrieve a document based on Id in the route, along the doc at https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-cosmosdb-v2-input?tabs=csharp#http-trigger-look-up-id-from-route-data-using-sqlquery
