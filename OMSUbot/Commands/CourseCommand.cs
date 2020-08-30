using System;
using OMSUbot.Tools;
using OMSUbot.Vk.Api;

namespace OMSUbot.Commands
{
    public class CourseCommand: Command
    {

        public CourseCommand() : base("course", new []{"1", "2", "3", "4", "5"}){}

        public override void Execute(Chat chat, User user, Data data)
        {
            if (!user.HaveAuth())
            {
                user.RemoveAuth();
                user.RemoveData();
            }
            if (Strings.IsNumeric(data.Message))
            {
                user.SetAuthCourse(Int32.Parse(data.Message));
            }else if (Strings.IsNumeric(data.CommandArgs[1]))
            {
                user.SetAuthCourse(Int32.Parse(data.CommandArgs[1]));
            }else return;
            Bot.GetInstance().SendMessage(user, "Выбери группу.");
        }
        
        public override void Execute(User user, Data data)
        {
            
        }
    }
}