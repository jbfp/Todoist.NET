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

        internal TimeZoneOffset()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gmtValue"></param>
        /// <param name="hourOffset"></param>
        /// <param name="minuteOffset"></param>
        /// <param name="isDaylightSavingsTime"></param>
        public TimeZoneOffset(string gmtValue,
                              int hourOffset,
                              int minuteOffset,
                              bool isDaylightSavingsTime)
        {
            GmtString = gmtValue;
            HourOffset = hourOffset;
            MinuteOffset = minuteOffset;
            IsDaylightSavingsTime = isDaylightSavingsTime;
        }
    }
}
