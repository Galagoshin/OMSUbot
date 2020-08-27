using OMSUbot.Tools;

namespace OMSUbot.Vk.Api
{
    public struct User
    {

        public User(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.First_Name = firstName;
            this.Last_Name = lastName;
        }

        public int Id;
        public string First_Name;
        public string Last_Name;

        public static User GetUserById(int id)
        {
            var response = Curl.Curl2Json("https://api.vk.com/method/users.get?v=5.92&access_token=" + Bot.GetInstance().GetToken() + "&user_id=" + id);
            return new User(id, (string) response.response[0].first_name, (string) response.response[0].last_name);
        }
    }
}