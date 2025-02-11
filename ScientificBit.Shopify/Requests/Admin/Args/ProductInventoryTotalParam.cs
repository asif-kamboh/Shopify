using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class ProductInventoryTotalParam
{
    public int InventoryTotal { get; set; }

    public GraphQlRangeQueryParamOperator Op { get; set; }

    public override string ToString()
    {
        return $"inventory_total:{Op}{InventoryTotal}";
    }
}