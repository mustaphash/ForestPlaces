using Core.Commands;
using Core.Entities;
using Core.Queries;
using DAL.Commands.CategoryCommands;
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
        private readonly ICommandHandler<CreateCategoryCommand> _createCategoryCommand;
        private readonly ICommandHandler<DeleteCategoryCommand> _deleteCategoryCommand;

        public CategoryController(
            IQueryHandler<GetAllCategoriesQuery, IList<Category>> getAllCategoriesQuery,
            ICommandHandler<CreateCategoryCommand> createCategoryCommand,
            ICommandHandler<DeleteCategoryCommand> deleteCategoryCommand)
        {
            _getAllCategoriesQuery = getAllCategoriesQuery;
            _createCategoryCommand = createCategoryCommand;
            _deleteCategoryCommand = deleteCategoryCommand;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            IList<Category> categories = await _getAllCategoriesQuery.HandleAsync(new GetAllCategoriesQuery());
            var categoryResponse = categories.Select(c => new CategoryResponseModel(c));

            return Ok(categoryResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryModel model)
        {
            var category = model.ToCategory();
            await _createCategoryCommand.HandleAsync(new CreateCategoryCommand(category));

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _deleteCategoryCommand.HandleAsync(new DeleteCategoryCommand(id));

            return NoContent();
        }
    }
}
