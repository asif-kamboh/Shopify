using ScientificBit.Shopify.Requests.Admin.Args;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class OrderTransactionFragment : GraphQlFragment
{
    public OrderTransactionFragment(string name, OrderTransactionArgs? args = null) : base(name, args)
    {
        AddFields(new []
        {
            "id", "gateway", "kind", "createdAt", "paymentId", "status",
            "processedAt", "authorizationCode", "test"
        });
        AddFragment(new MoneyBagFragment("amountSet"));
    }
}