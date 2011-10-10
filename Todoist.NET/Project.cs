// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the Project type.
// </summary>
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
            if (this.name[0] == '*')
            {
                this.name = this.name.Remove(0, 1);
                this.isGroup = true;
            }
            else
            {
                this.isGroup = false;
            }

            this.indent = (int)o.SelectToken("indent");
            this.cacheCount = (int)o.SelectToken("cache_count");
            this.id = (int)o.SelectToken("id");
            this.itemOrder = (int)o.SelectToken("item_order");
            this.isSubProjectsCollapsed = (int)o.SelectToken("collapsed");

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
        /// Gets the amount of tasks in the project.
        /// </summary>
        public int CacheCount
        {
            get
            {
                return this.cacheCount;
            }
        }

        /// <summary>
        /// Gets the color-label of the project.
        /// </summary>
        public Color Color
        {
            get
            {
                return this.color;
            }
        }

        /// <summary>
        /// Gets the unique project id.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the indent-level.
        /// </summary>
        public int Indent
        {
            get
            {
                return this.indent;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the project is a group or not.
        /// </summary>
        public bool IsGroup
        {
            get
            {
                return this.isGroup;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the project is collapsed, hiding subprojects.
        /// </summary>
        public bool IsSubprojectsCollapsed
        {
            get
            {
                return this.isSubProjectsCollapsed == 1;
            }
        }

        /// <summary>
        /// Gets the weight in the ordering of the items.
        /// </summary>
        public int ItemOrder
        {
            get
            {
                return this.itemOrder;
            }
        }

        /// <summary>
        /// Gets the JSON data of the project.
        /// </summary>
        public string JsonData
        {
            get
            {
                return this.jsonData;
            }
        }

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the id of the user who owns the project.
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