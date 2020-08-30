using System;
using OMSUbot.Tools;

namespace OMSUbot.Commands
{
    public class CommandMap : Map<string, Command>
    {

        public void RegisterCommand(Command cmd)
        {
            foreach (var aliase in cmd.Aliases)
            {
                Add(aliase, cmd);
            }
            Add(cmd.GetName(), cmd);
        }

        public bool ExistsCommand(string name, string arg0)
        {
            return Contains(name) || Contains(arg0);
        }

        public Command GetCommand(string name, string arg0)
        {
            return Contains(name) ? Get(name) : Get(arg0);
        }
    }
}