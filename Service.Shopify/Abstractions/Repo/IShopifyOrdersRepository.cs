using Service.Shopify.Builders.Query;
using Service.Shopify.Models;
using Service.Shopify.Views;

namespace Service.Shopify.Abstractions.Repo;

public interface IShopifyOrdersRepository
{
    Task<GraphQlResult<ShopifyOrderModel>> GetOrderById(string orderId, bool detailed = false);

    Task<GraphQlResult<TOrder>> GetOrderById<TOrder>(string orderId, bool detailed = false) where TOrder : new();

    Task<GraphQlResult<ShopifyOrderModel>> GetOrderById(string orderId, Action<OrderQueryBuilder> builder);

    Task<GraphQlResult<TOrder>> GetOrderById<TOrder>(string orderId, Action<OrderQueryBuilder> builder) where TOrder : new();

    Task<GraphQlResults<ShopifyOrderModel>> GetOrdersAsync(Action<OrderQueryBuilder> builder);

    Task<GraphQlResults<TOrder>> GetOrdersAsync<TOrder>(Action<OrderQueryBuilder> builder) where TOrder : new();
}