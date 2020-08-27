using System;
using OMSUbot.Tools;
using OMSUbot.Vk.Api;
using OMSUbot.Commands;
using Json = OMSUbot.Tools.Json;

namespace OMSUbot
{
    public class Bot
    {

        private static Bot _instance;

        private CommandMap _commandMap;

        public readonly string Token;

        public Bot(string token)
        {
            Token = token;
            _commandMap = new CommandMap();
            RegisterCommands();
            _instance = this;
        }

        public CommandMap GetCommandMap()
        {
            return _commandMap;
        }

        private void RegisterCommands()
        {
            GetCommandMap().RegisterCommand(new HelpCommand());
        }

        public void SendMessage(User user, string message)
        {
            Curl.Curl2String("https://api.vk.com/method/messages.send?v=5.92&random_id=" + new Random().Next(Int32.MinValue, Int32.MaxValue) + "&access_token=" + Token + "&peer_id=" + user.Id + "&message=" + message);
        }
        
        public void SendMessage(Chat chat, string message)
        {
            Curl.Curl2String("https://api.vk.com/method/messages.send?v=5.92&random_id=" + new Random().Next(Int32.MinValue, Int32.MaxValue) + "&access_token=" + Token + "&peer_id=" + chat.Id + "&message=" + message);
        }
        
        public void SendMessage(User user, string message, Keyboard kb)
        {
            Curl.Curl2String("https://api.vk.com/method/messages.send?v=5.92&random_id=" + new Random().Next(Int32.MinValue, Int32.MaxValue) + "&access_token=" + Token + "&peer_id=" + user.Id + "&keyboard=" + Json.Encode(kb.GetData()).Replace(",null", "") + "&message=" + message);
        }
        
        public void SendMessage(Chat chat, string message, Keyboard kb)
        {
            Curl.Curl2String("https://api.vk.com/method/messages.send?v=5.92&random_id=" + new Random().Next(Int32.MinValue, Int32.MaxValue) + "&access_token=" + Token + "&peer_id=" + chat.Id + "&keyboard=" + Json.Encode(kb.GetData()).Replace(",null", "") + "&message=" + message);
        }

        public string GetToken()
        {
            return Token;
        }

        public static Bot GetInstance()
        {
            return _instance;
        }
    }
}