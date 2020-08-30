using System;
using OMSUbot.Vk.Api;

namespace OMSUbot.Commands
{
    public class StartCommand: Command
    {

        public StartCommand() : base("start", new []{"старт"}){}

        public override void Execute(Chat chat, User user, Data data)
        {
            
        }
        
        public override void Execute(User user, Data data)
        {
            user.RemoveAuth();
            user.RemoveData();
            user.CreateDataAuth();
            Bot.GetInstance().SendMessage(user, "Расписание ИМИТ\nLink: @galagoshin\nSourse: github.com/Galagoshin/OMSUbot\n\n Выбери курс.",
                Keyboard.GenerateKeyboard()
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "1", "course 1", 0, 0))
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "2", "course 2", 0, 1))
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "3", "course 3", 0, 2))
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "4", "course 4", 0, 3))
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "5", "course 5", 0, 4)));
        }
    }
}