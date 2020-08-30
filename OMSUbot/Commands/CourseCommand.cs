using System;
using OMSUbot.Tools;
using OMSUbot.Vk.Api;

namespace OMSUbot.Commands
{
    public class CourseCommand: Command
    {

        public CourseCommand() : base("course", new []{"1", "2", "3", "4", "5"}){}

        public override void Execute(User user, Data data)
        {
            if (!user.HaveAuth())
            {
                user.RemoveAuth();
                user.RemoveData();
                return;
            }
            if (Strings.IsNumeric(data.Message))
            {
                user.SetAuthCourse(Int32.Parse(data.Message));
            }else if (Strings.IsNumeric(data.CommandArgs[1]))
            {
                user.SetAuthCourse(Int32.Parse(data.CommandArgs[1]));
            }else return;
            Keyboard kbrd = Keyboard.GenerateKeyboard();
            int
                course = user.GetAuthCourse(),
                row = 0,
                column = 0;
            string msg = String.Empty;
            for (int id = 0; id < 6; id++)
            {
                string group = Groups.GROUPS[course - 1, id];
                if (!String.IsNullOrEmpty(group))
                {
                    kbrd.AddButton(new Button(KeyboardType.Text, Color.Blue, group, "group " + id, row, column));
                    msg += group + "\n";
                    if (column == 1)
                    {
                        column = 0;
                        row++;
                    }
                    else column++;
                }
            }
            Bot.GetInstance().SendMessage(user, "Выбери группу.\n\n" + msg, kbrd);
        }
        
        public override void Execute(Chat chat, User user, Data data)
        {
            
        }
    }
}