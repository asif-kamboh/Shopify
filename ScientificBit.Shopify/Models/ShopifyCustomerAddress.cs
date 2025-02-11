namespace ScientificBit.Shopify.Models;

public class ShopifyCustomerAddress : ShopifyBaseModel
{
    public string? FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; } = string.Empty;

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address1 { get; set; } = string.Empty;

    public string? Address2 { get; set; } = string.Empty;

    public IList<string>? Formatted { get; set; }

    public string? FormattedArea { get; set; }

    public string? City { get; set; } = string.Empty;

    public string? Province { get; set; }

    public string? ProvinceCode { get; set; }

    public string? TimeZone { get; set; }

    public bool? CoordinatesValidated { get; set; }

    public string? Company { get; set; }

    private double? _latitude;

    private double? _longitude;

    public double? Latitude {
        get
        {
            if (_latitude != null || string.IsNullOrEmpty(Company)) return _latitude;
            if (double.TryParse(Company.Split(",")[0], out var lat))
            {
                _latitude = lat;
            }
            return _latitude;
        }
        set => _latitude = value;
    }

    public double? Longitude {
        get
        {
            if (_longitude != null || string.IsNullOrEmpty(Company)) return _longitude;
            var tokens = Company.Split(",");
            if (tokens.Length > 1 && double.TryParse(tokens[1], out var lon))
            {
                _longitude = lon;
            }
            return _longitude;
        }
        set => _longitude = value;
    }

    public string? Country { get; set; } = string.Empty;

    public string? CountryCode => CountryCodeV2;

    public string? CountryCodeV2 { get; set; }
}