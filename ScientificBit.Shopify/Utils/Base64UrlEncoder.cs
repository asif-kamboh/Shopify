using System.Globalization;
using System.Text;

namespace ScientificBit.Shopify.Utils;

/// <summary>
/// Copied from Microsoft.Identity.Token package. The purpose is to reduce dependency on external package.
/// Ref:
///   https://github.com/microsoft/azure-activedirectory-jwt-token-handler-for-dotnet/blob/dev/lib/Base64UrlEncoder.cs
/// </summary>
internal static class Base64UrlEncoder
{
    private const char Base64PadCharacter = '=';
    private static readonly string DoubleBase64PadCharacter = string.Format(CultureInfo.InvariantCulture, "{0}{0}", Base64PadCharacter);
    private const char Base64Character62 = '+';
    private const char Base64Character63 = '/';
    private const char Base64UrlCharacter62 = '-';
    private const char Base64UrlCharacter63 = '_';

    /// <summary>
    /// The following functions perform base64url encoding which differs from regular base64 encoding as follows
    /// * padding is skipped so the pad character '=' doesn't have to be percent encoded
    /// * the 62nd and 63rd regular base64 encoding characters ('+' and '/') are replace with ('-' and '_')
    /// The changes make the encoding alphabet file and URL safe.
    /// </summary>
    /// <param name="arg">string to encode.</param>
    /// <returns>Base64Url encoding of the UTF8 bytes.</returns>
    public static string Encode(string arg)
    {
        if (null == arg)
        {
            throw new ArgumentNullException(arg);
        }

        return Encode(Encoding.UTF8.GetBytes(arg));
    }

    /// <summary>
    /// See above.
    /// </summary>
    /// <param name="arg">bytes to encode.</param>
    /// <returns>Base64Url encoding of the bytes.</returns>
    public static string Encode(byte[] arg)
    {
        if (null == arg)
        {
            throw new ArgumentNullException("arg");
        }

        string s = Convert.ToBase64String(arg);
        s = s.Split(Base64PadCharacter)[0]; // Remove any trailing padding
        s = s.Replace(Base64Character62, Base64UrlCharacter62);  // 62nd char of encoding
        s = s.Replace(Base64Character63, Base64UrlCharacter63);  // 63rd char of encoding

        return s;
    }

    /// <summary>
    /// Returns the decoded bytes.
    /// </summary>
    /// <param name="str">base64Url encoded string.</param>
    /// <returns>UTF8 bytes.</returns>
    public static byte[] DecodeBytes(string str)
    {
        if (null == str)
        {
            throw new ArgumentNullException("str");
        }

        // 62nd char of encoding
        str = str.Replace(Base64UrlCharacter62, Base64Character62);
        
        // 63rd char of encoding
        str = str.Replace(Base64UrlCharacter63, Base64Character63);

        // check for padding
        switch (str.Length % 4)
        {
            case 0:
                // No pad chars in this case
                break;
            case 2:
                // Two pad chars
                str += DoubleBase64PadCharacter;
                break;
            case 3:
                // One pad char
                str += Base64PadCharacter;
                break;
            default:
                throw new ArgumentException("Illegal base64url string!");
        }

        return Convert.FromBase64String(str);
    }

    /// <summary>
    /// Decodes the string from Base64UrlEncoded to UTF8.
    /// </summary>
    /// <param name="arg">string to decode.</param>
    /// <returns>UTF8 string.</returns>
    public static string Decode(string arg)
    {
        return Encoding.UTF8.GetString(DecodeBytes(arg));
    }
}