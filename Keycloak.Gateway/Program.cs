using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddReverseProxy()
                .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.ConfigureHttpClientDefaults(http => http.AddStandardResilienceHandler());

services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddKeycloakWebApi(builder.Configuration);

services
    .AddAuthorization()
    .AddKeycloakAuthorization()
    .AddAuthorizationServer(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapReverseProxy();
app.MapControllers();

app.Run();
