using OMSUbot.Vk.Api;

namespace OMSUbot.Commands
{
    public class HelpCommand: Command
    {

        public HelpCommand() : base("help"){}

        public override void Execute(Chat chat, User user)
        {
            Bot.GetInstance().SendMessage(chat, "test",
                Keyboard.GenerateKeyboard()
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "Кнопка", "cmd 1", 0, 0))
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "Кнопка 2", "cmd 2", 1, 0)));
        }
        
        public override void Execute(User user)
        {
            Bot.GetInstance().SendMessage(user,
                "test",
                Keyboard.GenerateKeyboard()
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "Кнопка", "cmd 1", 0, 0))
                    .AddButton(new Button(KeyboardType.Text, Color.Blue, "Кнопка 2", "cmd ", 1, 0)));
        }
    }
}
