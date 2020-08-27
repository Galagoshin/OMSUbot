using OMSUbot.Vk.Api;

namespace OMSUbot.Commands
{
    public interface ICommand
    {
        void Execute(User user);
        void Execute(Chat chat, User user);
        string GetName();
    }

    abstract public class Command: ICommand
    {
        public string Name;
        
        public Command(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        abstract public void Execute(User user);

        abstract public void Execute(Chat chat, User user);
    }
}