using HomeAccounting.Application.Contracts;
using HomeAccounting.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeAccounting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a purchase by ID",
            Description = "Returns a purchase by its ID",
            OperationId = "GetPurchaseById",
            Tags = new[] { "Purchases" }
        )]
        [SwaggerResponse(200, "The purchase", typeof(Purchase))]
        [SwaggerResponse(404, "Purchase not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var purchase = await _purchaseService.GetAsync(id);
                return Ok(purchase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all purchases",
            Description = "Returns a list of all purchases, optionally filtered by creator user ID",
            OperationId = "GetPurchases",
            Tags = new[] { "Purchases" }
        )]
        [SwaggerResponse(200, "A list of purchases", typeof(IEnumerable<Purchase>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetPurchasesAsync([FromQuery] int? creatorUserId)
        {
            try
            {
                var purchases = await _purchaseService.GetPurchasesAsync(creatorUserId);
                return Ok(purchases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new purchase",
            Description = "Creates a new purchase",
            OperationId = "CreatePurchase",
            Tags = new[] { "Purchases" }
        )]
        [SwaggerResponse(200, "The created purchase", typeof(Purchase))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> CreateAsync([FromBody] Purchase purchase)
        {
            try
            {
                var createdPurchase = await _purchaseService.CreateAsync(purchase);
                return Ok(createdPurchase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Update an existing purchase",
            Description = "Updates an existing purchase",
            OperationId = "UpdatePurchase",
            Tags = new[] { "Purchases" }
        )]
        [SwaggerResponse(200, "The updated purchase", typeof(Purchase))]
        [SwaggerResponse(404, "Purchase not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> UpdatePurchase([FromQuery] int creatorUserId, [FromBody] Purchase purchase)
        {
            try
            {
                var updatedPurchase = await _purchaseService.UpdateAsync(creatorUserId, purchase);
                return Ok(updatedPurchase);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, $"{ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpDelete]
        [SwaggerOperation(
            Summary = "Delete a purchase",
            Description = "Deletes a purchase by its ID and checks creator user ID for opportunity to delete",
            OperationId = "DeletePurchase",
            Tags = new[] { "Purchases" }
        )]
        [SwaggerResponse(204, "Purchase deleted successfully")]
        [SwaggerResponse(404, "Purchase not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id, [FromQuery] int creatorUserId)
        {
            try
            {
                await _purchaseService.DeleteAsync(id, creatorUserId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, $"{ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}
