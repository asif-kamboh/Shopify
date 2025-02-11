namespace Service.Shopify.Requests.Admin.Projections;

internal class DiscountCodeBasicProjection
{
    private readonly int _codesCount;
    private readonly string? _afterCursor;

    public DiscountCodeBasicProjection(int codesCount, string? afterCursor = null)
    {
        _codesCount = codesCount;
        _afterCursor = afterCursor;
    }

    public override string ToString()
    {
        var codesFragment = _codesCount > 0 ? $@"
            codes(first: {_codesCount} {(_afterCursor != null ? ", after: \"" + _afterCursor + "\"" : "")}) {{
                pageInfo {{ hasNextPage endCursor }}
                nodes {{ id asyncUsageCount code }}
            }}" : "";
        return $@"
            codeDiscount {{
                ... on DiscountCodeBasic {{
                    title
                    summary
                    appliesOncePerCustomer
                    status
                    codeCount
                    asyncUsageCount
                    usageLimit
                    startsAt
                    endsAt
                    discountClass
                    minimumRequirement {{
                        ...on DiscountMinimumQuantity {{ greaterThanOrEqualToQuantity }}
                        ...on DiscountMinimumSubtotal {{ greaterThanOrEqualToSubtotal {{ amount }} }}
                    }}
                    customerGets {{
                        appliesOnOneTimePurchase
                        appliesOnSubscription
                        items {{
                            ...on AllDiscountItems {{ allItems }}
                        }}
                        value {{
                            ...on DiscountAmount {{
                                appliesOnEachItem amount {{ amount }}
                            }}
                            ...on DiscountOnQuantity {{
                                quantity {{ quantity }}
                                effect {{
                                    ...on DiscountAmount {{ amount {{ amount }} appliesOnEachItem }}
                                    ...on DiscountPercentage {{ percentage }}
                                }}
                            }}
                            ...on DiscountPercentage {{ percentage }}
                        }}
                    }}
                    {codesFragment}
                }}
            }}";
    }
}