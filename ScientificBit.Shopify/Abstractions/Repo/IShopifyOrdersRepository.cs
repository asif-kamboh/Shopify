using ScientificBit.Shopify.Builders.Query;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Requests;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Abstractions.Repo;

public interface IShopifyOrdersRepository
{
    Task<GraphQlResult<ShopifyOrderModel>> GetOrderById(string orderId, bool detailed = false);

    Task<GraphQlResult<TOrder>> GetOrderById<TOrder>(string orderId, bool detailed = false) where TOrder : new();

    Task<GraphQlResult<ShopifyOrderModel>> GetOrderById(string orderId, Action<OrderQueryBuilder> builder);

    Task<GraphQlResult<TOrder>> GetOrderById<TOrder>(string orderId, Action<OrderQueryBuilder> builder) where TOrder : new();

    Task<GraphQlResults<ShopifyOrderModel>> GetOrdersAsync(Action<OrderQueryBuilder> builder);

    Task<GraphQlResults<TOrder>> GetOrdersAsync<TOrder>(Action<OrderQueryBuilder> builder) where TOrder : new();

    Task<GraphQlResult<DraftOrderModel>> CreateOrderAsync(DraftOrderInput payload, bool isPaid = false);

    Task<GraphQlResult<ShopifyBaseModel>> CreateDraftOrder(DraftOrderInput payload);

    Task<GraphQlResult<DraftOrderModel>> CompleteDraftOrder(string draftOrderId, bool isPaid = false);
}