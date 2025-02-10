using Service.Shopify.Enums;

namespace Service.Shopify.Requests;

public class OrderTransactionCreateRequest
{
    public static OrderTransactionCreateRequest AuthorizeTransaction(double amount, long? parentId)
    {
        return new OrderTransactionCreateRequest(TransactionTypes.Authorization, amount, parentId)
        {
            Transaction = { Source = "external" }
        };
    }

    public static OrderTransactionCreateRequest CaptureTransaction(double amount, long? parentId)
    {
        return new OrderTransactionCreateRequest(TransactionTypes.Capture, amount, parentId);
    }

    public static OrderTransactionCreateRequest RefundTransaction(long? parentId)
    {
        return new OrderTransactionCreateRequest(TransactionTypes.Refund, null, parentId);
    }

    public static OrderTransactionCreateRequest VoidTransaction(long? parentId)
    {
        return new OrderTransactionCreateRequest(TransactionTypes.Void, null, parentId);
    }

    private OrderTransactionCreateRequest(string kind, double? amount, long? parentId)
    {
        Transaction = new TransactionPayload { Kind = kind, Amount = amount, ParentId = parentId };
    }

    public TransactionPayload Transaction { get; }

    public class TransactionPayload
    {
        public string Kind { get; set; } = TransactionTypes.Capture;

        public string Currency { get; set; } = "";

        public string? Source { get; set; }

        public double? Amount { get; set; }

        public long? ParentId { get; set; }
    }
}