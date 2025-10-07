namespace ScientificBit.Shopify.Requests;

public class DraftOrderLineItemInput
{
    public string VariantId { get; set; } = string.Empty;

    public string? Title { get; set; }

    public int Quantity { get; set; }

    public DraftOrderAppliedDiscountInput? AppliedDiscount { get; set; }
}