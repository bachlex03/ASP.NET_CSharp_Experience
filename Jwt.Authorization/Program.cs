using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

var securityScheme = new OpenApiSecurityScheme
{
    Name = "JWT Authentication",
    Description = "Enter JWT Bearer token **_only_**",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = JwtBearerDefaults.AuthenticationScheme, // must be lower case
    BearerFormat = "JWT",
};

var securityRequirement = new OpenApiSecurityRequirement
{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
        }
};

services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(id => id.FullName!.Replace("+", "-"));

    // Define security Schema for swagger with Bearer JWT token
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

    // Apply bearer token in header for all requests
    options.AddSecurityRequirement(securityRequirement);
});

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder?.Configuration["JwtSettings:Issuers"] ?? "default-issuers",
                ValidAudience = builder?.Configuration["JwtSettings:Audience"] ?? "default-audience",
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder?.Configuration["JwtSettings:SecretKey"] ?? "default-secret-key"))
            };
        });

services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
