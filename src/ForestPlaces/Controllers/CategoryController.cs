using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllCategoryQueries;
using ForestPlaces.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;

namespace ForestPlaces.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IQueryHandler<GetAllCategoriesQuery, IList<Category>> _getAllCategoriesQuery;

        public CategoryController(
            IQueryHandler<GetAllCategoriesQuery, IList<Category>> getAllCategoriesQuery)
        {
            _getAllCategoriesQuery = getAllCategoriesQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            IList<Category> categories = await _getAllCategoriesQuery.HandleAsync(new GetAllCategoriesQuery());
            var categoryResponse = categories.Select(c => new CategoryResponseModel(c));

            return Ok(categoryResponse);
        }
    }
}
