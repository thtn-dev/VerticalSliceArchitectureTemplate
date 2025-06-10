using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectName.Database.Entities;

namespace ProjectName.Application.Features.Auth;

public static class RegisterUser
{
    public sealed record RegisterUserResponse(string Email);
    public sealed record RegisterUserRequest(string Email, string Password)
        : IRequest<ErrorOr<RegisterUserResponse>>;

    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
        
    }
    
    public sealed class RegisterUserHandler(
        IUserStore<ApplicationUser> userStore,
        UserManager<ApplicationUser> userManager)
        : IRequestHandler<RegisterUserRequest, ErrorOr<RegisterUserResponse>>
    {
        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!userManager.SupportsUserEmail)
                throw new NotSupportedException("The default UI requires a user store with email support.");
            return (IUserEmailStore<ApplicationUser>)userStore;
        }
        
        private static ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                                                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                    $"override the external login page in /Areas/Identity/Pages/Account/ExternalLogin.cshtml");
            }
        }

        public async Task<ErrorOr<RegisterUserResponse>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var user = CreateUser();
            var emailStore = GetEmailStore();
            await userStore.SetUserNameAsync(user, request.Email, CancellationToken.None);
            await emailStore.SetEmailAsync(user, request.Email, CancellationToken.None);
            
            var result = await userManager.CreateAsync(user, request.Password);
            
            if (!result.Succeeded)
            {
                return Error.Validation(
                    code: "RegisterUser",
                    description: string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            
            var response = new RegisterUserResponse(request.Email);
            return response;
        }
    }


}