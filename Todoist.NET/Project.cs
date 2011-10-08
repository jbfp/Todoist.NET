// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The project.
    /// </summary>
    public class Project
    {
        #region Constants and Fields

        /// <summary>
        /// The cache count.
        /// </summary>
        private readonly int cacheCount;

        /// <summary>
        /// The color.
        /// </summary>
        private readonly Color color;

        /// <summary>
        /// The id.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// The indent.
        /// </summary>
        private readonly int indent;

        /// <summary>
        /// The is group.
        /// </summary>
        private readonly bool isGroup;

        /// <summary>
        /// The is sub projects collapsed.
        /// </summary>
        private readonly int isSubProjectsCollapsed;

        /// <summary>
        /// The item order.
        /// </summary>
        private readonly int itemOrder;

        /// <summary>
        /// The json data.
        /// </summary>
        private readonly string jsonData;

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The owner id.
        /// </summary>
        private readonly int ownerId;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        /// <param name="jsonData">
        /// The JSON data.
        /// </param>
        internal Project(string jsonData)
        {
            JObject o = JObject.Parse(jsonData);

            this.ownerId = (int)o.SelectToken("user_id");
            this.name = (string)o.SelectToken("name");
            this.indent = (int)o.SelectToken("indent");
            this.cacheCount = (int)o.SelectToken("cache_count");
            this.id = (int)o.SelectToken("id");
            this.itemOrder = (int)o.SelectToken("item_order");
            this.isSubProjectsCollapsed = (int)o.SelectToken("collapsed");
            this.isGroup = this.name[0] == '*';

            switch ((string)o.SelectToken("color"))
            {
                case "#bde876":
                    this.color = new Color(TodoistColor.Green);
                    break;
                case "#ff8581":
                    this.color = new Color(TodoistColor.Red);
                    break;
                case "#ffc472":
                    this.color = new Color(TodoistColor.Orange);
                    break;
                case "#faed75":
                    this.color = new Color(TodoistColor.Yellow);
                    break;
                case "#a8c9e5":
                    this.color = new Color(TodoistColor.Blue);
                    break;
                case "#999999":
                    this.color = new Color(TodoistColor.MediumGrey);
                    break;
                case "#e3a8e5":
                    this.color = new Color(TodoistColor.Pink);
                    break;
                case "#dddddd":
                    this.color = new Color(TodoistColor.LightGrey);
                    break;
                case "#fc603c":
                    this.color = new Color(TodoistColor.Flame);
                    break;
                case "#ffcc00":
                    this.color = new Color(TodoistColor.Gold);
                    break;
                case "#74e8d4":
                    this.color = new Color(TodoistColor.LightOpal);
                    break;
                case "#3cd6fc":
                    this.color = new Color(TodoistColor.BrilliantCerulean);
                    break;
            }

            this.jsonData = jsonData;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The cache count.
        /// </summary>
        public int CacheCount
        {
            get
            {
                return this.cacheCount;
            }
        }

        /// <summary>
        /// The color.
        /// </summary>
        public Color Color
        {
            get
            {
                return this.color;
            }
        }

        /// <summary>
        /// The id.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// The indent.
        /// </summary>
        public int Indent
        {
            get
            {
                return this.indent;
            }
        }

        /// <summary>
        /// The is group.
        /// </summary>
        public bool IsGroup
        {
            get
            {
                return this.isGroup;
            }
        }

        /// <summary>
        /// The is subprojects collapsed.
        /// </summary>
        public bool IsSubprojectsCollapsed
        {
            get
            {
                return this.isSubProjectsCollapsed == 1;
            }
        }

        /// <summary>
        /// The item order.
        /// </summary>
        public int ItemOrder
        {
            get
            {
                return this.itemOrder;
            }
        }

        /// <summary>
        /// The json data.
        /// </summary>
        public string JsonData
        {
            get
            {
                return this.jsonData;
            }
        }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// The owner id.
        /// </summary>
        public int OwnerId
        {
            get
            {
                return this.ownerId;
            }
        }

        #endregion
    }
}