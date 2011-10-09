// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//    Defines the Item type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Todoist.com task (or "item" as it is referred to in the API).
    /// </summary>
    public class Item
    {
        #region Constants and Fields

        /// <summary>
        /// Task text.
        /// </summary>
        private readonly string content;

        /// <summary>
        /// The raw string of the due date.
        /// </summary>
        private readonly string dateString;

        /// <summary>
        /// The next due date.
        /// </summary>
        private readonly string dueDate;

        /// <summary>
        /// Task's unique id.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Task's indent level.
        /// </summary>
        private readonly int indent;

        /// <summary>
        /// True if the task has been 'checked' on the website, which usually means it has been completed.
        /// </summary>
        private readonly bool isChecked;

        /// <summary>
        /// True if the task has been put in the history, which usually means it has been completed.
        /// </summary>
        private readonly bool isInHistory;

        /// <summary>
        /// Are the subtasks collapsed.
        /// </summary>
        private readonly bool isSubTasksCollapsed;

        /// <summary>
        /// Task's weight in the order of tasks.
        /// </summary>
        private readonly int itemOrder;

        /// <summary>
        /// The JSON data of the task.
        /// </summary>
        private readonly string jsonData;

        /// <summary>
        /// The id of the user who owns the task.
        /// </summary>
        private readonly int ownerId;

        /// <summary>
        /// The priority of the task.
        /// </summary>
        private readonly int priority;

        /// <summary>
        /// The id of the project the task belongs to.
        /// </summary>
        private readonly int projectId;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class. 
        /// </summary>
        /// <param name="jsonData">
        /// A task's JSON data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="jsonData"/> is null.
        /// </exception>
        public Item(string jsonData)
        {
            JObject o = JObject.Parse(jsonData);

            if (o.First == null)
            {
                throw new ArgumentNullException(jsonData);
            }

            this.id = (int)o.SelectToken("id");
            this.ownerId = (int)o.SelectToken("user_id");
            this.isSubTasksCollapsed = Convert.ToBoolean((int)o.SelectToken("collapsed"));
            this.isInHistory = Convert.ToBoolean((int)o.SelectToken("in_history"));
            this.priority = (int)o.SelectToken("priority");
            this.itemOrder = (int)o.SelectToken("item_order");
            this.content = (string)o.SelectToken("content");
            this.indent = (int)o.SelectToken("indent");
            this.projectId = (int)o.SelectToken("project_id");
            this.isChecked = Convert.ToBoolean((int)o.SelectToken("checked"));
            this.dateString = (string)o.SelectToken("date_string");
            this.dueDate = (string)o.SelectToken("due_date");
            this.jsonData = jsonData;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the text of the task.
        /// </summary>
        public string Content
        {
            get
            {
                return this.content;
            }
        }

        /// <summary>  
        /// Gets the raw string of the due date.
        /// </summary>
        public string DateString
        {
            get
            {
                return this.dateString;
            }
        }

        /// <summary>
        /// Gets the next due date.
        /// </summary>
        public string DueDate
        {
            get
            {
                return this.dueDate;
            }
        }

        /// <summary>
        /// Gets the unique id of the task.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the indent level of the task.
        /// </summary>
        public int Indent
        {
            get
            {
                return this.indent;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the task is checked (is completed) or not.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return this.isChecked;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the task is in the history (is completed) or not.
        /// </summary>
        public bool IsInHistory
        {
            get
            {
                return this.isInHistory;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the subtasks are collapsed or not.
        /// </summary>
        public bool IsSubtasksCollapsed
        {
            get
            {
                return this.isSubTasksCollapsed;
            }
        }

        /// <summary>
        /// Gets the task weight in the order of tasks.
        /// </summary>
        public int ItemOrder
        {
            get
            {
                return this.itemOrder;
            }
        }

        /// <summary>
        /// Gets a string of JSON data.
        /// </summary>
        public string JsonData
        {
            get
            {
                return this.jsonData;
            }
        }

        /// <summary>
        /// Gets the id of the user who owns the task.
        /// </summary>
        public int OwnerId
        {
            get
            {
                return this.ownerId;
            }
        }

        /// <summary>
        /// Gets the task priority.
        /// </summary>
        public int Priority
        {
            get
            {
                return this.priority;
            }
        }

        /// <summary>
        /// Gets the id of the project the task belongs to.
        /// </summary>
        public int ProjectId
        {
            get
            {
                return this.projectId;
            }
        }

        #endregion
    }
}