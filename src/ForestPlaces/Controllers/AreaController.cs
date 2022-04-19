using Core.Commands;
using Core.Entities;
using Core.Queries;
using DAL.Commands.AreaCommands;
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

        public AreaController(
            IQueryHandler<GetAllAreasQuery, IList<Area>> getAllAreasQuery,
            ICommandHandler<CreateAreaCommand> createAreaCommand,
            ICommandHandler<DeleteAreaCommand> deleteAreaCommand)
        {
            _getAllAreasQuery = getAllAreasQuery;
            _createAreaCommand = createAreaCommand;
            _deleteAreaCommand = deleteAreaCommand;
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

        [HttpDelete]
        public async Task<IActionResult> DeleteArea(int id)
        {
            await _deleteAreaCommand.HandleAsync(new DeleteAreaCommand(id));

            return NoContent();
        }
    }
}
