namespace Service.Shopify.Models;

public class MetaObjectModel
{
    public string Id { get; set; } = string.Empty;

    public string Handle { get; set; } = string.Empty;

    public List<Field> Fields { get; set; } = new ();

    public Field? GetField(string key)
    {
        return Fields.FirstOrDefault(field => field.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)) ??
               null;
    }

    public class Field
    {
        public string Key { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;
    }
}