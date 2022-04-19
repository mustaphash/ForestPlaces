using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;

namespace DAL.Queries.GetAllCategoryQueries
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, IList<Category>>
    {
        private readonly PlaceContext _placeContext;
        public GetAllCategoriesQueryHandler(PlaceContext placeContext)
        {
            _placeContext = placeContext;
        }
        public async Task<IList<Category>> HandleAsync(GetAllCategoriesQuery query, CancellationToken cancellationToken = default)
        {
            List<Category> categories = await _placeContext.Categories.ToListAsync(cancellationToken);

            return categories;
        }
    }
}
