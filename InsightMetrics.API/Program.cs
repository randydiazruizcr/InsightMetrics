using Asp.Versioning;
using ForsyteIT.KeyVault;
using InsightMetrics.API.Models.Auth;
using InsightMetrics.API.Repositories.Implementations;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Implementations;
using InsightMetrics.API.Services.Interfaces;
using InsightMetrics.API.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

if (builder.Configuration["SetProd"] == "S")
{
    ForsyteSetEnvironment.AssignEnvironment(ForsyteEnvironment.Prod);
}

#region Logging Configuration: Serilog + Seq

string serverUrl = builder.Configuration["Seq:ServerUrl"] ?? string.Empty;
string apiKey = builder.Configuration["Seq:ApiKey"] ?? string.Empty;
bool enableJwtAuth = builder.Configuration.GetValue<bool>("Features:EnableJwtAuth");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .Enrich.WithCorrelationId()
    .Enrich.WithProperty("Environment", builder.Configuration["Environment"])
    .Enrich.WithProperty("Application", "insightmetrics.api")
    .Enrich.WithMachineName()
    .Enrich.WithThreadId()
    .WriteTo.Seq(serverUrl, apiKey: apiKey)
    .CreateLogger();

builder.Host.UseSerilog();

#endregion

#region Service Configuration

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddResponseCompression();

// JWT Settings
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("Jwt").Bind(jwtSettings);

if (string.IsNullOrWhiteSpace(jwtSettings.Key))
    throw new InvalidOperationException("JWT Key is missing in configuration.");

builder.Services.AddSingleton(jwtSettings);

if (enableJwtAuth)
{
    // JWT Authentication
    builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            ClockSkew = TimeSpan.Zero,
        };
    });

    builder.Services.AddAuthorization();
}
    

// CORS policy
const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy
            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InsightMetrics API",
        Version = "v1",
        Description = "API for Insight Metrics Platform",
        Contact = new OpenApiContact
        {
            Name = "ForsyteIT Team",
            Email = "contact@forsyteit.com"
        }
    });
    if (enableJwtAuth)
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Description = @"JWT Authorization header using the Bearer scheme.  
                        Enter 'Bearer' [space] and then your token.  
                        Example: 'Bearer abcdef12345'",
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    }    
});

builder.Services.AddSwaggerGenNewtonsoftSupport(); // Needed for Newtonsoft compatibility

// Health checks
builder.Services.AddHealthChecks();

// Dependency Injection
builder.Services.AddScoped<IKpiService, KpiService>();
builder.Services.AddScoped<IAlertsService, AlertsService>();
builder.Services.AddScoped<IEscalationService, EscalationService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IComplianceService, ComplianceService>();
builder.Services.AddScoped<IPenTestingService, PenTestingService>();
builder.Services.AddScoped<IUserActivityService, UserActivityService>();
builder.Services.AddScoped<IZohoDeskService, ZohoDeskService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<ISecureScoreService, SecureScoreService>();

builder.Services.AddScoped<IKpiRepository, KpiRepository>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<IEscalationRepository, EscalationRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IComplianceRepository, ComplianceRepository>();
builder.Services.AddScoped<IPenTestingRepository, PenTestingRepository>();
builder.Services.AddScoped<IUserActivityRepository, UserActivityRepository>();
builder.Services.AddScoped<IZohoDeskRepository, ZohoDeskRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<ISecureScoreRepository, SecureScoreRepository>();

#endregion

var app = builder.Build();

#region Middleware Pipeline

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

if (enableJwtAuth)
{
    app.UseAuthentication();
    app.UseAuthorization();
}

app.MapControllers();
app.MapHealthChecks("/health");

#endregion

await app.RunAsync();
