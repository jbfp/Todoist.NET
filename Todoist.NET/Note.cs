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
    /// Todoist.com Note type.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Note content.
        /// </summary>
        private readonly string content;

        /// <summary>
        /// Unique note id.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Id of the item the note belongs to.
        /// </summary>
        private readonly int itemId;

        /// <summary>
        /// The JSON data for the note.
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
        /// Gets the id of the note.
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the id of the item the note belongs to.
        /// </summary>
        public int ItemId
        {
            get { return this.itemId; }
        }

        /// <summary>
        /// Gets the content/text of the note.
        /// </summary>
        public string Content
        {
            get { return this.content; }
        }

        /// <summary>
        /// Gets the JSON data for the note.
        /// </summary>
        public string JsonData
        {
            get { return this.jsonData; }
        }
    }
}