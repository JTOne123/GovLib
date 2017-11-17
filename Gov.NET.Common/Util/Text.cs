using System.Linq;

namespace Gov.NET.Util
{
    public static class Text
    {
        public static string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            return str.First().ToString().ToUpper() + str.Substring(1);
        }

        public static string Ordinal(int num)
        {
            if (num >= 10 && num < 21) return num + "th";
            return num + GetEnd(num);
        }

        private static string GetEnd(int num)
        {
            string answer;
            switch (num)
            {
                case 1:
                    answer = "st";
                    break;
                case 2:
                    answer = "nd";
                    break;
                case 3:
                    answer = "rd";
                    break;
                default:
                    answer = "th";
                    break;
            }
            return answer;
        }
        }
}