using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;

namespace DAL.Queries.GetAllAreaQueries
{
    public class GetAllAreasQueryHandler : IQueryHandler<GetAllAreasQuery, IList<Area>>
    {
        private readonly PlaceContext _placeContext;
        public GetAllAreasQueryHandler(PlaceContext placeContext)
        {
            _placeContext = placeContext;
        }
        public async Task<IList<Area>> HandleAsync(GetAllAreasQuery query, CancellationToken cancellationToken = default)
        {
            List<Area> areas = await _placeContext.Areas.Include(p => p.Places).ToListAsync(cancellationToken);

            return areas;
        }
    }
}
