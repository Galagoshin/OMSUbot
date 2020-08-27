using OMSUbot.Tools;

namespace OMSUbot.Commands
{
    public class CommandMap
    {
        private Map<string, Command> _commands;

        public CommandMap()
        {
            _commands = new Map<string, Command>();
        }

        public void RegisterCommand(Command cmd)
        {
            _commands.Add(cmd.GetName(), cmd);
        }

        public Command GetCommand(string name)
        {
            return _commands.Get(name);
        }
    }
}