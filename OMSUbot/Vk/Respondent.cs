using OMSUbot.Vk.Api;
using OMSUbot.Commands;

namespace OMSUbot.Vk
{
    public static class Respondent
    {

        public static void PersonalRespond(User user, Data data)
        {
            Command cmd = Bot.GetInstance().GetCommandMap().GetCommand(data.Command);
            cmd.Execute(user);
        }

        public static void ChatRespond(Chat chat, User user, Data data)
        {
            Command cmd = Bot.GetInstance().GetCommandMap().GetCommand(data.Command);
            cmd.Execute(chat, user);
        }
    }
}