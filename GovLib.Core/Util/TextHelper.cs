using System.Linq;

namespace GovLib.Util
{
    /// <summary>Small text utility helper class.</summary>
    public static class TextHelper
    {
        /// <summary>Capitalize the given word.</summary>
        public static string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }

        /// <summary>Attach an ordinal to the given number.</summary>
        public static string Ordinal(int num)
        {
            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }
            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }
    }
}