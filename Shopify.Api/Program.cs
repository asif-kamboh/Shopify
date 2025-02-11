using ScientificBit.Shopify.Auth;
using ScientificBit.Shopify.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Shopify Support
builder.Services.AddShopify(opts =>
{
    opts.Configuration = builder.Configuration.GetSection("Shopify");
    opts.MultipassSecret = ""; // TODO: Read from ENV
    opts.StoreDomain = "https://www.scientificbit.com"; // Your store website
    opts.AddSalesChannelTokens("sb", "shopify-admin-token", "shopify-storefront-token", "shopify-api-secret");
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
app.UseAuthorization();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
}