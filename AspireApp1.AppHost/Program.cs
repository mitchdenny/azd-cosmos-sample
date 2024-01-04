var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var cosmos = builder.AddAzureCosmosDB("mycosmos");

var apiService = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService)
    .WithReference(cosmos);

builder.Build().Run();
