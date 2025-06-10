using ErrorOr;
using FastEndpoints;
using FluentValidation;
using MediatR;
using static ProjectName.Application.Features.Auth.UserLogin;

namespace ProjectName.WebApi.Endpoints.Auth;

public sealed class LoginEndpoint(ISender sender) : Endpoint<LoginRequest,
    ErrorOr<LoginResponse>>
{
    public override void Configure()
    {
        Post("/api/auth/login");
        AllowAnonymous();
    }

    public override Task<ErrorOr<LoginResponse>> ExecuteAsync(LoginRequest req, CancellationToken ct)
    {
        return sender.Send(req, ct);
    }
}

// public class LoginRequestValidator : Validator<LoginRequest>
// {
//     public LoginRequestValidator()
//     {
//         RuleFor(r => r.Email)
//             .NotEmpty()
//             .EmailAddress();
//
//         RuleFor(r => r.Password)
//             .NotEmpty();
//     }
// }