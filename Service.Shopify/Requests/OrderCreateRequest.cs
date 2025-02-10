namespace Service.Shopify.Requests;

public class OrderCreateRequest
{
    /// <summary>
    /// Shopify checkout object ID
    /// </summary>
    public string CheckoutId { get; set; } = string.Empty;

    /// <summary>
    /// Values are: "pending" or "paid"
    /// </summary>
    public string PaymentStatus { get; set; } = Enums.PaymentStatus.Pending;

    /// <summary>
    /// If customer accepts a TradeIn offer, the payload will contain a Quotation ID
    /// </summary>
    public string? TradeInQuotationId { get; set; }

    /// <summary>
    /// User's selected locale. Default=en
    /// </summary>
    public string? Lang { get; set; }

    /// <summary>
    /// List if payment objects
    /// </summary>
    public IList<PaymentInfo> Payments { get; set; } = new List<PaymentInfo>();

    public IList<PaymentInfo>? PaymentInput { get; set; }

    public class PaymentInfo
    {
        /// <summary>
        /// Useful for online transactions
        /// </summary>
        public string? TransactionId { get; set; }

        /// <summary>
        /// Source of payment
        /// </summary>
        public string? PaymentSource { get; set; }

        /// <summary>
        /// Order value
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Shopify object ID or one of PaymentMethods enum
        /// </summary>
        public string? PaymentMethod { get; set; }

        /// <summary>
        /// paid or pending
        /// </summary>
        public string? PaymentStatus { get; set; }

        /// <summary>
        /// Required for Staff loan order
        /// </summary>
        public string? EmployeeId { get; set; }

        /// <summary>
        /// Required for Staff loan order
        /// </summary>
        public string? Qid { get; set; }
    }
}