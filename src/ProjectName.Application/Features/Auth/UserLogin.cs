using ErrorOr;
using FastEndpoints;
using FluentValidation;
using MediatR;

namespace ProjectName.Application.Features.Auth;

public static class UserLogin
{
    public sealed record LoginRequest : IRequest<ErrorOr<LoginResponse>>
    {
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }

    public sealed record LoginResponse(
        string Token,
        DateTimeOffset ExpiresAt
    );

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("email is required")
                .EmailAddress().WithMessage("invalid email format");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }

    public sealed class LoginUserHandler : IRequestHandler<LoginRequest, ErrorOr<LoginResponse>>
    {
        public Task<ErrorOr<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            if (request.Email == "trungnam")
            {
                return Task.FromResult<ErrorOr<LoginResponse>>(
                    Error.Validation("Login", "Invalid email or password"));
            }
            var fakeResult = new LoginResponse("fake_token", DateTime.UtcNow);
            return Task.FromResult<ErrorOr<LoginResponse>>(fakeResult);
        }
    }
}
