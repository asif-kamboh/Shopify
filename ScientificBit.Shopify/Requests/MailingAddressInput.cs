namespace ScientificBit.Shopify.Requests;

public class MailingAddressInput
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Address1 { get; set; } = string.Empty;

    public string? Address2 { get; set; }

    public string? Phone { get; set; }

    public string? City { get; set; }

    public string? ProvinceCode { get; set; }

    public string? Company { get; set; }

    public string? CountryCode { get; set; }

    public string? Zip { get; set; }
}