using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services for API calls
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( // Defines a default CORS policy
        builder =>
        {
            // Allow requests from your Angular app's development server origin(s)
            builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                   .AllowAnyHeader() // Allow any headers in the request
                   .AllowAnyMethod(); // Allow HTTP methods like GET, POST, PUT, DELETE
        });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StargateContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("StarbaseApiDatabase")));

builder.Services.AddMediatR(cfg =>
{
    cfg.AddRequestPreProcessor<CreateAstronautDutyPreProcessor>();
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

// For Angular development/testing
if (app.Environment.IsDevelopment())
{
    app.UseSpa(spa =>
    {
        // Path to the Angular app
        spa.Options.SourcePath = "../StargateApp";

        if (app.Environment.IsDevelopment())
        {
            // Use Angular CLI server in development
            spa.UseAngularCliServer(npmScript: "start");
        }
    });
}

//// For Swagger UI API endpoint development/testing
//app.UseSwagger();
//app.UseSwaggerUI();

app.Run();