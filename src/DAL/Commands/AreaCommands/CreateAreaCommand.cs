using Core.Commands;
using Core.Entities;

namespace DAL.Commands.AreaCommands
{
    public class CreateAreaCommand : ICommand
    {
        public CreateAreaCommand(Area area)
        {
            Area = area;
        }
        public Area Area { get; set; }
    }
}
