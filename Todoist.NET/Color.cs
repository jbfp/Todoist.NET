// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Color.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the Color type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Enum of the valid colors Todoist.com allows.
    /// </summary>
    public enum TodoistColor
    {
        /// <summary>
        /// Green #bde876
        /// </summary>
        Green = 0,

        /// <summary>
        /// Red #ff8581
        /// </summary>
        Red = 1,

        /// <summary>
        /// Orange #ffc472
        /// </summary>
        Orange = 2,

        /// <summary>
        /// Yellow #faed75
        /// </summary>
        Yellow = 3,

        /// <summary>
        /// Blue #a8c9e5
        /// </summary>
        Blue = 4,

        /// <summary>
        /// Medium grey #999999
        /// </summary>
        MediumGrey = 5,

        /// <summary>
        /// Pink #e3a8e5
        /// </summary>
        Pink = 6,

        /// <summary>
        /// Light grey #dddddd
        /// </summary>
        LightGrey = 7,

        /// <summary>
        /// Flame #fc603c
        /// </summary>
        Flame = 8,

        /// <summary>
        /// Gold #ffcc00
        /// </summary>
        Gold = 9,

        /// <summary>
        /// Light opal #74e8d4
        /// </summary>
        LightOpal = 10,

        /// <summary>
        /// Brilliant cerulean #3cd6fc
        /// </summary>
        BrilliantCerulean = 11
    }

    /// <summary>
    /// A necessary class, since Todoist.com only allows for 12 different colors 
    /// and is very inconsistent in the API, whether a hex string or 'id' is to be returned.
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Color in hex.
        /// </summary>
        private readonly string htmlColor;

        /// <summary>
        /// Color in <see cref="System.Drawing.Color"/>.
        /// </summary>
        private readonly System.Drawing.Color rgb;

        /// <summary>
        /// Color in <see cref="Color"/>.
        /// </summary>
        private readonly TodoistColor todoistColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> class.
        /// </summary>
        /// <param name="todoistColor">
        /// The <see cref="TodoistColor"/>.
        /// </param>
        public Color(TodoistColor todoistColor)
        {
            this.todoistColor = todoistColor;
            this.htmlColor = ConvertTodoistColorToString(TodoistColor);
            this.rgb = ConvertStringToColor(this.htmlColor);
        }

        /// <summary>
        /// Gets <see cref="todoistColor"/>.
        /// </summary>
        public TodoistColor TodoistColor
        {
            get { return this.todoistColor; }
        }

        /// <summary>
        /// Gets color in hex.
        /// </summary>
        public string HtmlColor
        {
            get { return this.htmlColor; }
        }

        /// <summary>
        /// Gets color in RGB.
        /// </summary>
        public System.Drawing.Color Rgb
        {
            get { return this.rgb; }
        }

        /// <summary>
        /// Converts <see cref="TodoistColor"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="todoistColor">
        /// The todoist color.
        /// </param>
        /// <returns>
        /// <see cref="TodoistColor"/> in <see cref="string"/>.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">Throws <see cref="InvalidEnumArgumentException"/> 
        /// if the parameter is not a valid color.</exception>
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
        /// <param name="htmlColor">
        /// A hex string: "FFFFFF", "#000000".
        /// </param>
        /// <returns>
        /// The convert string to color.
        /// </returns>
        private static System.Drawing.Color ConvertStringToColor(string htmlColor)
        {
            string hc = ExtractHexDigits(htmlColor);
            if (hc.Length != 6)
            {
                return System.Drawing.Color.Empty;
            }

            string r = hc.Substring(0, 2);
            string g = hc.Substring(2, 2);
            string b = hc.Substring(4, 2);
            System.Drawing.Color color;
            try
            {
                int ri
                    = int.Parse(r, NumberStyles.HexNumber);
                int gi
                    = int.Parse(g, NumberStyles.HexNumber);
                int bi
                    = int.Parse(b, NumberStyles.HexNumber);
                color = System.Drawing.Color.FromArgb(ri, gi, bi);
            }
            catch (FormatException)
            {
                return System.Drawing.Color.Empty;
            }

            return color;
        }

        /// <summary>
        /// Extract only the hex digits from a string.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The extracted hex digits.
        /// </returns>
        private static string ExtractHexDigits(string input)
        {
            // remove any characters that are not digits (like #)
            var isHexDigit
                = new Regex("[abcdefABCDEF\\d]+", RegexOptions.Compiled);
            return input.Where(c => isHexDigit.IsMatch(c.ToString()))
                .Aggregate(string.Empty, (current, c) => current + c.ToString());
        }
    }
}