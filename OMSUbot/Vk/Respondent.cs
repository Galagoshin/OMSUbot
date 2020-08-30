using System;
using OMSUbot.Vk.Api;
using OMSUbot.Commands;

namespace OMSUbot.Vk
{
    public static class Respondent
    {

        public static void PersonalRespond(User user, Data data)
        {
            Command cmd = null;
            if (!user.HaveAuth())
            {
                cmd = Bot.GetInstance().GetCommandMap().GetCommand("start", data.Args[0].ToLower());
            }
            else if (Bot.GetInstance().GetCommandMap().ExistsCommand(data.CommandArgs[0], data.Args[0].ToLower()))
            {
                cmd = Bot.GetInstance().GetCommandMap().GetCommand(data.CommandArgs[0], data.Args[0].ToLower());
            }
            else
            {
                Bot.GetInstance().SendMessage(user, "Команда не найдена.");
                return;
            }
            cmd.Execute(user, data);
        }

        public static void ChatRespond(Chat chat, User user, Data data)
        {
            Command cmd = Bot.GetInstance().GetCommandMap().GetCommand(data.CommandArgs[0], data.Args[0].ToLower());
            cmd.Execute(chat, user, data);
        }
    }
}