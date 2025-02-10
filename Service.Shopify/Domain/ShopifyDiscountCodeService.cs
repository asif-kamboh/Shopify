using Microsoft.Extensions.Logging;
using Service.Shopify.Abstractions;
using Service.Shopify.Abstractions.Clients;
using Service.Shopify.Exceptions;
using Service.Shopify.Models;
using Service.Shopify.Models.Base;
using Service.Shopify.Requests;
using Service.Shopify.Requests.Admin.Mutations;
using Service.Shopify.Requests.Admin.Queries;
using Service.Shopify.Views;

namespace Service.Shopify.Domain;

internal class ShopifyDiscountCodeService : IShopifyDiscountCodeService
{
    private readonly ILogger<ShopifyDiscountCodeService> _logger;

    private readonly IAdminApiClient _graphQlApi;

    public ShopifyDiscountCodeService(IAdminApiClient graphQlApi, ILogger<ShopifyDiscountCodeService> logger)
    {
        _graphQlApi = graphQlApi;
        _logger = logger;
    }

    public async Task<ShopifyDiscountCodeNode?> GetBasicDiscountCodeById(string? discountId)
    {
        if (string.IsNullOrEmpty(discountId)) return null;

        var query = new DiscountNodeGetByIdQuery
        {
            Variables = new { Id = discountId }
        };
        var response = await _graphQlApi.RunQueryAsync<CodeDiscountNodeByCodeResponse>(query);
        return response.Data?.CodeDiscountNodeByCode;
    }

    public async Task<ShopifyDiscountCodeNode?> GetBasicDiscountCode(string? code)
    {
        if (string.IsNullOrEmpty(code)) return null;

        var query = new DiscountNodeGetByCodeQuery
        {
            Variables = new {Code = code}
        };
        var response = await _graphQlApi.RunQueryAsync<CodeDiscountNodeByCodeResponse>(query);
        return response.Data?.CodeDiscountNodeByCode;
    }

    public async Task<ShopifyDiscountCodeNode?> GetDiscountCodeNodeWithRedeemCodes(string code)
    {
        ShopifyDiscountCodeNode? result = null;
        string? nextPageCursor = null;
        bool hasNextPage;
        const int limit = 100;
        var allCodeNodes = new List<DiscountCodeBasic.DiscountRedeemCode>();
        do
        {
            var pageResult = await GetDiscountCodeNode(code, limit, nextPageCursor);
            var nodes = pageResult?.CodeDiscount?.Codes?.Nodes;
            if (nodes is null) break;
            if (result is null)
            {
                result = pageResult;
            }

            allCodeNodes.AddRange(nodes);

            nextPageCursor = pageResult?.CodeDiscount?.Codes?.PageInfo?.EndCursor;
            hasNextPage = pageResult?.CodeDiscount?.Codes?.PageInfo?.HasNextPage ?? false;
        } while (hasNextPage);

        if (result == null || !allCodeNodes.Any()) return result;

        result.CodeDiscount ??= new DiscountCodeBasic();
        result.CodeDiscount.Codes ??= new GraphQlConnection<DiscountCodeBasic.DiscountRedeemCode>();
        result.CodeDiscount.Codes.Nodes = allCodeNodes;
        return result;
    }

    public async Task CreateDiscountCodeNode(DiscountCodeNodeCreateRequest payload)
    {
        var hasCustomers = !(payload.CustomerIds is null && payload.ExcludeCustomerIds is null);
        var hasRequirements = payload.MinimumRequiredQuantity.HasValue || payload.MinimumRequiredSubtotal.HasValue;
        var basicCodeDiscount = new BasicDiscountCodeModel
        {
            Title = payload.Title,
            Code = payload.Code,
            StartsAt = payload.StartsAt.ToString("yyyy-MM-ddTHH:mm:ss"),
            EndsAt = payload.EndsAt?.ToString("yyyy-MM-ddTHH:mm:ss"),
            UsageLimit = payload.UsageLimit,
            CustomerSelection = new CustomerSelectionModel
            {
                Customers = hasCustomers ? new CustomersModel
                {
                    Add = payload.CustomerIds,
                    Remove = payload.ExcludeCustomerIds
                } : null,
                All = !hasCustomers
            },
            CustomerGets = new CustomerGetsModel
            {
                Value = new ValueModel
                {
                    DiscountAmount = payload.Amount.HasValue ? new DiscountAmountModel
                    {
                        Amount = payload.Amount.Value,
                        AppliesOnEachItem = false
                    } : null,
                    Percentage = payload.Percentage
                },
                Items = new ItemsModel { All = payload.AppliedOnAllItems }
            },
            AppliesOncePerCustomer = payload.AppliesOncePerCustomer,
            MinimumRequirement = hasRequirements ? new MinimumRequirementModel
            {
                Quantity = payload.MinimumRequiredQuantity.HasValue ? new MinimumQuantityRequirementModel
                {
                    GreaterThanOrEqualToQuantity = payload.MinimumRequiredQuantity.Value
                } : null,
                Subtotal = payload.MinimumRequiredSubtotal.HasValue ? new MinimumSubtotalRequirementModel
                {
                    GreaterThanOrEqualToSubtotal = payload.MinimumRequiredSubtotal.Value
                } : null
            } : null
        };

        await CreateDiscountCode(basicCodeDiscount);
    }

    public async Task AddDiscountRedeemCodes(string? discountCodeId, IList<string> redeemCodes)
    {
        if (string.IsNullOrEmpty(discountCodeId)) return;
        // Remove empty and duplicates
        var codes = redeemCodes.Select(c => c.Trim())
            .Where(c => !string.IsNullOrEmpty(c))
            .Distinct()
            .Select(c => new {Code = c})
            .ToList();

        var mutation = new DiscountRedeemCodeAddMutation
        {
            Variables = new {DiscountId = discountCodeId, Codes = codes}
        };
        var response = await _graphQlApi.RunMutationAsync<AdminApiResponse>(mutation);
        var error = response.Errors?.FirstOrDefault();
        if (response.Data is null && error != null)
        {
            _logger.LogError("Adding Redeem Codes failed for DiscountId={DiscountId}, Codes={Code}. Error={Message}",
                discountCodeId, string.Join(",", redeemCodes), error.Message);
            throw new ShopifyApiException(error.Message);
        }

        _logger.LogInformation("Added Redeem Codes for DiscountId={NodeId}", discountCodeId);
    }

    public async Task DeleteDiscountRedeemCode(string? discountCodeId, string? redeemCode)
    {
        if (string.IsNullOrEmpty(redeemCode)) return;

        var mutation = new DiscountRedeemCodeDeleteMutation
        {
            Variables = new {DiscountId = discountCodeId, Search = redeemCode}
        };
        var response = await _graphQlApi.RunMutationAsync<AdminApiResponse>(mutation);
        var error = response.Errors?.FirstOrDefault();
        if (response.Data is null && error != null)
        {
            _logger.LogError("Deleting RedeemCode failed for Code={Code}. Error={Message}", redeemCode, error.Message);
            throw new ShopifyApiException(error.Message);
        }

        _logger.LogInformation("Deleted RedeemCode for NodeId={NodeId}, Code={Code}", discountCodeId, redeemCode);
    }

    #region Helper methods

    private async Task CreateDiscountCode(BasicDiscountCodeModel payload)
    {
        var mutation = new DiscountCodeCreateMutation
        {
            Variables = new {BasicCodeDiscount = payload}
        };
        var response = await _graphQlApi.RunMutationAsync<DiscountCodeCreateResponse>(mutation);
        var error = response.Errors?.FirstOrDefault();
        if (response.Data is null && error != null)
        {
            throw new ShopifyApiException(error.Message);
        }
    }

    private async Task<ShopifyDiscountCodeNode?> GetDiscountCodeNode(string code, int limit, string? afterCursor)
    {
        var query = new DiscountNodeGetByCodeQuery(limit, afterCursor)
        {
            Variables = new { Code = code }
        };
        var response = await _graphQlApi.RunQueryAsync<CodeDiscountNodeByCodeResponse>(query);
        return response.Data.CodeDiscountNodeByCode;
    }

    #endregion
}

public class DiscountCodeCreateResponse
{
    public DiscountCodeIdResponse? DiscountCodeBasicCreate { get; set; }
}

public class DiscountCodeIdResponse : AdminApiResponse
{
    public ShopifyBaseModel? CodeDiscountNode { get; set; }
}

public class CodeDiscountNodeByCodeResponse
{
    public ShopifyDiscountCodeNode? CodeDiscountNodeByCode { get; set; }
}