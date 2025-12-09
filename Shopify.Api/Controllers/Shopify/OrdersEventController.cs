using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificBit.Shopify.Abstractions.Repo;
using ScientificBit.Shopify.Auth;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Requests.Webhooks;

namespace Shopify.Api.Controllers.Shopify;

[ApiController]
[Authorize(AuthenticationSchemes = ShopifyAuthSchemes.ShopifyWebhookAuth)]
[Route("api/shopify/events/orders")]
public class OrdersEventController : ControllerBase
{
    private readonly IShopifyOrdersRepository _ordersRepository;

    public OrdersEventController(IShopifyOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    /// <summary>
    /// Registered for orders/created webhook topic
    /// </summary>
    /// <returns></returns>
    [HttpPost("created")]
    public async Task<IActionResult> HandlerOrderCreatedEvent([FromBody] ShopifyOrderEvent orderEvent)
    {
        // fetch order from shopify
        var result = await _ordersRepository.GetOrderById<ShopifyOrderModel>(orderEvent.AdminGraphqlApiId);

        if (result.Data != null)
        {
            // TODO: Handle the order event
        }

        if (result.HasErrors)
        {
            Console.WriteLine($"Failed to handle event. Error={result.Error ?? result.GraphQlErrors?.FirstOrDefault()}");
        }

        return Ok();
    }
}