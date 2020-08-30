using OMSUbot.Vk.Api;

namespace OMSUbot.Commands
{
    public interface ICommand
    {
        void Execute(User user, Data data);
        void Execute(Chat chat, User user, Data data);
        string GetName();
    }

    abstract public class Command: ICommand
    {
        public string Name;
        public string[] Aliases;
        
        public Command(string name, string[] aliases)
        {
            Name = name;
            Aliases = aliases;
        }

        public string GetName()
        {
            return Name;
        }
        
        public string[] GetAliases()
        {
            return Aliases;
        }

        abstract public void Execute(User user, Data data);

        abstract public void Execute(Chat chat, User user, Data data);
    }
}