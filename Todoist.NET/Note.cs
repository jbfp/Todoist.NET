// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Note.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the Note type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class Note
    {
        /// <summary>
        /// </summary>
        private readonly string content;

        /// <summary>
        /// </summary>
        private readonly int id;

        /// <summary>
        /// </summary>
        private readonly int itemId;

        /// <summary>
        /// </summary>
        private readonly string jsonData;

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        /// <param name="jsonData">
        /// The json data.
        /// </param>
        internal Note(string jsonData)
        {
            JArray o = JArray.Parse(jsonData);

            this.id = (int)o.SelectToken("id");
            this.itemId = (int)o.SelectToken("item_id");
            this.content = (string)o.SelectToken("content");

            this.jsonData = jsonData;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ItemId
        {
            get { return this.itemId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get { return this.content; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string JsonData
        {
            get { return this.jsonData; }
        }
    }
}