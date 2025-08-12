# InsightMetrics API

[![.NET 8](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)
[![API Version](https://img.shields.io/badge/API%20Version-v1.0-orange.svg)](https://localhost:7006/swagger)

## 📋 Overview

InsightMetrics API is a comprehensive security analytics platform that provides key performance indicators (KPIs), alert management, compliance scoring, and device monitoring capabilities. Built with .NET 8, it serves as the backend for the Insight Metrics Platform, delivering critical security data and metrics to clients.

## 🏗️ Architecture

```
InsightMetrics.API/
├── Controllers/          # API endpoints
├── Services/            # Business logic layer
├── Repositories/        # Data access layer
├── Models/              # DTOs and response models
├── Utils/               # Helper utilities and middleware
└── Program.cs           # Application startup and configuration
```

### Tech Stack
- **Framework**: .NET 8
- **Authentication**: JWT Bearer tokens
- **Logging**: Serilog + Seq
- **Documentation**: Swagger/OpenAPI
- **Serialization**: Newtonsoft.Json (migrating to System.Text.Json)
- **Database**: Azure Cosmos DB (via ForsyteIT libraries)

## 🚀 Features

### Core Modules

#### 🔔 **Alerts Management**
- Retrieve detailed alert information for clients
- Alert summary with tuning metrics
- Top alert categories analysis
- Daily severity grouping and trends

#### 📊 **KPI Metrics**
- Mean Time to Detection (MTTD)
- Mean Time to Resolution (MTTR) 
- SLA violation tracking
- 30-day trend analysis

#### 🛡️ **Compliance Scoring**
- Task-based compliance tracking
- Onboarding requirement management
- Status-based grouping and reporting
- Deployment tracking across workloads

#### 💻 **Device Management**
- Compliant vs non-compliant device reporting
- Device health status monitoring
- Support status tracking
- Pagination support with continuation tokens

#### 🎯 **Escalation Tracking**
- Escalation timing analysis (business hours vs off-hours)
- Status breakdown reporting
- False positive tracking
- Automated vs manual escalation detection

#### 🔒 **Secure Score Monitoring**
- Latest security score retrieval
- Historical score tracking
- Microsoft Graph integration

#### 👥 **User Activity Analysis**
- Member and guest account statistics
- Active vs disabled account tracking
- Comprehensive user activity summaries

#### 🎫 **Zoho Desk Integration**
- Support ticket retrieval
- Status-based ticket summaries
- Priority-based filtering
- Last 30 days ticket analysis

#### 🏢 **Organization Management**
- Multi-tenant organization support
- Timezone management
- Display name and metadata handling

#### 🔍 **Penetration Testing**
- Test schedule management
- Last test date tracking
- Next test scheduling

## 🔧 Installation & Setup

### Prerequisites
- .NET 8 SDK
- Azure Cosmos DB access
- Seq logging server (optional)
- Visual Studio 2022 or VS Code

### Environment Variables
Create an `appsettings.json` or set environment variables:

```json
{
  "Jwt": {
    "Issuer": "your-issuer",
    "Audience": "your-audience", 
    "Key": "your-secret-key", // Move to environment variable
    "ExpiryMinutes": 60
  },
  "Seq": {
    "ServerUrl": "http://localhost:5341",
    "ApiKey": "your-seq-api-key"
  },
  "Features": {
    "EnableJwtAuth": false // Set to true for production
  }
}
```

### Running the Application

1. **Clone the repository**
```bash
git clone <repository-url>
cd InsightMetrics.API
```

2. **Restore packages**
```bash
dotnet restore
```

3. **Update configuration**
```bash
# Set JWT secret key as environment variable (REQUIRED for production)
export JWT_SECRET_KEY="your-super-secure-secret-key"
```

4. **Run the application**
```bash
dotnet run
```

5. **Access Swagger UI**
```
https://localhost:7006/swagger
```

## 📖 API Documentation

### Authentication
The API supports JWT Bearer token authentication (configurable via `Features:EnableJwtAuth`).

```bash
# Get token (development only)
POST /api/auth/authenticate
{
  "email": "user@example.com"
}

# Use token in requests
Authorization: Bearer <your-jwt-token>
```

### Core Endpoints

#### Alerts
```http
GET /api/alerts/details?clientId={guid}
GET /api/alerts/summary?clientId={guid}
```

#### KPI Metrics  
```http
GET /api/kpi/metrics?clientId={guid}
```

#### Compliance
```http
GET /api/compliance/score?clientId={guid}
```

#### Devices
```http
GET /api/devices/non-compliant?clientId={guid}&deviceType=Supported
```

#### Escalations
```http
GET /api/escalations/details?clientId={guid}
```

#### Secure Score
```http
GET /api/metrics/latest?clientId={guid}
```

#### User Activity
```http
GET /api/useractivity/summary?clientId={guid}
```

#### Zoho Tickets
```http
GET /api/zohotickets/tickets?clientId={guid}
```

#### Organizations
```http
GET /api/organization
```

#### Pen Testing
```http
GET /api/pentesting/schedule?clientId={guid}
```

## 🔒 Security Features

- **JWT Authentication**: Configurable token-based authentication
- **CORS Policy**: Cross-origin request handling
- **Input Validation**: Parameter validation across all endpoints
- **Error Handling**: Centralized error handling middleware
- **Correlation IDs**: Request tracking and tracing
- **Structured Logging**: Comprehensive logging with Serilog

## 🏃‍♂️ Performance Features

- **Response Compression**: Automatic response compression
- **Health Checks**: Built-in health monitoring at `/health`
- **Async/Await**: Full async implementation
- **Pagination**: Continuation token support for large datasets

## 🧪 Development

### Project Structure Details

#### Controllers
- **AlertsController**: Alert management endpoints
- **AuthController**: Authentication (development only)
- **ComplianceController**: Compliance scoring
- **DevicesController**: Device management
- **EscalationsController**: Escalation tracking
- **KpiController**: KPI metrics
- **MetricsController**: Secure score metrics
- **OrganizationController**: Organization management
- **PenTestingController**: Penetration testing schedules
- **UserActivityController**: User activity summaries
- **ZohoTicketsController**: Zoho Desk integration

#### Services
Business logic layer implementing core functionality:
- `IAlertsService` / `AlertsService`
- `IAuthService` / `AuthService` 
- `IComplianceService` / `ComplianceService`
- `IDeviceService` / `DeviceService`
- `IEscalationService` / `EscalationService`
- `IKpiService` / `KpiService`
- `IOrganizationService` / `OrganizationService`
- `IPenTestingService` / `PenTestingService`
- `ISecureScoreService` / `SecureScoreService`
- `IUserActivityService` / `UserActivityService`
- `IZohoDeskService` / `ZohoDeskService`

#### Repositories
Data access layer with Cosmos DB integration:
- Pattern: Interface + Implementation
- Uses ForsyteIT Cosmos API libraries
- Handles query building and data retrieval

#### Models
- **Alert**: Alert-related DTOs
- **Auth**: JWT and authentication models
- **Compliance**: Compliance scoring models
- **Device**: Device management models
- **Escalation**: Escalation tracking models
- **KpiMetric**: KPI response models
- **Organization**: Organization data models
- **PenTest**: Penetration testing models
- **Zoho**: Zoho Desk integration models

#### Utils
- **ErrorHandlingMiddleware**: Centralized error handling
- **TimezoneHelper**: Cross-platform timezone conversion
- **WorkloadHelper**: Deployment workload descriptions

### Key Dependencies

```xml
<PackageReference Include="Asp.Versioning.Mvc" Version="8.1.0" />
<PackageReference Include="ForsyteIT.CosmosAPI.Core" Version="8.0.0.30" />
<PackageReference Include="ForsyteIT.Guardian" Version="8.0.0.21" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.18" />
<PackageReference Include="Serilog.AspNetCore" Version="9.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="9.0.3" />
```

## 🔄 API Versioning

The API supports versioning through:
- URL segments: `/api/v1/alerts/details`
- Query parameters: `/api/alerts/details?version=1.0`
- Headers: `X-Version: 1.0`

## 📊 Monitoring & Logging

### Structured Logging
The application uses Serilog with enrichers for:
- Correlation IDs
- Machine names
- Thread IDs
- Environment information
- Request duration tracking

### Health Checks
Monitor application health:
```http
GET /health
```

### Seq Integration
Structured logs are sent to Seq for analysis:
- Server URL: `http://localhost:5341`
- Configurable API key
- Environment-based log levels

## 🚀 Deployment

### Environment Configuration

#### Development
- JWT authentication disabled by default
- Detailed error messages
- Swagger UI enabled
- Debug logging level

#### Production
- JWT authentication enabled
- Generic error messages
- Swagger UI configurable
- Information logging level
- HTTPS enforcement

### Docker Support
*(To be implemented)*

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["InsightMetrics.API.csproj", "."]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InsightMetrics.API.dll"]
```

## 🔧 Configuration

### JWT Configuration
```json
{
  "Jwt": {
    "Issuer": "https://your-domain.com",
    "Audience": "https://your-domain.com", 
    "Key": "env:JWT_SECRET_KEY", // Use environment variable
    "ExpiryMinutes": 60
  }
}
```

### CORS Configuration
```json
{
  "Cors": {
    "Origins": ["https://your-frontend-domain.com"],
    "Methods": ["GET", "POST", "PUT", "DELETE"],
    "Headers": ["Content-Type", "Authorization"]
  }
}
```

## 🐛 Troubleshooting

### Common Issues

1. **JWT Key Missing**
   - Ensure `JWT_SECRET_KEY` environment variable is set
   - Check appsettings.json for key configuration

2. **Cosmos DB Connection**
   - Verify ForsyteIT library configuration
   - Check connection strings and permissions

3. **CORS Issues**
   - Update allowed origins in startup configuration
   - Ensure preflight requests are handled

4. **Seq Logging**
   - Verify Seq server is running on configured port
   - Check API key configuration

## 🤝 Contributing

### Development Workflow
1. Fork the repository
2. Create a feature branch
3. Follow coding standards
4. Add unit tests
5. Submit pull request

### Code Standards
- Use async/await patterns
- Follow SOLID principles
- Implement proper error handling
- Add XML documentation
- Use dependency injection

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🔮 Future Roadmap

### Planned Improvements
- [ ] Migration to System.Text.Json
- [ ] Implementation of MediatR pattern
- [ ] Clean Architecture restructuring
- [ ] Comprehensive unit testing
- [ ] Performance optimizations
- [ ] Docker containerization
- [ ] CI/CD pipeline setup
- [ ] API rate limiting
- [ ] Response caching
- [ ] Database migrations

### Security Enhancements
- [ ] Move JWT secrets to Azure Key Vault
- [ ] Implement API key authentication
- [ ] Add request/response encryption
- [ ] Enhance CORS policies
- [ ] Add SQL injection prevention
- [ ] Implement audit logging

## 📞 Support

For support and questions:
- **Email**: contact@forsyteit.com
- **Documentation**: [API Documentation](https://localhost:7006/swagger)
- **Issues**: [GitHub Issues](https://github.com/your-org/insightmetrics-api/issues)

---

**Built with ❤️ by the ForsyteIT Team**