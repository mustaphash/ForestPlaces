using Core.Commands;
using Core.Entities;

namespace DAL.Commands.CategoryCommands
{
    public class CreateCategoryCommand : ICommand
    {
        public CreateCategoryCommand(Category category)
        {
            Category = category;
        }
        public Category Category { get; }
    }
}
