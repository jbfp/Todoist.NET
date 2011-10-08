#region License

// Copyright (c) 2011 Jakob Pedersen
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Todoist.NET
{
    /// <summary>
    /// 
    /// </summary>
    public enum TodoistColor
    {
        /// <summary>
        /// 
        /// </summary>
        Green = 0,
        /// <summary>
        /// 
        /// </summary>
        Red = 1,
        /// <summary>
        /// 
        /// </summary>
        Orange = 2,
        /// <summary>
        /// 
        /// </summary>
        Yellow = 3,
        /// <summary>
        /// 
        /// </summary>
        Blue = 4,
        /// <summary>
        /// 
        /// </summary>
        MediumGrey = 5,
        /// <summary>
        /// 
        /// </summary>
        Pink = 6,
        /// <summary>
        /// 
        /// </summary>
        LightGrey = 7,
        /// <summary>
        /// 
        /// </summary>
        Flame = 8,
        /// <summary>
        /// 
        /// </summary>
        Gold = 9,
        /// <summary>
        /// 
        /// </summary>
        LightOpal = 10,
        /// <summary>
        /// 
        /// </summary>
        BrilliantCerulean = 11
    }

    /// <summary>
    /// 
    /// </summary>
    public class Color
    {
        private readonly string _htmlColor;
        private readonly System.Drawing.Color _rgb;

        private readonly TodoistColor _todoistColor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="todoistColor"></param>
        public Color(TodoistColor todoistColor)
        {
            _todoistColor = todoistColor;
            _htmlColor = ConvertTodoistColorToString(TodoistColor);
            _rgb = ConvertStringToColor(_htmlColor);
        }

        /// <summary>
        /// 
        /// </summary>
        public TodoistColor TodoistColor
        {
            get { return _todoistColor; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HtmlColor
        {
            get { return _htmlColor; }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Drawing.Color Rgb
        {
            get { return _rgb; }
        }

        private static string ConvertTodoistColorToString(TodoistColor todoistColor)
        {
            switch (todoistColor)
            {
                case TodoistColor.Green:
                    return "bde876";
                case TodoistColor.Red:
                    return "ff8581";
                case TodoistColor.Orange:
                    return "ffc472";
                case TodoistColor.Yellow:
                    return "faed75";
                case TodoistColor.Blue:
                    return "a8c9e5";
                case TodoistColor.MediumGrey:
                    return "999999";
                case TodoistColor.Pink:
                    return "e3a8e5";
                case TodoistColor.LightGrey:
                    return "dddddd";
                case TodoistColor.Flame:
                    return "fc603c";
                case TodoistColor.Gold:
                    return "ffcc00";
                case TodoistColor.LightOpal:
                    return "74e8d4";
                case TodoistColor.BrilliantCerulean:
                    return "3cd6fc";
            }

            throw new InvalidEnumArgumentException("The color selected is not a valid color.");
        }

        /// <summary>
        /// Convert a hex string to a .NET Color object.
        /// </summary>
        /// <param name="htmlColor">A hex string: "FFFFFF", "#000000"</param>
        private static System.Drawing.Color ConvertStringToColor(string htmlColor)
        {
            string hc = ExtractHexDigits(htmlColor);
            if (hc.Length != 6)
            {
                // you can choose whether to throw an exception
                //throw new ArgumentException("hexColor is not exactly 6 digits.");
                return System.Drawing.Color.Empty;
            }
            string r = hc.Substring(0, 2);
            string g = hc.Substring(2, 2);
            string b = hc.Substring(4, 2);
            System.Drawing.Color color;
            try
            {
                int ri
                    = Int32.Parse(r, NumberStyles.HexNumber);
                int gi
                    = Int32.Parse(g, NumberStyles.HexNumber);
                int bi
                    = Int32.Parse(b, NumberStyles.HexNumber);
                color = System.Drawing.Color.FromArgb(ri, gi, bi);
            }
            catch (FormatException)
            {
                // you can choose whether to throw an exception
                //throw new ArgumentException("Conversion failed.");
                return System.Drawing.Color.Empty;
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