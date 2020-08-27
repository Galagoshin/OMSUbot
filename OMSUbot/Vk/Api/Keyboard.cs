using OMSUbot.Tools;

namespace OMSUbot.Vk.Api
{
    public class Keyboard
    {

        private dynamic settings;

        public Keyboard()
        {
            settings = new System.Dynamic.ExpandoObject();
            settings.one_time = false;
            settings.buttons = new dynamic[10];
        }
        
        public static Keyboard GenerateKeyboard()
        {
            Keyboard kb = new Keyboard();
            return kb;
        }

        public dynamic GetData()
        {
            return settings;
        }

        public Keyboard AddButton(Button button)
        {
            if (settings.buttons[button.Row] == null)
                settings.buttons[button.Row] = new dynamic[10];
            settings.buttons[button.Row][button.Column] = new System.Dynamic.ExpandoObject();
            settings.buttons[button.Row][button.Column].color = button.Collor;
            settings.buttons[button.Row][button.Column].action = new System.Dynamic.ExpandoObject();
            settings.buttons[button.Row][button.Column].action.type = button.Type;
            settings.buttons[button.Row][button.Column].action.label = button.Text;
            settings.buttons[button.Row][button.Column].action.payload = button.Command;
            return this;
        }
    }

    public struct Button
    {
        public string Collor;
        public string Type;
        public string Text;
        public string Command;
        public int Row;
        public int Column;

        public const string ColorWhite = "secondary";
        public const string ColorBlue = "primary";
        public const string ColorGreen = "positive";
        public const string ColorRed = "negative";

        public Button(KeyboardType type, Color color, string text, string payload, int row, int column)
        {
            switch (color)
            {
                case Color.Blue:
                    Collor = ColorBlue;
                    break;
                case Color.Green:
                    Collor = ColorGreen;
                    break;
                case Color.Red:
                    Collor = ColorRed;
                    break;
                case Color.White:
                    Collor = ColorWhite;
                    break;
                default:
                    Collor = ColorBlue;
                    break;
            }
            switch (type)
            {
                case KeyboardType.Text:
                    Type = "text";
                    break;
                /* not supported yet */
                /*case KeyboardType.VkPay:
                    Type = "vk pay";
                    break;
                case KeyboardType.Location:
                    Type = "location";
                    break;*/
                default:
                    Type = "text";
                    break;
            }
            Text = text;
            Command = "{\"command\":\"" + payload + "\"}";
            Row = row;
            Column = column;
        }
    }

    public enum Color { White, Blue, Green, Red }
    
    public enum KeyboardType { Text, Location, VkPay }
}