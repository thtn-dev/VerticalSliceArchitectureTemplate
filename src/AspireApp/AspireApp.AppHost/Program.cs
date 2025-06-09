var builder = DistributedApplication.CreateBuilder(args);
var apiService = builder.AddProject<Projects.ProjectName_WebApi>("webapi");
var app = builder.Build();
app.Run();
