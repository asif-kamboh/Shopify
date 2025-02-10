namespace Service.Shopify.Models;

public class WeightInput
{
    public string Unit { get; set; } = "KILOGRAMS"; // GRAMS, KILOGRAMS, OUNCES, POUNDS

    public double Value { get; set; }
}