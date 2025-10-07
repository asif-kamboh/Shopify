using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Abstractions.Repo;
using ScientificBit.Shopify.Builders.Query;
using ScientificBit.Shopify.Mappers;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Models.Base;
using ScientificBit.Shopify.Requests;
using ScientificBit.Shopify.Requests.Admin.Mutations;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Domain;

internal class ShopifyOrdersRepository : ShopifyBaseRepository, IShopifyOrdersRepository
{
    private readonly IAdminApiClient _apiClient;

    public ShopifyOrdersRepository(IAdminApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<GraphQlResult<ShopifyOrderModel>> GetOrderById(string orderId, bool allFields = false)
    {
        return GetOrderById<ShopifyOrderModel>(orderId, allFields);
    }

    public Task<GraphQlResult<TOrder>> GetOrderById<TOrder>(string orderId, bool detailed = false) where TOrder : new()
    {
        return GetOrderById<TOrder>(orderId, detailed, _ => { });
    }

    public Task<GraphQlResult<ShopifyOrderModel>> GetOrderById(string orderId, Action<OrderQueryBuilder> builder)
    {
        return GetOrderById<ShopifyOrderModel>(orderId, false, builder);
    }

    public Task<GraphQlResult<TOrder>> GetOrderById<TOrder>(string orderId, Action<OrderQueryBuilder> builder) where TOrder : new()
    {
        return GetOrderById<TOrder>(orderId, false, builder);
    }

    public Task<GraphQlResults<ShopifyOrderModel>> GetOrdersAsync(Action<OrderQueryBuilder> builder)
    {
        return GetOrdersAsync<ShopifyOrderModel>(builder);
    }

    public async Task<GraphQlResults<TOrder>> GetOrdersAsync<TOrder>(Action<OrderQueryBuilder> builder) where TOrder : new()
    {
        var queryBuilder = OrderQueryBuilder.QueryAll();
        queryBuilder.Pagination = true;
        builder.Invoke(queryBuilder);

        var query = queryBuilder.Build();

        var response = await _apiClient.RunQueryAsync<OrdersGetResponse<TOrder>>(query);
        return GraphQlResultMapper.BuildResults(response, () =>
            GraphQlResultMapper.CreateResult(response.Data.Orders, response.Data.UserErrors, response.Errors)
        );
    }

    public async Task<GraphQlResult<DraftOrderModel>> CreateOrderAsync(DraftOrderInput payload, bool isPaid = false)
    {
        var draftOrderResult = await CreateDraftOrder(payload);
        if (string.IsNullOrEmpty(draftOrderResult.Data?.Id)) return new GraphQlResult<DraftOrderModel>()
        {
            Error = draftOrderResult.Error,
            GraphQlErrors = draftOrderResult.GraphQlErrors
        };

        var orderResult = await CompleteDraftOrder(draftOrderResult.Data?.Id ?? "", isPaid);
        return orderResult;
    }

    public async Task<GraphQlResult<ShopifyBaseModel>> CreateDraftOrder(DraftOrderInput payload)
    {
        var mutation = new DraftOrderCreateMutation
        {
            Variables = new { Input = payload }
        };

        var response = await _apiClient.RunMutationAsync<ShopifyMutationResponse>(mutation);

        return GraphQlResultMapper.BuildResult(response, () =>
            GraphQlResultMapper.CreateResult(response.Data.Result?.Data, response.Data.Result?.UserErrors,
                response.Errors)
        );
    }

    public async Task<GraphQlResult<DraftOrderModel>> CompleteDraftOrder(string draftOrderId, bool isPaid = false)
    {
        var mutation = new DraftOrderCompleteMutation
        {
            Variables = new { Id = draftOrderId, PaymentPending = !isPaid }
        };

        var response = await _apiClient.RunMutationAsync<ShopifyMutationResponse<DraftOrderModel>>(mutation);

        return GraphQlResultMapper.BuildResult(response, () =>
            GraphQlResultMapper.CreateResult(response.Data.Result?.Data, response.Data.Result?.UserErrors,
                response.Errors)
        );
    }

    #region Helper methods

    private async Task<GraphQlResult<TOrder>> GetOrderById<TOrder>(string orderId, bool detailed, Action<OrderQueryBuilder> builder) where TOrder : new()
    {
        var queryBuilder = OrderQueryBuilder.QueryById(detailed);

        builder.Invoke(queryBuilder);

        var query = queryBuilder.Build(new {Id = orderId});

        var response = await _apiClient.RunQueryAsync<OrderGetResponse<TOrder>>(query);
        return GraphQlResultMapper.BuildResult(response, () =>
            GraphQlResultMapper.CreateResult(response.Data.Order, response.Data.UserErrors, response.Errors)
        );
    }

    #endregion
}

public sealed class OrderGetResponse<TOrder> : AdminApiResponse where TOrder : new()
{
    public TOrder? Order { get; set; }
}

public class OrdersGetResponse<TOrder> : AdminApiResponse where TOrder : new()
{
    public GraphQlConnection<TOrder>? Orders { get; set; }
}