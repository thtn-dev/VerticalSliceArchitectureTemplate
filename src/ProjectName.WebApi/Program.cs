using ErrorOr;
using FastEndpoints;
using FastEndpoints.Swagger;
using ProjectName.WebApi.Extensions;
using ProjectName.WebApi.Processor;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
// Add services to the container.
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapDefaultEndpoints();

app.UseFastEndpoints(
        c =>
        {
            c.Errors.UseProblemDetails();
            c.Endpoints.Configurator =
                ep =>
                {
                    if (!ep.ResDtoType.IsAssignableTo(typeof(IErrorOr))) return;
                    ep.DontAutoSendResponse();
                    ep.PostProcessor<ResultResponseSender>(Order.After);
                    ep.Description(
                        b => b.ClearDefaultProduces()
                            .Produces(200, ep.ResDtoType.GetGenericArguments()[0])
                            .ProducesProblemDetails());
                };
        })
    .UseSwaggerGen();

app.Run();
