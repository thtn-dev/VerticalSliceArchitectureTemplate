using System.Security.Claims;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectName.Application.Core.Interfaces;
using ProjectName.Database.Entities;

namespace ProjectName.Application.Features.Auth;

public static class UserLogin
{
    public sealed record LoginRequest : IRequest<ErrorOr<LoginResponse>>
    {
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }

    public sealed record LoginResponse(
        string Token
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

    public sealed class LoginUserHandler(
        IJwtService jwtService,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
        : IRequestHandler<LoginRequest, ErrorOr<LoginResponse>>
    {
        public async Task<ErrorOr<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            
            if (user is null)
            {
                return Error.Validation(
                    code: "LoginUser",
                    description: "Invalid email or password.");
            }
            
            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return Error.Validation(
                    code: "LoginUser",
                    description: "Invalid email or password.");
            }
            var claims = await userManager.GetClaimsAsync(user);
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email ?? string.Empty));
            var token = await jwtService.GenerateJwtTokenAsync(claims);
            
            return new LoginResponse(token)
            {
                Token = token
            };
        }
    }
}
