using Core.Commands;
using Microsoft.EntityFrameworkCore;

namespace DAL.Commands.CategoryCommands
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly PlaceContext _placeContext;
        public DeleteCategoryCommandHandler(PlaceContext placeContext)
        {
            _placeContext = placeContext;
        }
        public async Task HandleAsync(DeleteCategoryCommand command, CancellationToken cancellationToken = default)
        {
            var category = await _placeContext.Categories.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (category != null)
            {
                _placeContext.Categories.Remove(category);
                await _placeContext.SaveChangesAsync();
            }
        }
    }
}
