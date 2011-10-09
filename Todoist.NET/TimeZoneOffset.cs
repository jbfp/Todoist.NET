// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeZoneOffset.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the TimeZoneOffset type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    /// <summary>
    /// The time zone offset.
    /// </summary>
    public class TimeZoneOffset
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeZoneOffset"/> class. 
        /// </summary>
        /// <param name="gmtValue">
        /// The GMT value in a string, e.g. "+01.00".
        /// </param>
        /// <param name="hourOffset">
        /// The hour offset in an int, e.g. 1.
        /// </param>
        /// <param name="minuteOffset">
        /// The minute offset in an int, e.g. 45.
        /// </param>
        /// <param name="isDaylightSavingsTime">
        /// True if it is daylight savings time.
        /// </param>
        public TimeZoneOffset(string gmtValue, int hourOffset, int minuteOffset, bool isDaylightSavingsTime)
        {
            this.GmtString = gmtValue;
            this.HourOffset = hourOffset;
            this.MinuteOffset = minuteOffset;
            this.IsDaylightSavingsTime = isDaylightSavingsTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeZoneOffset"/> class.
        /// </summary>
        internal TimeZoneOffset()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the GMT value in a string.
        /// </summary>
        public string GmtString { get; set; }

        /// <summary>
        /// Gets or sets the hour offset.
        /// </summary>
        public int HourOffset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is daylight savings time or not.
        /// </summary>
        public bool IsDaylightSavingsTime { get; set; }

        /// <summary>
        /// Gets or sets the minute offset.
        /// </summary>
        public int MinuteOffset { get; set; }

        #endregion
    }
}