using Service.Shopify.Builders.Fragments;
using Service.Shopify.Requests.Admin.Args;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Query;

public class VariantQueryBuilder : GenericQueryBuilder<VariantsConnectionArgs>
{
    public static VariantQueryBuilder QueryById()
    {
        var builder = new VariantQueryBuilder("GetProductVariant($id: ID!)", "productVariant(id: $id)");
        builder.AddDetailedFields();
        return builder;
    }

    public static VariantQueryBuilder QueryAll()
    {
        return QueryAll(new VariantsConnectionArgs());
    }

    public static VariantQueryBuilder QueryAll(VariantsConnectionArgs? args, bool pagination = false)
    {
        var builder = new VariantQueryBuilder("productVariants", "productVariants", args)
        {
            Pagination = pagination
        };
        return builder;
    }

    private static readonly string[] DefaultFields =
    {
        "id", "title", "displayName", "availableForSale", "sku", "barcode", "price", "taxable",
        "sellableOnlineQuantity", "compareAtPrice", "inventoryQuantity", "createdAt"
    };

    private VariantQueryBuilder(string methodSignature, string resource, VariantsConnectionArgs? args = null)
        : base(methodSignature, resource, DefaultFields, args)
    {
    }

    public VariantQueryBuilder AddDetailedFields()
    {
        AddProduct();
        AddSelectedOptions();
        AddImage();
        return this;
    }

    public VariantQueryBuilder AddProduct()
    {
        var fragment = new GraphQlFragment("product");
        fragment.AddFields(new[] {"id", "title", "handle", "productType", "vendor", "tags", "status"});
        return this.AddFragment(fragment);
    }

    public VariantQueryBuilder AddImage()
    {
        var fragment = new GraphQlFragment("image");
        fragment.AddFields(new[] {"id", "url", "altText", "height", "width"});
        return this.AddFragment(fragment);
    }

    public VariantQueryBuilder AddSelectedOptions()
    {
        var fragment = new GraphQlFragment("image");
        fragment.AddFields(new[] {"name", "value"});
        return this.AddFragment(fragment);
    }

    public VariantQueryBuilder AddInventoryItem(long locationId)
    {
        return AddInventoryItem($"gid://shopify/Location/{locationId}");
    }

    public VariantQueryBuilder AddInventoryItem(string locationId)
    {
        var inventoryLevelArgs = new InventoryLevelArgs {LocationId = locationId};
        var inventorItemFragment = new GraphQlFragment("inventoryItem");
        inventorItemFragment.AddFields(new[] {"id", "sku", "requiresShipping"});
        inventorItemFragment.AddFragment(new InventoryLevelFragment("inventoryLevel", inventoryLevelArgs));
        return this.AddFragment(inventorItemFragment);
    }
}