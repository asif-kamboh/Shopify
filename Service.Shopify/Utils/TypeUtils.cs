namespace Service.Shopify.Utils;

public static class TypeUtils
{
    public static bool IsNumeric(Type inputType)
    {
        var type = Nullable.GetUnderlyingType(inputType) ?? inputType; 
        return type == typeof(byte)
               || type == typeof(sbyte)
               || type == typeof(short)
               || type == typeof(ushort)
               || type == typeof(int)
               || type == typeof(uint)
               || type == typeof(long)
               || type == typeof(ulong)
               || type == typeof(decimal)
               || type == typeof(float)
               || type == typeof(double);
    }
}