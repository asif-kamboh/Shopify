using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.Admin.Args;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Query;

public class ProductQueryBuilder : GenericQueryBuilder<ProductsConnectionArgs>
{
    public static ProductQueryBuilder QueryById()
    {
        var builder = new ProductQueryBuilder("getProductById($id: ID!)", "product(id: $id)", DefaultFields);
        return builder;
    }

    public static ProductQueryBuilder QueryAll()
    {
        return QueryAll(new ProductsConnectionArgs {First = 10});
    }

    public static ProductQueryBuilder QueryAll(ProductsConnectionArgs args)
    {
        var builder = new ProductQueryBuilder("products", "products", DefaultFields, args);
        return builder;
    }

    private ProductQueryBuilder(string methodSignature, string resource, IEnumerable<string> fields,
        ProductsConnectionArgs? args = null) : base(methodSignature, resource, fields, args)
    {
    }

    private static readonly string[] DefaultFields =
    {
        "id", "title", "bodyHtml", "vendor", "productType", "handle", "templateSuffix",
        "status", "tags",
        "totalInventory",
        "createdAt", "updatedAt", "publishedAt"
    };

    public ProductQueryBuilder AddOptions(int count, string? locale = null)
    {
        var args = new OptionsQueryArgs {First = count};
        var fragment = new ProductOptionFragment("options", args);
        if (!string.IsNullOrEmpty(locale))
        {
            fragment.AddFragment(new TranslationsFragment("translations", new TranslationQueryArgs {Locale = locale}));
        }
        return this.AddFragment(fragment);
    }

    public ProductQueryBuilder AddImages(int count, bool includePreview = false)
    {
        /* Sample fragment {
            "id",
            "...on MediaImage { image { altText url }}",
            "preview { ...on MediaPreviewImage { image { url altText } } }"
        }*/
        var imageFragment = new ImageFragment("image");
        var mediaImgFragment = new GraphQlFragment("...on MediaImage");
        mediaImgFragment.AddFragment(imageFragment);

        var args = new GraphQlConnectionArgs {First = count};
        var nodesFragment = new GraphQlNodesFragment<GraphQlFragment>("media", args);
        nodesFragment.AddField("id");
        nodesFragment.AddFragment(mediaImgFragment);

        if (includePreview)
        {
            var previewImgFragment = new GraphQlFragment("...on MediaPreviewImage");
            previewImgFragment.AddFragment(imageFragment);
            var previewFragment = new GraphQlFragment("preview");
            previewFragment.AddFragment(previewImgFragment);
        }

        return this.AddFragment(nodesFragment);
    }

    public ProductQueryBuilder AddVariantsConnection(int variantsCount, Action<VariantQueryBuilder> action)
    {
        var builder = VariantQueryBuilder.QueryAll(new VariantsConnectionArgs { First = variantsCount });
        action.Invoke(builder);

        var args = new GraphQlConnectionArgs {First = variantsCount};
        var nodesFragment = new GraphQlNodesFragment<GraphQlFragment>("variants", args);

        nodesFragment.AddFragments(builder.Fragments);

        return this.AddFragment(nodesFragment);
    }
}