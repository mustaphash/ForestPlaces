using Core.Entities;

namespace ForestPlaces.Models.CategoryModels
{
    public class CategoryResponseModel
    {
        public CategoryResponseModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
