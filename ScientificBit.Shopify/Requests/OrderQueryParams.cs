using Refit;

namespace ScientificBit.Shopify.Requests;

public class OrderQueryParams : AdminApiQueryParams
{
    private readonly string[] _fields =
    {
        "id", "name", "email", "phone", "line_items", "shipping_address", "customer",
        "subtotal_price", "total_discounts", "total_tax", "total_price", "currency",
        "current_subtotal_price", "current_total_discounts", "current_total_tax", "current_total_price",
        "financial_status", "fulfillment_status", "order_status_url",
        "tags", "note", "note_attributes", "created_at", "updated_at"
    };

    private readonly string[] _allFields =
    {
        "id", "name", "email", "phone", "customer",
        "shipping_address", "billing_address",
        "line_items", "shipping_lines",
        "subtotal_price", "total_tax", "total_price", "total_outstanding",
        "current_subtotal_price", "current_total_discounts", "current_total_tax", "current_total_price",
        "total_weight", "currency",  "gateway", "reference",
        "total_discounts", "discount_codes", "discount_applications", "discount_allocations",
        "financial_status", "fulfillment_status", "order_status_url",
        "tags", "note", "note_attributes", "test", "token",
        "order_number", "checkout_id", "checkout_token",
        "cancel_reason", "cancelled_at", "processed_at", "closed_at",
        "updated_at", "created_at"
    };

    public static OrderQueryParams WithAllFields()
    {
        return new OrderQueryParams(true);
    }

    private OrderQueryParams(bool includeAllFields)
    {
        var fields = includeAllFields ? _allFields : _fields;
        Fields = string.Join(",", fields);
        Limit = 250;
    }

    public OrderQueryParams() : this(false)
    {
    }

    /// <summary>
    /// Order IDs separated by comma
    /// </summary>
    [AliasAs("ids")]
    public string? Ids { get; set; }

    /// <summary>
    /// ISO 8601 format date ex: 2023-07-28T15:57:11+03:00
    /// </summary>
    [AliasAs("updated_at_min")]
    [Query(Format = "yyyy-MM-ddTHH:mm:ss")]
    public DateTime? UpdatedAtMin { get; set; }

    /// <summary>
    /// ISO 8601 format date ex: 2023-07-28T15:57:11+03:00
    /// </summary>
    [AliasAs("created_at_min")]
    [Query(Format = "yyyy-MM-ddTHH:mm:ss")]
    public DateTime? CreatedAtMin { get; set; }

    /// <summary>
    /// ISO 8601 format date ex: 2023-07-28T15:57:11+03:00
    /// </summary>
    [AliasAs("created_at_max")]
    [Query(Format = "yyyy-MM-ddTHH:mm:ss")]
    public DateTime? CreatedAtMax { get; set; }

    /// <summary>
    /// Numeric Id of customer
    /// </summary>
    [AliasAs("customer_id")]
    public long? CustomerId { get; set; }

    /// <summary>
    /// Numeric Id of product
    /// </summary>
    [AliasAs("product_id")]
    public long? ProductId { get; set; }

    /// <summary>
    /// values are null/unfulfilled, partial, fulfilled
    /// </summary>
    [AliasAs("fulfillment_status")]
    public string? FulfillmentStatus { get; set; }

    /// <summary>
    /// open, closed, cancelled, any
    /// </summary>
    [AliasAs("status")]
    public string? Status { get; set; } = "any";
}