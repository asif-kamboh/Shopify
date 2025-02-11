namespace Service.Shopify.Enums;

public static class PaymentStatus
{
    public const string Pending = "pending";

    public const string Authorized = "authorized";

    public const string PartiallyPaid = "partially_paid";

    public const string Paid = "paid";

    public static bool IsPending(string? paymentStatus)
    {
        return Pending.Equals(paymentStatus, StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool IsPaid(string? paymentStatus)
    {
        return Paid.Equals(paymentStatus, StringComparison.InvariantCultureIgnoreCase);
    }
}