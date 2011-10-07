using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace TodoistDotNet
{
    public enum TodoistColorEnum
    {
        Green = 0,
        Red = 1,
        Orange = 2,
        Yellow = 3,
        Blue = 4,
        MediumGrey = 5,
        Pink = 6,
        LightGrey = 7,
        Flame = 8,
        Gold = 9,
        LightOpal = 10,
        BrilliantCerulean = 11
    }

    public class TodoistColor
    {
        private readonly Color _rgb;
        private readonly string _htmlColor;

        public TodoistColor(TodoistColorEnum todoistColor)
        {
            TodoistColorEnum = todoistColor;
            _htmlColor = ConvertTodoistColorToString(TodoistColorEnum);
            _rgb = ConvertStringToColor(_htmlColor);
        }

        public TodoistColorEnum TodoistColorEnum { get; set; }

        public string HtmlColor
        {
            get { return _htmlColor; }
        }

        public Color RGB
        {
            get { return _rgb; }
        }

        private static string ConvertTodoistColorToString(TodoistColorEnum todoistColor)
        {
            switch (todoistColor)
            {
                case TodoistColorEnum.Green:
                    return "bde876";
                case TodoistColorEnum.Red:
                    return "ff8581";
                case TodoistColorEnum.Orange:
                    return "ffc472";
                case TodoistColorEnum.Yellow:
                    return "faed75";
                case TodoistColorEnum.Blue:
                    return "a8c9e5";
                case TodoistColorEnum.MediumGrey:
                    return "999999";
                case TodoistColorEnum.Pink:
                    return "e3a8e5";
                case TodoistColorEnum.LightGrey:
                    return "dddddd";
                case TodoistColorEnum.Flame:
                    return "fc603c";
                case TodoistColorEnum.Gold:
                    return "ffcc00";
                case TodoistColorEnum.LightOpal:
                    return "74e8d4";
                case TodoistColorEnum.BrilliantCerulean:
                    return "3cd6fc";
            }

            throw new InvalidEnumArgumentException("The color selected is not a valid color.");
        }

        /// <summary>
        /// Convert a hex string to a .NET Color object.
        /// </summary>
        /// <param name="htmlColor">A hex string: "FFFFFF", "#000000"</param>
        private static Color ConvertStringToColor(string htmlColor)
        {
            string hc = ExtractHexDigits(htmlColor);
            if (hc.Length != 6)
            {
                // you can choose whether to throw an exception
                //throw new ArgumentException("hexColor is not exactly 6 digits.");
                return Color.Empty;
            }
            string r = hc.Substring(0, 2);
            string g = hc.Substring(2, 2);
            string b = hc.Substring(4, 2);
            Color color;
            try
            {
                int ri
                    = Int32.Parse(r, NumberStyles.HexNumber);
                int gi
                    = Int32.Parse(g, NumberStyles.HexNumber);
                int bi
                    = Int32.Parse(b, NumberStyles.HexNumber);
                color = Color.FromArgb(ri, gi, bi);
            }
            catch
            {
                // you can choose whether to throw an exception
                //throw new ArgumentException("Conversion failed.");
                return Color.Empty;
            }
            return color;
        }

        /// <summary>
        /// Extract only the hex digits from a string.
        /// </summary>
        private static string ExtractHexDigits(string input)
        {
            // remove any characters that are not digits (like #)
            var isHexDigit
                = new Regex("[abcdefABCDEF\\d]+", RegexOptions.Compiled);
            return input.Where(c => isHexDigit.IsMatch(c.ToString()))
                .Aggregate("", (current, c) => current + c.ToString());
        }
    }
}