using Core.Entities;

namespace ForestPlaces.Models.CategoryModels
{
    public class CreateCategoryModel
    {
        public string Name { get; set; }

        public Category ToCategory()
        {
            return new Category
            {
                Name = Name
            };
        }
    }
}
