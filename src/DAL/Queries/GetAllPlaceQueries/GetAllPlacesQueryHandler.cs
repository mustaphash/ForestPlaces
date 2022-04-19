using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;

namespace DAL.Queries.GetAllPlaceQueries
{
    public class GetAllPlacesQueryHandler : IQueryHandler<GetAllPlacesQuery, IList<Place>>
    {
        private readonly PlaceContext _placeContext;
        public GetAllPlacesQueryHandler(PlaceContext placeContext)
        {
            _placeContext = placeContext;
        }
        public async Task<IList<Place>> HandleAsync(GetAllPlacesQuery query, CancellationToken cancellationToken = default)
        {
            List<Place> places = await _placeContext.Places.ToListAsync(cancellationToken);

            return places;
        }
    }
}
