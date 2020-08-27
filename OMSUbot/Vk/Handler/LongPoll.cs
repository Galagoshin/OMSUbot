using System;
using System.Collections.Generic;
using OMSUbot.Tools;
using OMSUbot.Vk.Api;

namespace OMSUbot.Vk.Handler
{
    public class LongPoll : IHandler
    {

        private string server;
        private string key;
        private int ts;

        private readonly int group_id;

        public LongPoll(int group_id)
        {
            var json = Curl.Curl2Json("https://api.vk.com/method/groups.getLongPollServer?group_id=" + group_id + "&v=5.92&access_token=" + Bot.GetInstance().GetToken());
            server = json.response.server;
            key = json.response.key;
            ts = json.response.ts;
            this.group_id = group_id;
        }

        public void Start()
        {
            while (true)
                Handle();
        }

        public void Handle()
        {
            foreach (var msg in GetMessages())
            {
                string payload = string.Empty;
                if (msg["payload"] != null)
                {
                    payload = msg.payload;
                    payload = payload.Split(':')[1].Split('\"')[1];
                }

                if ((int) msg.peer_id == 2000000002)
                {
                    Respondent.ChatRespond(Chat.GetChatById((int) msg.peer_id), User.GetUserById((int)msg.from_id), new Data((string) msg.text, payload));
                }
                else
                {
                    Respondent.PersonalRespond(User.GetUserById((int)msg.from_id), new Data((string) msg.text, payload));
                }
            }
        }

        private dynamic GetEvents()
        {
            return Curl.Curl2Json(server + "?act=a_check&key=" + key + "&ts=" + ts + "&wait=25");
        }

        private List<dynamic> GetMessages()
        {
            var events = GetEvents();
            List<dynamic> messages = new List<dynamic>();
            foreach (var event2 in events.updates)
            {
                if (event2.type == "message_new")
                {
                    messages.Add(event2["object"]);
                }
            }
            ts = events.ts;
            return messages;
        }
    }
}