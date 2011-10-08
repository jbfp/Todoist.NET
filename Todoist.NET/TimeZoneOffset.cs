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
    /// 
    /// </summary>
    public class TimeZoneOffset
    {
        /// <summary>
        /// 
        /// </summary>
        public string GmtString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int HourOffset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDaylightSavingsTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MinuteOffset { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeZoneOffset"/> class.
        /// </summary>
        internal TimeZoneOffset()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeZoneOffset"/> class. 
        /// </summary>
        /// <param name="gmtValue">
        /// </param>
        /// <param name="hourOffset">
        /// </param>
        /// <param name="minuteOffset">
        /// </param>
        /// <param name="isDaylightSavingsTime">
        /// </param>
        public TimeZoneOffset(
            string gmtValue,
            int hourOffset,
            int minuteOffset,
            bool isDaylightSavingsTime)
        {
            this.GmtString = gmtValue;
            this.HourOffset = hourOffset;
            this.MinuteOffset = minuteOffset;
            this.IsDaylightSavingsTime = isDaylightSavingsTime;
        }
    }
}
