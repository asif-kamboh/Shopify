using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.Admin.Args;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Query;

public class OrderQueryBuilder : GenericQueryBuilder<OrdersConnectionArgs>
{
    private static readonly string[] DefaultFields =
    {
        "id", "name", "email", "phone",
        "billingAddressMatchesShippingAddress",
        "cancelledAt", "cancelReason", "cancellation { staffNote }",
        "tags", "clientIp", "closed", "closedAt", "processedAt",
        "currentSubtotalLineItemsQuantity", "currentTotalWeight",
        "confirmationNumber", "confirmed", "currencyCode",
        "createdAt", "updatedAt", "customerLocale", "paymentGatewayNames",
        "discountCode", "discountCodes", "refundable",
        "displayFinancialStatus", "displayFulfillmentStatus",
        "note", "test", "requiresShipping", "statusPageUrl", "restockable"
    };

    public static OrderQueryBuilder QueryById(bool detailed = false)
    {
        var builder = new OrderQueryBuilder("getOrderById($id: ID!)", "order(id: $id)", DefaultFields);
        if (detailed)
        {
            builder.AddDetailedFields();
        }
        return builder;
    }

    public static OrderQueryBuilder QueryAll()
    {
        return QueryAll(new OrdersConnectionArgs {First = 10});
    }

    public static OrderQueryBuilder QueryAll(OrdersConnectionArgs args)
    {
        var builder = new OrderQueryBuilder("orders", "orders", DefaultFields, args);
        return builder;
    }

    private OrderQueryBuilder(string methodSignature, string resource, IEnumerable<string> fields, OrdersConnectionArgs? args = null)
        : base(methodSignature, resource, fields, args)
    {
        AddDefaultFields();
    }

    private void AddDefaultFields()
    {
        this.AddFragment(new AddressFragment("shippingAddress"));
        this.AddFragment(new MoneyBagFragment("subtotalPriceSet"));
        this.AddFragment(new MoneyBagFragment("totalDiscountsSet"));
        this.AddFragment(new MoneyBagFragment("totalPriceSet"));
        this.AddFragment(new MoneyBagFragment("totalTaxSet"));
        this.AddFragment(new MoneyBagFragment("currentSubtotalPriceSet"));
        this.AddFragment(new MoneyBagFragment("currentTotalDiscountsSet"));
        this.AddFragment(new MoneyBagFragment("currentTotalPriceSet"));
        this.AddFragment(new MoneyBagFragment("currentTotalTaxSet"));
        this.AddFragment(new CustomAttributesFragment("customAttributes"));
        this.AddFragment(new CustomerFragment("customer"));
    }

    public OrderQueryBuilder AddDetailedFields()
    {
        AddLineItems();
        AddBillingAddress();
        AddCartDiscount();
        AddDiscountApplications();
        AddShippingPrice();
        AddShippingLine();
        AddTransactions();
        AddRefunds();
        return this;
    }

    public OrderQueryBuilder AddLineItems(GraphQlConnectionArgs? args = null)
    {
        return AddLineItems(_ => { }, args);
    }

    public OrderQueryBuilder AddLineItems(Action<OrderLineItemsFragment> fragmentBuilder, GraphQlConnectionArgs? args = null)
    {
        args ??= new GraphQlConnectionArgs { First = 100 };
        var fragment = new OrderLineItemsFragment("lineItems", args);
        fragmentBuilder.Invoke(fragment);
        return this.AddFragment(fragment);
    }

    public OrderQueryBuilder AddBillingAddress()
    {
        return this.AddFragment(new AddressFragment("billingAddress"));
    }

    public OrderQueryBuilder AddCartDiscount()
    {
        return this.AddFragment(new MoneyBagFragment("currentCartDiscountAmountSet"));
    }

    public OrderQueryBuilder AddShippingPrice()
    {
        return this.AddFragment(new MoneyBagFragment("currentShippingPriceSet"));
    }

    public OrderQueryBuilder AddDiscountApplications(int count = 5)
    {
        return AddDiscountApplications(new GraphQlConnectionArgs {First = count});
    }

    public OrderQueryBuilder AddDiscountApplications(GraphQlConnectionArgs? args)
    {
        args ??= new GraphQlConnectionArgs {First = 5};
        return this.AddFragment(new DiscountApplicationsFragment("discountApplications", args));
    }

    public OrderQueryBuilder AddShippingLine()
    {
        return AddShippingLine(_ => { });
    }

    public OrderQueryBuilder AddShippingLine(Action<ShippingLineFragment> fragmentBuilder)
    {
        var fragment = new ShippingLineFragment("shippingLine");
        fragmentBuilder.Invoke(fragment);
        return this.AddFragment(fragment);
    }

    public OrderQueryBuilder AddShippingLines(int count, bool includeRemovals = false)
    {
        var args = new ShippingLinesConnectionArgs {First = count, IncludeRemovals = includeRemovals};
        return AddShippingLines(args, _ => { });
    }

    public OrderQueryBuilder AddShippingLines(ShippingLinesConnectionArgs args, Action<ShippingLinesFragment> fragmentBuilder)
    {
        var fragment = new ShippingLinesFragment("shippingLines", args);
        fragmentBuilder.Invoke(fragment);
        return this.AddFragment(fragment);
    }

    public OrderQueryBuilder AddTransactions(int count = 5)
    {
        var args = new OrderTransactionArgs { First = count };
        return AddTransactions(args);
    }

    public OrderQueryBuilder AddTransactions(OrderTransactionArgs args)
    {
        return this.AddFragment(new OrderTransactionFragment("transactions", args));
    }

    public OrderQueryBuilder AddRefunds(int count = 5)
    {
        var args = new RefundArgs {First = count};
        return AddRefunds(args, _ => { });
    }

    public OrderQueryBuilder AddRefunds(RefundArgs args, Action<RefundFragment> fragmentBuilder)
    {
        var fragment = new RefundFragment("refunds", args);
        fragmentBuilder.Invoke(fragment);
        return this.AddFragment(fragment);
    }
}