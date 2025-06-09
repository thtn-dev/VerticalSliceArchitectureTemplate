var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ProjectName_WebApi>("apiservice");

builder.AddProject<Projects.ProjectName_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
