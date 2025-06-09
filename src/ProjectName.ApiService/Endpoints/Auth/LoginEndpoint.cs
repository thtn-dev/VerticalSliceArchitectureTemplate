using ErrorOr;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using static ProjectName.Application.Features.Auth.UserLogin;

namespace ProjectName.WebApi.Endpoints.Auth;

public sealed class LoginEndpoint : Endpoint<LoginRequest,
    Results<Ok<LoginResponse>, NotFound, ProblemDetails>>
{
    private readonly ISender sender;

    public LoginEndpoint(ISender sender)
    {
        this.sender = sender;
    }

    public override void Configure()
    {
        Post("/api/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var result = await sender.Send(req, ct);

        if (result.IsError)
        {
            if (result.FirstError.Type == ErrorType.Validation)
            {
                await SendErrorsAsync(cancellation: ct);
                return;
            }
            if (result.FirstError.Type == ErrorType.NotFound)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            await SendForbiddenAsync(ct);
            return;
        }

        var response = result.Value;
        await SendResultAsync(TypedResults.Ok(response));
    }
}
