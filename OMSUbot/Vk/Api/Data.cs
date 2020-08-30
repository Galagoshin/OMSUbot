namespace OMSUbot.Vk.Api
{
    public struct Data
    {
        public string Message;
        public string Command;
        public string[] Args;
        public string[] CommandArgs;

        public Data(string message, string command)
        {
            Message = message;
            Command = command;
            Args = Message.Split(' ');
            CommandArgs = Command.Split(' ');
        }
    }
}