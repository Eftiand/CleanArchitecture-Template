using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyVaultIfConfigured(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder);

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.InitialiseDatabaseAsync();
}
else
{
    app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseExceptionHandler();
app.MapEndpoints();
app.Map("/", () => Results.Redirect("/swagger"));
app.Run();

public abstract partial class Program;
