using Core.Commands;
using Microsoft.EntityFrameworkCore;

namespace DAL.Commands.AreaCommands
{
    public class DeleteAreaCommandHandler : ICommandHandler<DeleteAreaCommand>
    {
        private readonly PlaceContext _placeContext;
        public DeleteAreaCommandHandler(PlaceContext placeContext)
        {
            _placeContext = placeContext;
        }
        public async Task HandleAsync(DeleteAreaCommand command, CancellationToken cancellationToken = default)
        {
            var area = await _placeContext.Areas.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (area != null)
            {
                _placeContext.Areas.Remove(area);
                await _placeContext.SaveChangesAsync();
            }
        }
    }
}
