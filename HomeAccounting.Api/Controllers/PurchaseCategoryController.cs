using HomeAccounting.Application.Contracts;
using HomeAccounting.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeAccounting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseCategoryController : ControllerBase
    {
        private readonly IPurchaseCategoryService _purchaseCategoryService;

        public PurchaseCategoryController(IPurchaseCategoryService purchaseCategoryService)
        {
            _purchaseCategoryService = purchaseCategoryService;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a purchase category by ID",
            Description = "Returns a purchase category by its ID",
            OperationId = "GetCategoryById",
            Tags = new[] { "PurchaseCategories" }
        )]
        [SwaggerResponse(200, "The purchase category", typeof(PurchaseCategory))]
        [SwaggerResponse(404, "Category not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAsyncy([FromRoute] int id)
        {
            try
            {
                var purchaseCategory = await _purchaseCategoryService.GetAsync(id);
                return Ok(purchaseCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all purchase categories",
            Description = "Returns a list of all purchase categories",
            OperationId = "GetCategories",
            Tags = new[] { "PurchaseCategories" }
        )]
        [SwaggerResponse(200, "A list of purchase categories", typeof(IEnumerable<PurchaseCategory>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetPurchaseCategories()
        {
            try
            {
                var purchaseCategories = await _purchaseCategoryService.GetPurchaseCategoriesAsync();
                return Ok(purchaseCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new purchase category",
            Description = "Creates a new purchase category",
            OperationId = "CreateCategory",
            Tags = new[] { "PurchaseCategories" }
        )]
        [SwaggerResponse(200, "The created purchase category", typeof(PurchaseCategory))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> CreateAsync([FromBody] PurchaseCategory category)
        {
            try
            {
                var createdCategory = await _purchaseCategoryService.CreateAsync(category);
                return Ok(createdCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Update an existing purchase category",
            Description = "Updates an existing purchase category",
            OperationId = "UpdateCategory",
            Tags = new[] { "PurchaseCategories" }
        )]
        [SwaggerResponse(200, "The updated purchase category", typeof(PurchaseCategory))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> UpdateAsync([FromBody] PurchaseCategory category)
        {
            try
            {
                var updatedPurchaseCategory = await _purchaseCategoryService.UpdateAsync(category);
                return Ok(updatedPurchaseCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a purchase category",
            Description = "Deletes a purchase category by its ID",
            OperationId = "DeleteCategory",
            Tags = new[] { "PurchaseCategories" }
        )]
        [SwaggerResponse(204, "Category deleted successfully")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                await _purchaseCategoryService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}
