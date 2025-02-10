using System.Net;

namespace Service.Shopify.Exceptions;

public class ShopifyApiException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public ShopifyApiException(string message) : this(message, null)
    {
    }

    public ShopifyApiException(HttpStatusCode statusCode) : this("Internal exception", statusCode)
    {
    }

    public ShopifyApiException(string message, HttpStatusCode statusCode) : this(message, statusCode, null)
    {
    }

    public ShopifyApiException(string message, Exception? innerException) : this(message, HttpStatusCode.InternalServerError, innerException)
    {
    }

    public ShopifyApiException(string message, HttpStatusCode statusCode, Exception? innerException) : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}