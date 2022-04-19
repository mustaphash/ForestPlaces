using Core.Commands;

namespace DAL.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : ICommand
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
