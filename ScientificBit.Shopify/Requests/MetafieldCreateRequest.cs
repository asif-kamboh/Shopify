using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Requests;

public class MetafieldCreateRequest
{
    public MetafieldCreateModel? Metafield { get; set; }
}

public class MetafieldCreateModel
{
    // {"namespace":"translation","key":"title_spanish","type":"single_line_text_field","value":"botas"}}'
    public string Namespace { get; set; } = "global";

    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public string Type { get; set; } = MetafieldTypes.SingleLineText;
}