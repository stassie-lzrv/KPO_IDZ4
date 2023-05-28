using System.Text;
using API.MiddleWare;
using Domain.Extensions;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { }
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(ConfigureOptions);
builder.Services.AddCore(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureOptions(JwtBearerOptions jwtBearerOptions)
{
    jwtBearerOptions.RequireHttpsMetadata = false;
    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = "AuthService",
        ValidateAudience = true,
        ValidAudience = "OmsServices",
        ValidateLifetime = true,
        IssuerSigningKeyResolver = (string _, SecurityToken _, string _,
            TokenValidationParameters _) => new List<SecurityKey>()
        {
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AuthOptions:JwtKey"]!))
        },
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
}