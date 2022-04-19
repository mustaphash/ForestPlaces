using Core.Commands;

namespace DAL.Commands.CategoryCommands
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly PlaceContext _placeContext;
        public CreateCategoryCommandHandler(PlaceContext placeContext)
        {
            _placeContext = placeContext;
        }
        public async Task HandleAsync(CreateCategoryCommand command, CancellationToken cancellationToken = default)
        {
            await _placeContext.AddAsync(command.Category);
            await _placeContext.SaveChangesAsync();
        }
    }
}
