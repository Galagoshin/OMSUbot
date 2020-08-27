using Newtonsoft.Json;

namespace OMSUbot.Tools
{
    public static partial class Json
    {
        public static dynamic Decode(string value)
        {
            return JsonConvert.DeserializeObject(value);
        }

        public static string Encode(dynamic array)
        {
            return JsonConvert.SerializeObject(array);
        }
    }
}