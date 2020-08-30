using System;

namespace OMSUbot.Tools
{
    public class Strings
    {

        public static bool IsNumeric(string str)
        {
            try
            {
                Int32.Parse(str);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}