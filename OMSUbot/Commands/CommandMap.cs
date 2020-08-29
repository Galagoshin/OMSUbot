using OMSUbot.Tools;

namespace OMSUbot.Commands
{
    public class CommandMap: Map<string, Command>
    {

        public void RegisterCommand(Command cmd)
        {
            Add(cmd.GetName(), cmd);
        }

        public Command GetCommand(string name)
        {
            return Get(name);
        }
    }
}