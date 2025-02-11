namespace ScientificBit.Shopify.Requests;

public class CustomerUpdateRequest
{
    public CustomerUpdateModel? Customer { get; set; }
}

public class CustomerUpdateModel
{
    public string? FirstName { get; set; } = string.Empty;
    
    public string? LastName { get; set; } = string.Empty;
    
    public string? Phone { get; set; } = string.Empty;
    
    public string? Email { get; set; } = string.Empty;

    public string? Id { get; set; } = string.Empty;
}