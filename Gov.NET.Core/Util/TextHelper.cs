using System.Linq;

namespace Gov.NET.Util
{
    /// <summary>Small text utility helper class.</summary>
    public static class TextHelper
    {
        /// <summary>Capitalize the given word.</summary>
        public static string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return $"{str.Substring(0, 1).ToUpper()} {str.Substring(1)}";
        }

        /// <summary>Attach an ordinal to the given number.</summary>
        public static string Ordinal(int num)
        {
            if (num >= 10 && num < 21) return $"{num}th";
            return $"{num}{GetEnd(num)}";
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