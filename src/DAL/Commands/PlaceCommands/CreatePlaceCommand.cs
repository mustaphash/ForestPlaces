using Core.Commands;
using Core.Entities;

namespace DAL.Commands.PlaceCommands
{
    public class CreatePlaceCommand : ICommand
    {
        public CreatePlaceCommand(int id, Place place)
        {
            AreaId = id;
            Place = place;
        }
        public Place Place { get; set; }
        public int AreaId { get; set; }
    }
}
