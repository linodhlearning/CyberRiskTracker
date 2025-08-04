using Azure.Storage.Blobs;
using CyberRiskTracker.Components;
using CyberRiskTracker.Data;
using CyberRiskTracker.Repositories;
using CyberRiskTracker.Services;
using CyberRiskTracker.State;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var storageType = builder.Configuration["Storage:Type"] ?? "Sql";
bool isInMemorySQL = (storageType == "Sql");
if (isInMemorySQL)
{
    builder.Services.AddScoped<IRiskRepository, SqlRiskRepository>();
    builder.Services.AddScoped<IAssetRepository, SqlAssetRepository>();
    //use the factory  to new up the db context for diff components
    builder.Services.AddDbContextFactory<CyberRiskDbContext>(options => options.UseInMemoryDatabase("CyberRiskDb")); 
    //builder.Services.AddDbContext<CyberRiskDbContext>(options =>
    //    options.UseInMemoryDatabase("CyberRiskDb"));
}
else if (storageType == "Blob")
{
    builder.Services.AddScoped<IRiskRepository, BlobRiskRepository>();
    builder.Services.AddSingleton(new BlobServiceClient(
        builder.Configuration.GetConnectionString("CyberRiskBlobStorage")));
}
builder.Services.AddScoped<ILoginAttemptRepository, MockLoginAttemptRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<RiskService>();
builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<TestApplicationState>();
var app = builder.Build();
if (isInMemorySQL)
    app.Services.InitializeAndSeedInMemDBIfNotFound();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
 