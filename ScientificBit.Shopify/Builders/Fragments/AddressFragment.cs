using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class AddressFragment : GraphQlFragment
{
    public AddressFragment(string name) : base(name)
    {
        var addressFields = new[]
        {
            "id", "name", "phone", "firstName", "lastName",
            "address1", "address2", "formatted", "formattedArea",
            "company", "latitude", "longitude", "coordinatesValidated",
            "city", "country", "countryCodeV2",
            "province", "provinceCode", "timeZone"
        };
        AddFields(addressFields);
    }
}