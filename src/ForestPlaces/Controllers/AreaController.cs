using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllAreaQueries;
using ForestPlaces.Models.AreaModels;
using Microsoft.AspNetCore.Mvc;

namespace ForestPlaces.Controllers
{
    [Route("area")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IQueryHandler<GetAllAreasQuery, IList<Area>> _getAllAreasQuery;

        public AreaController(
            IQueryHandler<GetAllAreasQuery, IList<Area>> getAllAreasQuery)
        {
            _getAllAreasQuery = getAllAreasQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAreas()
        {
            IList<Area> areas = await _getAllAreasQuery.HandleAsync(new GetAllAreasQuery());
            var areaResponse = areas.Select(x => new AreaResponseModel(x));

            return Ok(areaResponse);
        }
    }
}
