namespace Service.Shopify.Requests;

public class MetafieldUpdateRequest
{
    public MetafieldUpdateModel? Metafield { get; set; }
}

public class MetafieldUpdateModel
{
    public long MetafieldId { get; set; }

    public string? Value { get; set; }

    public string? Type { get; set; }
}