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
        
        public void CreateDataAuth()
        {
            Bot.GetDataBase().Execute("INSERT INTO auth (VkId, Course) VALUES (" + Id + ", 0);");
        }
        
        public int GetAuthCourse()
        {
            return (int) Bot.GetDataBase().QueryInt("SELECT Course FROM auth WHERE VkId = " + Id);
        }
        
        public void SetAuthCourse(int step)
        {
            Bot.GetDataBase().Query("UPDATE auth SET Course = " + step + " WHERE VkId = " + Id);
        }
        
        public void RemoveAuth()
        {
            Bot.GetDataBase().Query("DELETE FROM auth WHERE VkId = " + Id);
        }
        
        public void RemoveData()
        {
            Bot.GetDataBase().Query("DELETE FROM users WHERE VkId = " + Id);
        }

        public bool HaveAuth()
        {
            return Bot.GetDataBase().Exists("SELECT Course FROM auth WHERE VkId = " + Id);
        }

        public void CreateData(int vkid, int course, int group)
        {
            Bot.GetDataBase().Execute("INSERT INTO users (VkId, Course, GroupId) VALUES (" + vkid + ", " + course + ", " + group + ");");
        }
    }
}