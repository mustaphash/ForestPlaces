using Core.Commands;

namespace DAL.Commands.AreaCommands
{
    public class DeleteAreaCommand : ICommand
    {
        public DeleteAreaCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
