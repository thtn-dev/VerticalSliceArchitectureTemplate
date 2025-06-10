# 🏗️ Vertical Slice Architecture Template

> A production-ready ASP.NET Core template for .NET 9, built with Vertical Slice Architecture pattern and enhanced with modern development tools.

[![.NET](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://github.com/thtn-dev/VerticalSliceArchitectureTemplate/workflows/CI/badge.svg)](https://github.com/thtn-dev/VerticalSliceArchitectureTemplate/actions)

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Architecture](#-architecture)
- [Tech Stack](#-tech-stack)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Usage](#-usage)
- [API Endpoints](#-api-endpoints)
- [Configuration](#-configuration)
- [Testing](#-testing)
- [Deployment](#-deployment)
- [Contributing](#-contributing)
- [License](#-license)

## 🚀 Overview

The **Vertical Slice Architecture Template** is an ASP.NET Core template designed around the Vertical Slice Architecture pattern, organizing code by features rather than traditional layers. This template provides a clean, scalable, and maintainable architecture for modern web applications.

### What is Vertical Slice Architecture?

Vertical Slice Architecture organizes code into "vertical slices" - each feature contains all the necessary logic from API endpoint to database access within a single folder. This approach offers:

- **Reduced coupling** between components
- **Increased cohesion** within features
- **Easy feature addition/removal**
- **Independent parallel development**
- **Simplified testing**

## ✨ Features

- 🎯 **Vertical Slice Architecture** - Feature-based organization
- 🚀 **FastEndpoints** - High-performance minimal APIs
- 📨 **MediatR** - CQRS pattern and request/response handling
- ✅ **FluentValidation** - Powerful and flexible validation
- 🗄️ **Entity Framework Core** - Modern ORM
- 🔐 **ASP.NET Core Identity** - Authentication & Authorization
- 🌟 **.NET Aspire** - Cloud-native development
- 📝 **Swagger/OpenAPI** - API documentation
- 🧪 **Unit & Integration Tests** - Comprehensive testing
- 🐳 **Docker Support** - Containerization ready
- 📊 **Logging & Monitoring** - Production-ready observability

## 🏛️ Architecture

```
┌─────────────────────────────────────────┐
│                Frontend                 │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│              API Layer                  │
│  ┌─────────────────────────────────────┐│
│  │         FastEndpoints               ││
│  └─────────────────────────────────────┘│
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│           Feature Slices                │
│  ┌─────────────────────────────────────┐│
│  │  Feature A  │  Feature B  │ ...     ││
│  │  ├─Request  │  ├─Request  │         ││
│  │  ├─Handler  │  ├─Handler  │         ││
│  │  ├─Validator│  ├─Validator│         ││
│  │  └─Endpoint │  └─Endpoint │         ││
│  └─────────────────────────────────────┘│
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│          Infrastructure                 │
│  ┌─────────────────────────────────────┐│
│  │  EF Core │ Identity │ External APIs ││
│  └─────────────────────────────────────┘│
└─────────────────────────────────────────┘
```

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| [.NET](https://dotnet.microsoft.com/) | 9.0 | Runtime framework |
| [ASP.NET Core](https://docs.microsoft.com/aspnet/core/) | 9.0 | Web framework |
| [FastEndpoints](https://fast-endpoints.com/) | Latest | Minimal API endpoints |
| [MediatR](https://github.com/jbogard/MediatR) | Latest | CQRS & Mediator pattern |
| [FluentValidation](https://fluentvalidation.net/) | Latest | Request validation |
| [Entity Framework Core](https://docs.microsoft.com/ef/) | 9.0 | ORM |
| [ASP.NET Core Identity](https://docs.microsoft.com/aspnet/core/security/authentication/identity) | 9.0 | Authentication & Authorization |
| [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/) | Latest | Cloud-native development |

## 📦 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server) or [PostgreSQL](https://www.postgresql.org/)
- [Docker](https://www.docker.com/) (optional)

### Option 1: Using the Template (Recommended)

```bash
# Install the template
dotnet new install VerticalSliceArchitectureTemplate

# Create a new project
dotnet new vsa -n MyProject -o ./MyProject

# Navigate to the project directory
cd MyProject
```

### Option 2: Clone Repository

```bash
# Clone the repository
git clone https://github.com/thtn-dev/VerticalSliceArchitectureTemplate.git

# Navigate to the directory
cd VerticalSliceArchitectureTemplate

# Restore packages
dotnet restore

# Update database
dotnet ef database update

# Run the application
dotnet run
```

### Option 3: Docker

```bash
# Build and run with Docker Compose
docker-compose up -d
```

## 📁 Project Structure

```
src/
├── MyProject.Api/                    # API Layer
│   ├── Program.cs                    # Application entry point
│   ├── appsettings.json             # Configuration
│   └── Extensions/                   # Service extensions
├── MyProject.Core/                   # Core business logic
│   ├── Features/                     # Vertical slices
│   │   ├── Users/                   # User management feature
│   │   │   ├── CreateUser/          # Create user slice
│   │   │   │   ├── CreateUserRequest.cs
│   │   │   │   ├── CreateUserHandler.cs
│   │   │   │   ├── CreateUserValidator.cs
│   │   │   │   └── CreateUserEndpoint.cs
│   │   │   ├── GetUser/             # Get user slice
│   │   │   └── UpdateUser/          # Update user slice
│   │   └── Products/                # Product feature
│   ├── Entities/                    # Domain entities
│   ├── Common/                      # Shared components
│   │   ├── Behaviors/               # MediatR behaviors
│   │   ├── Exceptions/              # Custom exceptions
│   │   └── Interfaces/              # Contracts
├── MyProject.Infrastructure/         # Infrastructure layer
│   ├── Data/                        # EF Core context
│   ├── Identity/                    # Identity configuration
│   └── Services/                    # External services
└── tests/
    ├── MyProject.UnitTests/         # Unit tests
    └── MyProject.IntegrationTests/  # Integration tests
```

## 🎯 Usage

### Creating a New Feature

1. **Create feature folder**: `src/MyProject.Core/Features/Products/`

2. **Create Request DTO**:
```csharp
public class CreateProductRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}

public class CreateProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

3. **Create Validator**:
```csharp
public class CreateProductValidator : Validator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
            
        RuleFor(x => x.Price)
            .GreaterThan(0);
    }
}
```

4. **Create Handler**:
```csharp
public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly ApplicationDbContext _context;

    public CreateProductHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateProductResponse
        {
            Id = product.Id,
            Name = product.Name
        };
    }
}
```

5. **Create Endpoint**:
```csharp
public class CreateProductEndpoint : Endpoint<CreateProductRequest, CreateProductResponse>
{
    public override void Configure()
    {
        Post("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        var result = await Mediator.Send(req, ct);
        await SendOkAsync(result, ct);
    }
}
```

### Authentication & Authorization

The template includes built-in ASP.NET Core Identity integration:

```csharp
// Registration
public class RegisterEndpoint : Endpoint<RegisterRequest, RegisterResponse>
{
    public override void Configure()
    {
        Post("/api/auth/register");
        AllowAnonymous();
    }
}

// Login
public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    public override void Configure()
    {
        Post("/api/auth/login");
        AllowAnonymous();
    }
}

// Secured endpoint
public class SecureEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/secure");
        Roles("Admin", "User"); // Require roles
    }
}
```

## 🔌 API Endpoints

| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| POST | `/api/auth/register` | User registration | ❌ |
| POST | `/api/auth/login` | User login | ❌ |
| GET | `/api/users` | Get all users | ✅ |
| GET | `/api/users/{id}` | Get user by ID | ✅ |
| POST | `/api/users` | Create new user | ✅ |
| PUT | `/api/users/{id}` | Update user | ✅ |
| DELETE | `/api/users/{id}` | Delete user | ✅ |

Access Swagger UI at: `https://localhost:5001/swagger`

## ⚙️ Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyProjectDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  },
  "Jwt": {
    "Key": "YourSuperSecretKey",
    "Issuer": "MyProject",
    "Audience": "MyProjectUsers",
    "ExpireMinutes": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### Environment Variables

```bash
# Development
ASPNETCORE_ENVIRONMENT=Development
ConnectionStrings__DefaultConnection="YourConnectionString"

# Production
ASPNETCORE_ENVIRONMENT=Production
Jwt__Key="YourProductionSecretKey"
```

## 🧪 Testing

### Running Tests

```bash
# Run all tests
dotnet test

# Run unit tests
dotnet test tests/MyProject.UnitTests/

# Run integration tests
dotnet test tests/MyProject.IntegrationTests/

# Test with coverage
dotnet test --collect:"XPlat Code Coverage"
```

### Unit Test Example

```csharp
public class CreateUserHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ShouldCreateUser()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var handler = new CreateUserHandler(context);
        var request = new CreateUserRequest 
        { 
            Email = "test@example.com",
            Name = "Test User"
        };

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Email.Should().Be("test@example.com");
    }
}
```

### Integration Test Example

```csharp
public class UsersEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public UsersEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetUsers_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/api/users");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
```

## 🚀 Deployment

### Docker

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/MyProject.Api/MyProject.Api.csproj", "src/MyProject.Api/"]
RUN dotnet restore "src/MyProject.Api/MyProject.Api.csproj"
COPY . .
WORKDIR "/src/src/MyProject.Api"
RUN dotnet build "MyProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProject.Api.dll"]
```

### Cloud Deployment

The template supports deployment to:
- **Azure App Service**
- **AWS Elastic Beanstalk**
- **Google Cloud Run**
- **Kubernetes**

### Azure App Service

```bash
# Create resource group
az group create --name myResourceGroup --location "East US"

# Create App Service plan
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --sku B1 --is-linux

# Create web app
az webapp create --resource-group myResourceGroup --plan myAppServicePlan --name myUniqueAppName --runtime "DOTNETCORE|9.0"

# Deploy
az webapp deployment source config --name myUniqueAppName --resource-group myResourceGroup --repo-url https://github.com/thtn-dev/VerticalSliceArchitectureTemplate --branch main
```

## 📊 Monitoring & Observability

The template includes built-in support for:

- **Structured Logging** with Serilog
- **Health Checks** for database and external services
- **Metrics** with Application Insights
- **Distributed Tracing** with OpenTelemetry

### Health Checks

```csharp
// Access health checks
GET /health

// Detailed health check
GET /health/detailed
```

### Logging Configuration

```json
{
  "Serilog": {
    "Using": ["Serilog.Sinks.Console", "Serilog.Sinks.File"],
    "MinimumLevel": "Information",
    "WriteTo": [
      { "Name": "Console" },
      { 
        "Name": "File", 
        "Args": { "path": "logs/app-.log", "rollingInterval": "Day" } 
      }
    ]
  }
}
```

## 🔒 Security

### Security Features

- **JWT Authentication** with configurable expiration
- **Role-based Authorization**
- **CORS Configuration**
- **Rate Limiting**
- **Input Validation** with FluentValidation
- **SQL Injection Protection** with EF Core
- **XSS Protection** with built-in filters

### Security Best Practices

```csharp
// JWT Configuration
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });
```

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Development Guidelines

- Follow the existing code style and conventions
- Write unit tests for new features
- Update documentation as needed
- Ensure backward compatibility
- Run tests before submitting PR

### Code Style

- Use meaningful variable and method names
- Follow C# naming conventions
- Keep methods small and focused
- Use dependency injection
- Handle exceptions appropriately

## 📚 Documentation

### Additional Resources

- [Vertical Slice Architecture Blog Post](https://jimmybogard.com/vertical-slice-architecture/)
- [FastEndpoints Documentation](https://fast-endpoints.com/)
- [MediatR Documentation](https://github.com/jbogard/MediatR/wiki)
- [FluentValidation Documentation](https://docs.fluentvalidation.net/)

### API Documentation

The API is fully documented with OpenAPI/Swagger. After running the application, visit:
- Swagger UI: `https://localhost:5001/swagger`
- ReDoc: `https://localhost:5001/redoc`

## 🐛 Troubleshooting

### Common Issues

**Database Connection Issues**
```bash
# Update connection string in appsettings.json
# Run database migrations
dotnet ef database update
```

**Authentication Issues**
```bash
# Check JWT configuration
# Verify token expiration
# Ensure proper role assignments
```

**Build Issues**
```bash
# Clean and rebuild
dotnet clean
dotnet build
```

## 📄 License

This project is licensed under the [MIT License](LICENSE) - see the LICENSE file for details.

## 🙏 Acknowledgments

- [Jimmy Bogard](https://github.com/jbogard) - MediatR and Vertical Slice Architecture concepts
- [FastEndpoints Team](https://github.com/FastEndpoints/FastEndpoints) - FastEndpoints library
- [Jeremy Skinner](https://github.com/JeremySkinner) - FluentValidation
- [Microsoft](https://github.com/dotnet) - .NET Platform and EF Core
- [.NET Community](https://dotnet.foundation/) - Continuous inspiration and support

## 📞 Contact

- **Author**: [thtn-dev](https://github.com/thtn-dev)
- **Email**: your.email@example.com
- **Project**: [VerticalSliceArchitectureTemplate](https://github.com/thtn-dev/VerticalSliceArchitectureTemplate)
- **Issues**: [GitHub Issues](https://github.com/thtn-dev/VerticalSliceArchitectureTemplate/issues)

---

⭐ If this template helped you, please consider giving it a star on GitHub!
