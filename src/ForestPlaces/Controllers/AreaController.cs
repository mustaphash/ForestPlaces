using Core.Commands;
using Core.Entities;
using Core.Queries;
using DAL.Commands.AreaCommands;
using DAL.Commands.PlaceCommands;
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
        private readonly ICommandHandler<CreateAreaCommand> _createAreaCommand;
        private readonly ICommandHandler<DeleteAreaCommand> _deleteAreaCommand;
        private readonly ICommandHandler<CreatePlaceCommand> _cratePlaceCommand;

        public AreaController(
            IQueryHandler<GetAllAreasQuery, IList<Area>> getAllAreasQuery,
            ICommandHandler<CreateAreaCommand> createAreaCommand,
            ICommandHandler<DeleteAreaCommand> deleteAreaCommand,
            ICommandHandler<CreatePlaceCommand> cratePlaceCommand)
        {
            _getAllAreasQuery = getAllAreasQuery;
            _createAreaCommand = createAreaCommand;
            _deleteAreaCommand = deleteAreaCommand;
            _cratePlaceCommand = cratePlaceCommand;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAreas()
        {
            IList<Area> areas = await _getAllAreasQuery.HandleAsync(new GetAllAreasQuery());
            var areaResponse = areas.Select(x => new AreaResponseModel(x));

            return Ok(areaResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArea(CreateAreaModel model)
        {
            var area = model.ToArea();
            await _createAreaCommand.HandleAsync(new CreateAreaCommand(area));

            return NoContent();
        }

        [HttpPost("place")]
        public async Task<IActionResult> CratePlace(CreatePlaceModel model)
        {
            var place = model.ToPlace();
            await _cratePlaceCommand.HandleAsync(new CreatePlaceCommand(model.AreaId, place));

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteArea(int id)
        {
            await _deleteAreaCommand.HandleAsync(new DeleteAreaCommand(id));

            return NoContent();
        }
    }
}
