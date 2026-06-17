using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Query;

public class DraftOrderQueryBuilder : GenericQueryBuilder
{
    private static readonly string[] DefaultFields =
    {
        "id", "name", "status", "email", "phone",
        "tags", "currencyCode", "invoiceUrl",
        "taxExempt", "taxesIncluded",
        "createdAt", "updatedAt", "completedAt", "invoiceSentAt"
    };

    public static DraftOrderQueryBuilder QueryById()
    {
        var builder = new DraftOrderQueryBuilder("getDraftOrderById($id: ID!)", "draftOrder(id: $id)", DefaultFields);
        builder.AddDefaultFields();
        return builder;
    }

    private DraftOrderQueryBuilder(string methodSignature, string resource, IEnumerable<string> fields)
        : base(methodSignature, resource, fields)
    {
    }

    private void AddDefaultFields()
    {
        this.AddFragment(new MoneyBagFragment("subtotalPriceSet"));
        this.AddFragment(new MoneyBagFragment("totalPriceSet"));
        this.AddFragment(new MoneyBagFragment("totalTaxSet"));
        this.AddFragment(new MoneyBagFragment("totalShippingPriceSet"));
        this.AddFragment(new CustomerFragment("customer"));
        this.AddFragment(new AddressFragment("shippingAddress"));
        this.AddFragment(new AddressFragment("billingAddress"));

        var orderFragment = new GraphQlFragment("order");
        orderFragment.AddFields(new[] { "id", "name" });
        this.AddFragment(orderFragment);
    }

    public DraftOrderQueryBuilder AddLineItems(GraphQlConnectionArgs? args = null)
    {
        args ??= new GraphQlConnectionArgs { First = 100 };
        return this.AddFragment(new DraftOrderLineItemsFragment("lineItems", args));
    }
}