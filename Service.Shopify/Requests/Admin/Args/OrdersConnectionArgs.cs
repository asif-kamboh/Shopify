using Service.Shopify.Requests.GraphQl;
using Service.Shopify.Utils;

namespace Service.Shopify.Requests.Admin.Args;

public class OrdersConnectionArgs : GraphQlConnectionArgs
{
    public OrdersQueryParams? Query { get; set; }

    public string? SavedSearchId { get; set; }

    /// <summary>
    /// Possible values are:
    /// CREATED_AT, UPDATED_AT, ID, RELEVANCE, TOTAL_PRICE,
    /// TOTAL_ITEMS_QUANTITY, ORDER_NUMBER, FINANCIAL_STATUS,
    /// FULFILLMENT_STATUS, DESTINATION, CUSTOMER_NAME,
    /// PO_NUMBER, PROCESSED_AT
    /// </summary>
    public string? SortKey { get; set; }
}

public class OrdersQueryParams
{
    public IList<string>? Ids { get; set; }

    public GraphQlIdQueryStringParam? Id { get; set; }
    /// <summary>
    /// Order Name
    /// </summary>
    public string? Name { get; set; }

    public string? Default { get; set; }

    public long? CustomerId { get; set; }

    public string? Sku { get; set; }

    /// <summary>
    /// Order Status: open, closed, cancelled, not_closed
    /// </summary>
    public string? Status { get; set; }

    public string? Tag { get; set; }

    /// <summary>
    /// not_tag
    /// </summary>
    public string? NotTag { get; set; }

    /// <summary>
    /// test
    /// </summary>
    public bool? IsTest { get; set; } 

    public string? CartToken { get; set; }

    public long? ChannelId { get; set; }

    /// <summary>
    /// filter by channel handle
    /// </summary>
    public IList<string>? Channels { get; set; }

    public string? CheckoutToken { get; set; }
    // confirmation_number
    public string? ConfirmationNo { get; set; }
    // delivery_method
    public string? DeliveryMethod { get; set; }
    // discount_code
    public string? DiscountCode { get; set; }
    // email
    public string? Email { get; set; }
    // financial_status
    public string? FinancialStatus { get; set; }
    // fulfillment_status
    public string? FulfillmentStatus { get; set; }
    // gateway
    public string? Gateway { get; set; }
    // sales_channel
    public string? SalesChannel { get; set; }
    // risk_level
    public string? RiskLevel { get; set; }
    // created_at
    public GraphQlCreatedAtQueryStringParam? CreatedAt { get; set; }
    // updated_at
    public GraphQlUpdatedAtQueryStringParam? UpdatedAt { get; set; }

    public override string ToString()
    {
        var tokens = new List<string>();

        if (!string.IsNullOrEmpty(Default)) tokens.Add(Default);
        if (!string.IsNullOrEmpty(Sku)) tokens.Add($"status:{Sku}");
        if (!string.IsNullOrEmpty(Status)) tokens.Add($"status:{Status}");
        if (!string.IsNullOrEmpty(Tag)) tokens.Add($"tag:{Tag}");
        if (!string.IsNullOrEmpty(NotTag)) tokens.Add($"tag_not:{NotTag}");
        if (!string.IsNullOrEmpty(CartToken)) tokens.Add($"cart_token:{CartToken}");
        if (!string.IsNullOrEmpty(Name)) tokens.Add($"name:{Name}");
        if (!string.IsNullOrEmpty(Gateway)) tokens.Add($"gateway:{Gateway}");
        if (!string.IsNullOrEmpty(CheckoutToken)) tokens.Add($"checkout_token:{CheckoutToken}");
        if (!string.IsNullOrEmpty(DeliveryMethod)) tokens.Add($"delivery_method:{DeliveryMethod}");
        if (!string.IsNullOrEmpty(ConfirmationNo)) tokens.Add($"confirmation_number:{ConfirmationNo}");
        if (!string.IsNullOrEmpty(DiscountCode)) tokens.Add($"discount_code:{DiscountCode}");
        if (!string.IsNullOrEmpty(Email)) tokens.Add($"email:{Email}");
        if (!string.IsNullOrEmpty(FinancialStatus)) tokens.Add($"financial_status:{FinancialStatus}");
        if (!string.IsNullOrEmpty(FulfillmentStatus)) tokens.Add($"fulfillment_status:{FulfillmentStatus}");
        if (!string.IsNullOrEmpty(SalesChannel)) tokens.Add($"sales_channel:{RiskLevel}");
        if (!string.IsNullOrEmpty(RiskLevel)) tokens.Add($"risk_level:{RiskLevel}");

        if (Ids != null && Ids.Any())
        {
            tokens.Add( string.Join(" OR ", Ids.Select(gid => $"id:{ShopifyUtils.GetNumericId(gid)}")));
        }
        else if (Id != null)
        {
            tokens.Add(Id.ToString());
        }
        if (CustomerId.HasValue) tokens.Add($"customer_id:{CustomerId.Value}");
        if (IsTest.HasValue) tokens.Add($"test:{IsTest.Value}");
        if (ChannelId.HasValue) tokens.Add($"channel_id:{ChannelId.Value}");
        if (Channels != null && Channels.Any()) tokens.Add($"channel:{string.Join(",", Channels)}");

        if (CreatedAt != null) tokens.Add(CreatedAt.ToString());
        if (UpdatedAt != null) tokens.Add(UpdatedAt.ToString());

        return tokens.Count > 0 ? string.Join(" AND ", tokens) : string.Empty;
    }
}