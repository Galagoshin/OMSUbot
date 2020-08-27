namespace OMSUbot.Vk.Api
{
    public struct Data
    {
        public string Message;
        public string Command;

        public Data(string message, string command)
        {
            Message = message;
            Command = command;
        }
    }
}