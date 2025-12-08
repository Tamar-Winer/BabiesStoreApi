using BabiesStoreApi.Data;
using BabiesStoreApi.Interfaces;
using BabiesStoreApi.Repo;
using BabiesStoreApi.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductService>();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddDbContext<StoreContextDB>(options => 
options.UseSqlServer("Server=localhost;Database=BabiesStoreDb;Trusted_Connection=True;TrustServerCertificate=True;"
));

builder.Services.AddScoped<IProductRepository, ProductRepos>();
builder.Services.AddScoped<ProductRepos>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<EmailNotificationService>();
builder.Services.AddScoped<SmsNotificationService>();
builder.Services.AddScoped<Func<string, INotificationService>>(serviceProvider => key =>
{
    return key switch
    {
        "email" => serviceProvider.GetRequiredService<EmailNotificationService>(),
        "sms" => serviceProvider.GetRequiredService<SmsNotificationService>(),
        _ => throw new Exception("Invalid notification type")
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
