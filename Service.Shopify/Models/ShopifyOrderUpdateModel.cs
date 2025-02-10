using Refit;

namespace Service.Shopify.Models;

public class ShopifyOrderUpdateModel
{
    [AliasAs("notes")]
    public string? Note { get; set; }

    [AliasAs("note_attributes")]
    public IList<ShopifyNoteAttribute>? NoteAttributes { get; set; }

    [AliasAs("email")]
    public string? Email { get; set; }
    
    [AliasAs("phone")]
    public string? Phone { get; set; }

    [AliasAs("tags")]
    public string? Tags { get; set; }
}