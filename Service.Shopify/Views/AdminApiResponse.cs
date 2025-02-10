namespace Service.Shopify.Views;

public class AdminApiResponse
{
    public IList<UserError>? UserErrors { get; set; }

    public class UserError
    {
        public string? Code { get; set; }

        public IList<string>? Field { get; set; }

        public string? Message { get; set; }

        public string GetFields()
        {
            return Field != null ? string.Join(",", Field) : string.Empty;
        }
    }
}