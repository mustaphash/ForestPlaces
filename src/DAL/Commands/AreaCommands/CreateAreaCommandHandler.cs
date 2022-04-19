using Core.Commands;

namespace DAL.Commands.AreaCommands
{
    public class CreateAreaCommandHandler : ICommandHandler<CreateAreaCommand>
    {
        private readonly PlaceContext _placeContext;
        public CreateAreaCommandHandler(PlaceContext placeContext)
        {
            _placeContext = placeContext;
        }
        public async Task HandleAsync(CreateAreaCommand command, CancellationToken cancellationToken = default)
        {
            await _placeContext.AddAsync(command.Area);
            await _placeContext.SaveChangesAsync();
        }
    }
}
