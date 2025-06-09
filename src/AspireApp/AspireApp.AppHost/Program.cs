var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ProjectName_WebApi>("projectname-webapi");

builder.AddProject<Projects.ProjectName_Web>("projectname-web")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);


builder.Build().Run();
