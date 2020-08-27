namespace OMSUbot.Vk.Api
{
    public struct Chat
    {

        public int Id;

        public Chat(int id)
        {
            Id = id;
        }

        public static Chat GetChatById(int id)
        {
            return new Chat(id);
        }
    }
}