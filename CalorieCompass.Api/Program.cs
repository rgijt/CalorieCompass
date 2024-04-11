using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new() {
        Version = "0.0.1",
        Title = "CalorieCompassApi",
        Description = "The api for the CalorieCompass.",
        Contact = new OpenApiContact() 
        {
            Name = "NulEen",
            Email = "api.support@nuleen.com",
            Url = new Uri("https://nuleen.com/contact")
        },
        Extensions = new Dictionary<string, IOpenApiExtension> 
        {
            { 
                "x-app-id", new OpenApiString("92af4431-4254-45d0-89ea-7278b8b2fc33") 
            },
            {
                "x-audience", new OpenApiString("component-internal")
            }
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddHealthChecks();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();