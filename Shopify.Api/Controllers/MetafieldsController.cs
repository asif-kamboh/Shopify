using Microsoft.AspNetCore.Mvc;
using ScientificBit.Shopify.Abstractions.Repo;
using ScientificBit.Shopify.Models;

namespace Shopify.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetafieldsController : ControllerBase
{
    private readonly ILogger<MetafieldsController> _logger;
    private readonly IShopifyMetafieldsRepository _repository;

    public MetafieldsController(ILogger<MetafieldsController> logger, IShopifyMetafieldsRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] IList<MetafieldSetInput> metafields)
    {
        var result = await _repository.SetAsync(metafields);
        if (result.HasErrors)
        {
            _logger.LogError("Failed to set metafields. Error={Error}", result.Error ?? result.GraphQlErrors?.FirstOrDefault());
            return BadRequest(result.Error ?? "Failed to set metafields.");
        }

        return Ok(result.Data);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteAsync(IList<MetafieldIdentifier> metafields)
    {
        var result = await _repository.DeleteAsync(metafields);
        if (result.HasErrors)
        {
            _logger.LogError("Failed to delete metafields. Error={Error}", result.Error ?? result.GraphQlErrors?.FirstOrDefault());
            return BadRequest(result.Error ?? "Failed to delete metafields.");
        }

        return Ok(result.Data);
    }
}