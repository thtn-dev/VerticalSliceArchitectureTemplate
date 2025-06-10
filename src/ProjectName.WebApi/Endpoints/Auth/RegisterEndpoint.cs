
using MediatR;
using ErrorOr;
using FastEndpoints;
using static ProjectName.Application.Features.Auth.RegisterUser;

namespace ProjectName.WebApi.Endpoints.Auth;

public class RegisterEndpoint(ISender sender) : Endpoint<RegisterUserRequest, ErrorOr<RegisterUserResponse>>
{
    public override void Configure()
    {
        Post("/api/auth/register");
        AllowAnonymous();
    }
    
    public override Task<ErrorOr<RegisterUserResponse>> ExecuteAsync(RegisterUserRequest req, CancellationToken ct)
    {
        return sender.Send(req, ct);
    }
}