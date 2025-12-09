using ScientificBit.Shopify.Auth;
using ScientificBit.Shopify.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Shopify Support
builder.Services.AddShopify(opts =>
{
    var adminApiToken = Environment.GetEnvironmentVariable("SHOPIFY_ADMIN_API_TOKEN") ?? "shopify-admin-token";
    var storefrontApiToken = Environment.GetEnvironmentVariable("SHOPIFY_STORE_API_TOKEN") ?? "shopify-storefront-token";
    var shopifyApiSecret = Environment.GetEnvironmentVariable("SHOPIFY_API_SECRET") ?? "shopify-api-secret";

    opts.Configuration = builder.Configuration.GetSection("Shopify");
    opts.MultipassSecret = ""; // TODO: Read from ENV
    opts.StoreDomain = "https://www.scientificbit.com"; // Your store website
    opts.AddDefaultSalesChannelTokens(adminApiToken, storefrontApiToken, shopifyApiSecret);
});

// Add Shopify Webhook Authentication
builder.Services.AddAuthentication()
    .AddShopifyWebhookAuthentication(ShopifyAuthSchemes.ShopifyWebhookAuth);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.UseAuthentication();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
}