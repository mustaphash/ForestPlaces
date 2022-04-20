using Core.Commands;
using Microsoft.EntityFrameworkCore;

namespace DAL.Commands.PlaceCommands
{
    public class CreatePlaceCommandHandler : ICommandHandler<CreatePlaceCommand>
    {
        private readonly PlaceContext _placeContext;
        public CreatePlaceCommandHandler(PlaceContext placeContext)
        {
            _placeContext = placeContext;
        }
        public async Task HandleAsync(CreatePlaceCommand command, CancellationToken cancellationToken = default)
        {
            var area = await _placeContext.Areas.Include(p => p.Places).FirstOrDefaultAsync(x => x.Id == command.AreaId);
            if (area != null)
            {
                _placeContext.Places.Add(command.Place);
                await _placeContext.SaveChangesAsync();
            }
        }
    }
}
