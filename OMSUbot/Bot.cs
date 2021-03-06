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
        private static DataBase db;
        
        public readonly string Token;

        public Bot(string token)
        {
            Token = token;
            _commandMap = new CommandMap();
            RegisterCommands();
            _instance = this;
            db = new DataBase("db.sqlite3");
            db.Execute("CREATE TABLE IF NOT EXISTS users (VkId INTEGER NOT NULL, Сourse INTEGER NOT NULL, GroupId INTEGER NOT NULL);");
            db.Execute("CREATE TABLE IF NOT EXISTS auth (VkId INTEGER NOT NULL, Course INTEGER NOT NULL);");
        }

        public static DataBase GetDataBase()
        {
            return db;
        }

        public CommandMap GetCommandMap()
        {
            return _commandMap;
        }

        private void RegisterCommands()
        {
            GetCommandMap().RegisterCommand(new HelpCommand());
            GetCommandMap().RegisterCommand(new StartCommand());
            GetCommandMap().RegisterCommand(new CourseCommand());
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
            Curl.Curl2String("https://api.vk.com/method/messages.send?v=5.92&random_id=" + new Random().Next(Int32.MinValue, Int32.MaxValue) + "&access_token=" + Token + "&peer_id=" + user.Id + "&keyboard=" + kb.GetData() + "&message=" + message);
        }
        
        public void SendMessage(Chat chat, string message, Keyboard kb)
        {
            Curl.Curl2String("https://api.vk.com/method/messages.send?v=5.92&random_id=" + new Random().Next(Int32.MinValue, Int32.MaxValue) + "&access_token=" + Token + "&peer_id=" + chat.Id + "&keyboard=" + kb.GetData() + "&message=" + message);
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