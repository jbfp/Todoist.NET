// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net;
    using System.Text;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// User's startpage on Todoist.com.
    /// </summary>
    public enum StartPage
    {
        /// <summary>
        /// Info page.
        /// </summary>
        InfoPage, 

        /// <summary>
        /// Blank page.
        /// </summary>
        Blank, 

        /// <summary>
        /// Project of choice (NYI).
        /// </summary>
        ProjectX
    }

    /// <summary>
    /// User's time format, either 12-hour clock or 24-hour clock.
    /// </summary>
    public enum TimeFormat
    {
        /// <summary>
        /// 24-hour clock format, e.g. 13:00.
        /// </summary>
        TwentyFourHourClock = 0, 

        /// <summary>
        /// 12-hour clock format, e.g. 1 pm.
        /// </summary>
        TwelveHourClock = 1
    }

    /// <summary>
    /// The date format.
    /// </summary>
    public enum DateFormat
    {
        /// <summary>
        /// DD-MM-YYY date format.
        /// </summary>
        DdMmYyyy = 0, 

        /// <summary>
        /// MM-DD-YYY date format.
        /// </summary>
        MmDdYyyy = 1
    }

    /// <summary>
    /// When tasks are sorted by date, which tasks come first.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// Oldest tasks/items.
        /// </summary>
        OldestDatesFirst = 0, 

        /// <summary>
        /// Newest tasks/items.
        /// </summary>
        NewestDatesFirst = 1
    }

    /// <summary>
    /// The device of choice to be reminded to, of tasks due.
    /// </summary>
    public enum DefaultReminder
    {
        /// <summary>
        /// Remind by email.
        /// </summary>
        Email, 

        /// <summary>
        /// Remind by mobile phone.
        /// </summary>
        Mobile, 

        /// <summary>
        /// Remind by Notifo account.
        /// </summary>
        Notifo, 

        /// <summary>
        /// No reminders.
        /// </summary>
        NoDefault
    }

    /// <summary>
    /// The log on result.
    /// </summary>
    public enum LogOnResult
    {
        /// <summary>
        /// LogOnFailed returned when login fail (usually due to wrong password/email).
        /// </summary>
        LogOnFailed, 

        /// <summary>
        /// LogOnSucceeded when login succeeded.
        /// </summary>
        LogOnSucceeded
    }

    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        #region Constants and Fields

        /// <summary>
        /// The api token.
        /// </summary>
        private string apiToken;

        /// <summary>
        /// The date format.
        /// </summary>
        private DateFormat dateFormat;

        /// <summary>
        /// The default reminder.
        /// </summary>
        private DefaultReminder defaultReminder;

        /// <summary>
        /// The email.
        /// </summary>
        private string email;

        /// <summary>
        /// The full name.
        /// </summary>
        private string fullName;

        /// <summary>
        /// The id.
        /// </summary>
        private int id;

        /// <summary>
        /// The json data.
        /// </summary>
        private string jsonData;

        /// <summary>
        /// The mobile host.
        /// </summary>
        private string mobileHost;

        /// <summary>
        /// The mobile number.
        /// </summary>
        private string mobileNumber;

        /// <summary>
        /// The notifo account.
        /// </summary>
        private string notifoAccount;

        /// <summary>
        /// The premium until.
        /// </summary>
        private string premiumUntil;

        /// <summary>
        /// The sort order.
        /// </summary>
        private SortOrder sortOrder;

        /// <summary>
        /// The start page.
        /// </summary>
        private StartPage? startPage;

        /// <summary>
        /// The time format.
        /// </summary>
        private TimeFormat timeFormat;

        /// <summary>
        /// The time zone.
        /// </summary>
        private string timeZone;

        /// <summary>
        /// The time zone offset.
        /// </summary>
        private TimeZoneOffset timeZoneOffset;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.LogOff();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the user’s token, which is used for almost every query.
        /// </summary>
        public string ApiToken
        {
            get
            {
                return this.apiToken;
            }
        }

        /// <summary>
        /// Gets the user's dateformat of choice -- DD-MM-YYYY or MM-DD-YYYY.
        /// </summary>
        public DateFormat DateFormat
        {
            get
            {
                return this.dateFormat;
            }
        }

        /// <summary>
        /// Gets the default reminder for the user (Premium feature).
        /// </summary>
        public DefaultReminder DefaultReminder
        {
            get
            {
                return this.defaultReminder;
            }
        }

        /// <summary>
        /// Gets the user’s email.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }
        }

        /// <summary>
        /// Gets the user’s real name.
        /// </summary>
        public string FullName
        {
            get
            {
                return this.fullName;
            }
        }

        /// <summary>
        /// Gets all of the user's projects.
        /// </summary>
        public ReadOnlyCollection<Project> GetProjects
        {
            get
            {
                this.CheckLoginStatus();

                Uri uri = Core.ConstructUri("getProjects?", "token=" + this.ApiToken, false);
                string jsonResponse = Core.GetJsonData(uri);

                JArray o = JArray.Parse(jsonResponse);
                return new ReadOnlyCollection<Project>(o.Root.Select(p => new Project(p.ToString())).ToList());
            }
        }

        /// <summary>
        /// Gets user’s unique id.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets a string of JSON data from Todoist.com.
        /// </summary>
        public string JsonData
        {
            get
            {
                return this.jsonData;
            }
        }

        /// <summary>
        /// Gets the user's mobile host.
        /// </summary>
        public string MobileHost
        {
            get
            {
                return this.mobileHost;
            }
        }

        /// <summary>
        /// Gets the user's mobile number.
        /// </summary>
        public string MobileNumber
        {
            get
            {
                return this.mobileNumber;
            }
        }

        /// <summary>
        /// Gets the user's Notifo account.
        /// </summary>
        public string NotifoAccount
        {
            get
            {
                return this.notifoAccount;
            }
        }

        /// <summary>
        /// Gets the amount of time until the user's premium subscription expires.
        /// </summary>
        public string PremiumUntil
        {
            get
            {
                return this.premiumUntil;
            }
        }

        /// <summary>
        /// Gets a value indicating how the tasks are sorted in a project.
        /// </summary>
        public SortOrder SortOrder
        {
            get
            {
                return this.sortOrder;
            }
        }

        /// <summary>
        /// Gets the user’s default view on Todoist.com.
        /// </summary>
        public StartPage? StartPage
        {
            get
            {
                return this.startPage;
            }
        }

        /// <summary>
        /// Gets the user's timeformat of choice - 24-hour clock or 12-hour clock.
        /// </summary>
        public TimeFormat TimeFormat
        {
            get
            {
                return this.timeFormat;
            }
        }

        /// <summary>
        /// Gets the user’s time zone in a string.
        /// </summary>
        public string TimeZone
        {
            get
            {
                return this.timeZone;
            }
        }

        /// <summary>
        /// Gets the user’s time zone offset.
        /// </summary>
        public TimeZoneOffset TimeZoneOffset
        {
            get
            {
                return this.timeZoneOffset;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Registers a new user account with Todoist. The connection is secured with https.
        /// </summary>
        /// <param name="email">
        /// The new user's email address.
        /// </param>
        /// <param name="fullName">
        /// The new user's full name.
        /// </param>
        /// <param name="password">
        /// The new user's password.
        /// </param>
        /// <param name="timeZone">
        /// The new user's time zone, e.g. "Europe/Copenhagen".
        /// </param>
        /// <exception cref="RegistrationFailedException">
        /// Throws <see cref="RegistrationFailedException"/> if the registration failed.
        /// </exception>
        public static void Register(string email, string fullName, string password, string timeZone)
        {
            Uri uri = Core.ConstructUri(
                "register?",
                string.Format(
                    "email={0}&" + "full_name={1}&" + "password={2}&" + "timezone={3}",
                    email, 
                    fullName, 
                    password, 
                    timeZone), 
                true);
            string jsonResponse = Core.GetJsonData(uri);

            switch (jsonResponse)
            {
                case "\"ALREADY_REGISTRED\"":
                    throw new RegistrationFailedException(
                        "The e-mail address provided has already been registered with Todoist with another account.");
                case "\"TOO_SHORT_PASSWORD\"":
                    throw new RegistrationFailedException(
                        "The password provided is too short. It must at least 5 characters long.");
                case "\"INVALID_EMAIL\"":
                    throw new RegistrationFailedException(
                        "The e-mail address provided is invalid. Please use a valid e-mail address.");
                case "\"INVALID_TIMEZONE\"":
                    throw new RegistrationFailedException(
                        "The time zone provided is invalid. Please use the format \"Europe/Copenhagen\"");
                case "\"INVALID_FULL_NAME\"":
                    throw new RegistrationFailedException("The name provided is invalid.");
                case "\"UNKNOWN_ERROR\"":
                    throw new RegistrationFailedException("Unknown error. Please try again.");
            }
        }

        /// <summary>
        /// Adds an item to a project.
        /// </summary>
        /// <param name="projectId">
        /// The id of the project the item is to be added to.
        /// </param>
        /// <param name="content">
        /// The text of the task.
        /// </param>
        /// <param name="priority">
        /// 4 is urgent, 1 is default, natural.
        /// </param>
        /// <param name="indent">
        /// 1 is top-level, 4 is lowest level.
        /// </param>
        /// <param name="itemOrder">
        /// Item index on the list.
        /// </param>
        public void AddItemToProject(int projectId, string content, int priority, int indent, int? itemOrder)
        {
            this.CheckLoginStatus();

            if (priority < 1 || priority > 4)
            {
                throw new ArgumentOutOfRangeException(priority.ToString(), "Priority must be between 1 and 4.");
            }

            if (indent < 1 || indent > 4)
            {
                throw new ArgumentOutOfRangeException(indent.ToString(), "Indent must be between 1 and 4.");
            }

            Uri uri = Core.ConstructUri(
                "addItem?", 
                string.Format(
                    "token={0}&project_id={1}&content={2}&priority={3}&indent={4}&item_order={5}", 
                    this.ApiToken, 
                    projectId, 
                    content, 
                    priority, 
                    indent, 
                    itemOrder), 
                false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            if (jsonResponse == "\"ERROR_WRONG_DATE_SYNTAX\"")
            {
                throw new ItemException("Wrong date syntax.");
            }
        }

        /// <summary>
        /// Adds a note to an item.
        /// </summary>
        /// <param name="itemId">
        /// The item id of where the note is to be added.
        /// </param>
        /// <param name="content">
        /// The text of the new note.
        /// </param>
        public void AddNoteToItem(int itemId, string content)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "addNote?", string.Format("token={0}&item_id={1}&content={2}", this.ApiToken, itemId, content), false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Complete items and move them to history.
        /// </summary>
        /// <param name="itemIds">
        /// The item ids, which are to be completed.
        /// </param>
        /// <param name="sendToHistory">
        /// Value if the task is to be sent to 'history'.
        /// </param>
        public void CompleteItems(int[] itemIds, bool? sendToHistory)
        {
            this.CheckLoginStatus();

            // Validation
            if (itemIds == null)
            {
                throw new ArgumentNullException("itemIds");
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }

            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");
            Uri uri = Core.ConstructUri(
                "completeItems?", 
                string.Format("token={0}&ids={1}&in_history={2}", this.ApiToken, sb, Convert.ToInt32(sendToHistory)), 
                false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Create a new label.
        /// </summary>
        /// <param name="labelName">
        /// The name of the new label.
        /// </param>
        /// <param name="color">
        /// The color.
        /// </param>
        public void CreateLabel(string labelName, LabelColor color)
        {
            this.CheckLoginStatus();

            // Validation
            if (string.IsNullOrWhiteSpace(labelName))
            {
                throw new ArgumentNullException("labelName");
            }

            Core.GetJsonData(
                Core.ConstructUri(
                    "addLabel?", 
                    string.Format("token={0}&name={1}&color={2}", this.apiToken, labelName, color.GetHashCode()), 
                    false));
        }

        /// <summary>
        /// Create a new project. Call <see cref="GetProjects()"/> on the project collection to refresh it.
        /// </summary>
        /// <param name="projectName">
        /// Name of the new project.
        /// </param>
        /// <param name="indent">
        /// Indent level of the new project.
        /// </param>
        /// <param name="order">
        /// Weight in project list.
        /// </param>
        /// <param name="color">
        /// <see cref="Color"/> of the new project.
        /// </param>
        public void CreateProject(string projectName, int indent, int order, Color color)
        {
            this.CheckLoginStatus();

            // Validation
            if (indent < 1 || indent > 4)
            {
                throw new ArgumentOutOfRangeException(indent.ToString(), "The indent value must be between 1 and 4.");
            }

            if (string.IsNullOrWhiteSpace(projectName))
            {
                throw new ArgumentNullException("projectName");
            }

            // If color is null, set to default green
            if (color == null)
            {
                color = new Color(TodoistColor.Green);
            }

            Uri uri = Core.ConstructUri(
                "addProject?", 
                string.Format(
                    "token={0}&name={1}&indent={2}&order={3}&color={4}", 
                    this.ApiToken, 
                    projectName, 
                    indent, 
                    order, 
                    color.TodoistColor.GetHashCode()), 
                false);
            string jsonResponse = Core.GetJsonData(uri);
            if (jsonResponse == "\"ERROR_NAME_IS_EMPTY\"")
            {
                throw new ProjectException("The project name cannot be null.");
            }
        }

        /// <summary>
        /// Delete existing items.
        /// </summary>
        /// <param name="itemIds">
        /// The item ids, which are to be deleted.
        /// </param>
        public void DeleteItems(int[] itemIds)
        {
            this.CheckLoginStatus();

            // Validation
            if (itemIds == null)
            {
                throw new ArgumentNullException("itemIds");
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }

            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");
            Uri uri = Core.ConstructUri("deleteItems?", string.Format("token={0}&ids={1}", this.ApiToken, sb), false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Delete a specified label.
        /// </summary>
        /// <param name="name">
        /// The name of the label.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If the name is null or whitespace, a <see cref="ArgumentNullException"/> is thrown.
        /// </exception>
        public void DeleteLabel(string name)
        {
            this.CheckLoginStatus();

            // Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            Core.GetJsonData(
                Core.ConstructUri("deleteLabel?", string.Format("token={0}&name={1}", this.apiToken, name), false));
        }

        /// <summary>
        /// Delete an existing note.
        /// </summary>
        /// <param name="itemId">
        /// The item id, from where the note is to be deleted.
        /// </param>
        /// <param name="noteId">
        /// The note id, which is to be deleted.
        /// </param>
        public void DeleteNote(int itemId, int noteId)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "deleteNote?", string.Format("token={0}&item_id={1}&note_id={2}", this.ApiToken, itemId, noteId), false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Delete an existing project. Call <see cref="GetProjects()"/> on the project collection to refresh it.
        /// </summary>
        /// <param name="projectId">
        /// The id of the project to delete
        /// </param>
        public void DeleteProject(int projectId)
        {
            this.CheckLoginStatus();

            Core.GetJsonData(
                Core.ConstructUri(
                    "deleteProject?", string.Format("token={0}&project_id={1}", this.ApiToken, projectId), false));
        }

        /// <summary>
        /// Gets all completed items (only available to premium users).
        /// </summary>
        /// <param name="projectId">
        /// Filter the tasks by project_id.
        /// </param>
        /// <param name="label">
        /// Filter the tasks by label (could be home).
        /// </param>
        /// <param name="interval">
        /// Restrict time range, default is past 2 weeks.
        /// </param>
        /// <returns>
        /// Returns all user's completed items (tasks). Only available for Todoist Premium users.
        /// Returns null if there are no completed items, or if the user is not Premium.
        /// </returns>
        public ReadOnlyCollection<Item> GetAllCompletedItems(int? projectId, string label, string interval)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "getAllCompletedItems?", 
                string.Format(
                    "token={0}&project_id={1}&label={2}&interval={3}", this.ApiToken, projectId, label, interval), 
                false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            JObject o = JObject.Parse(jsonResponse);
            return new ReadOnlyCollection<Item>(o.Root.First.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Gets all completed items of a project.
        /// </summary>
        /// <param name="projectId">
        /// The id of the project where the completed items are from
        /// </param>
        /// <returns>
        /// Returns a project's completed items (tasks) - the tasks that are in history.
        /// </returns>
        public ReadOnlyCollection<Item> GetCompletedItemsByProjectId(int projectId)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "getCompletedItems?", string.Format("token={0}&project_id={1}", this.ApiToken, projectId), false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Gets a <see cref="ReadOnlyCollection{Item}"/> by id.
        /// </summary>
        /// <param name="itemIds">
        /// int array of specific item ids.
        /// </param>
        /// <returns>
        /// Returns a collection of items by id.
        /// </returns>
        public ReadOnlyCollection<Item> GetItemsById(int[] itemIds)
        {
            this.CheckLoginStatus();

            // Validation
            if (itemIds == null)
            {
                throw new ArgumentNullException("itemIds");
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }

            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");
            Uri uri = Core.ConstructUri("getItemsById?", string.Format("token={0}&ids={1}", this.ApiToken, sb), false);
            string jsonResponse = Core.GetJsonData(uri);

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Gets a <see cref="ReadOnlyCollection{T}"/> of labels the user has created.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="ReadOnlyCollection{T}"/> of labels.
        /// </returns>
        public ReadOnlyCollection<Label> GetLabels()
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri("getLabels?", string.Format("token={0}", this.apiToken), false);
            string jsonResponse = Core.GetJsonData(uri);

            JObject o = JObject.Parse(jsonResponse);
            return new ReadOnlyCollection<Label>(o.Root.Select(p => new Label(p.First.ToString())).ToList());
        }

        /// <summary>
        /// Gets all notes of an item.
        /// </summary>
        /// <param name="itemId">
        /// The item id from where the notes are to be found.
        /// </param>
        /// <returns>
        /// Returns all notes of an item.
        /// </returns>
        public ReadOnlyCollection<Note> GetNotesByItemId(int itemId)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "getNotes?", string.Format("token={0}&item_id={1}", this.ApiToken, itemId), false);
            string jsonResponse = Core.GetJsonData(uri);

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Note>(o.Root.Select(note => new Note(note.ToString())).ToList());
        }

        /// <summary>
        /// Gets data about a project. It does not have to be a project in the collection, 
        /// but it must still be a project the user owns. This will not add the project to the collection.
        /// </summary>
        /// <param name="projectId">
        /// The id of the project specified
        /// </param>
        /// <returns>
        /// Returns the specified <see cref="Project"/>.
        /// </returns>
        public Project GetProject(int projectId)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "getProject?", string.Format("token={0}&project_id={1}", this.ApiToken, projectId), false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            return AnalyseProjectJson(jsonResponse);
        }

        /// <summary>
        /// Returns a project's uncompleted items (tasks).
        /// </summary>
        /// <param name="projectId">
        /// The id of the project where the uncompleted items are from
        /// </param>
        /// <returns>
        /// The <see cref="ReadOnlyCollection{T}"/> of uncompleted items from a specific project.
        /// </returns>
        public ReadOnlyCollection<Item> GetUncompletedItemsByProjectId(int projectId)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "getUncompletedItems?", string.Format("token={0}&project_id={1}", this.ApiToken, projectId), false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Resets all properties, because there is no real logging out from Todoist.com
        /// </summary>
        public void LogOff()
        {
            this.id = 0;
            this.email = string.Empty;
            this.fullName = string.Empty;
            this.apiToken = string.Empty;
            this.startPage = new StartPage();
            this.timeZone = null;
            this.timeZoneOffset = new TimeZoneOffset();
            this.timeFormat = new TimeFormat();
            this.dateFormat = 0;
            this.sortOrder = SortOrder.OldestDatesFirst;
            this.notifoAccount = string.Empty;
            this.mobileNumber = string.Empty;
            this.mobileHost = string.Empty;
            this.premiumUntil = string.Empty;
            this.defaultReminder = new DefaultReminder();
            this.jsonData = string.Empty;
        }

        /// <summary>
        /// LogOn user into Todoist to get a token. Required to do any communication.
        /// </summary>
        /// <param name="logOnEmail">
        /// User's email address.
        /// </param>
        /// <param name="password">
        /// User's password.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="logOnEmail"/> or <paramref name="password"/> is null.
        /// </exception>
        /// <exception cref="LogOnFailedException">
        /// If <paramref name="logOnEmail"/> or <paramref name="password"/> is incorrect.
        /// </exception>
        /// <exception cref="WebException">
        /// </exception>
        /// <returns>
        /// The log on result.
        /// </returns>
        public LogOnResult LogOn(string logOnEmail, string password)
        {
            this.LogOff();
            if (string.IsNullOrWhiteSpace(logOnEmail))
            {
                throw new ArgumentNullException(logOnEmail);
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(password);
            }

            Uri uri = Core.ConstructUri("login?", string.Format("email={0}&password={1}", logOnEmail, password), true);
            string tempJson = Core.GetJsonData(uri);

            if (tempJson == "\"LOGIN_ERROR\"")
            {
                throw new LogOnFailedException("LogOn failed.");
            }

            this.jsonData = tempJson;
            this.AnalyseJson();

            return LogOnResult.LogOnSucceeded;
        }

        /// <summary>
        /// Move items from one project to another.
        /// </summary>
        /// <param name="itemIds">
        /// The item Ids.
        /// </param>
        /// <param name="fromProjectId">
        /// The from Project Id.
        /// </param>
        /// <param name="toProjectId">
        /// The to Project Id.
        /// </param>
        public void MoveItems(int[] itemIds, int fromProjectId, int toProjectId)
        {
            this.CheckLoginStatus();

            // Validation
            if (itemIds == null)
            {
                throw new ArgumentNullException("itemIds");
            }

            ReadOnlyCollection<Item> items = this.GetItemsById(itemIds);
            if (items.Any(item => item.ProjectId != fromProjectId))
            {
                throw new ItemException(string.Format("The item does not exist in {0}.", fromProjectId));
            }

            if (itemIds.Where((t, i) => items[i].ProjectId == toProjectId).Any())
            {
                throw new ItemException("The item already exists in the destination project.");
            }

            // Build JSON mapping
            var jsonMapping = new StringBuilder();
            jsonMapping.Append("{\"" + fromProjectId + "\":[");
            foreach (Item item in items)
            {
                jsonMapping.Append(string.Format("\"{0}\",", item.Id));
            }

            if (jsonMapping.ToString().ElementAt(jsonMapping.Length - 1) == ',')
            {
                jsonMapping.Remove(jsonMapping.Length - 1, 1);
            }

            jsonMapping.Append("]}");

            Uri uri = Core.ConstructUri(
                "moveItems?", 
                string.Format("token={0}&project_items={1}&to_project={2}", this.ApiToken, jsonMapping, toProjectId), 
                false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// "Un-complete" items and move them to the active projects.
        /// </summary>
        /// <param name="itemIds">
        /// The item ids, which are to be "un-completed".
        /// </param>
        public void UncompleteItems(int[] itemIds)
        {
            this.CheckLoginStatus();

            // Validation
            if (itemIds == null)
            {
                throw new ArgumentNullException("itemIds");
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }

            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");
            Uri uri = Core.ConstructUri(
                "uncompleteItems?", string.Format("token={0}&ids={1}", this.ApiToken, sb), false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Update an existing item.
        /// </summary>
        /// <param name="itemId">
        /// The item to update.
        /// </param>
        /// <param name="content">
        /// The new content/text. To add the item to a label, append "@labelname".
        /// </param>
        /// <param name="priority">
        /// The new priority.
        /// </param>
        /// <param name="indent">
        /// The new indent-level.
        /// </param>
        /// <param name="isCollapsed">
        /// Toggle collapsed.
        /// </param>
        public void UpdateItem(int itemId, string content, int? priority, int? indent, bool? isCollapsed)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "updateItem?", 
                string.Format(
                    "token={0}&id={1}&content={2}&priority={3}&indent={4}&collapsed={5}", 
                    this.ApiToken, 
                    itemId, 
                    content, 
                    priority, 
                    indent, 
                    Convert.ToInt32(isCollapsed)), 
                false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_ITEM_NOT_FOUND\"")
            {
                throw new ItemException("Item not found.");
            }
        }

        /// <summary>
        /// Update the order of a project's tasks.
        /// </summary>
        /// <param name="projectId">
        /// The project to update.
        /// </param>
        /// <param name="itemIds">
        /// The item ids in the order wished.
        /// </param>
        public void UpdateItemOrdering(int projectId, int[] itemIds)
        {
            this.CheckLoginStatus();

            // Validation
            if (itemIds == null)
            {
                throw new ArgumentNullException("itemIds");
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }

            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");
            Uri uri = Core.ConstructUri(
                "getItemsById?", string.Format("token={0}&project_id={1}&ids={2}", this.ApiToken, projectId, sb), false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }
        }

        /// <summary>
        /// Update the color of a specified label.
        /// </summary>
        /// <param name="name">
        /// The name of the label to update.
        /// </param>
        /// <param name="color">
        /// The new color.
        /// </param>
        public void UpdateLabelColor(string name, LabelColor color)
        {
            this.CheckLoginStatus();

            // Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            Core.GetJsonData(
                Core.ConstructUri(
                    "updateLabelColor?", 
                    string.Format("token={0}&name={1}&color={2}", this.ApiToken, name, color.GetHashCode()), 
                    false));
        }

        /// <summary>
        /// Update the name of a specified label.
        /// </summary>
        /// <param name="oldName">
        /// The old name of the label.
        /// </param>
        /// <param name="newName">
        /// The new name of the label.
        /// </param>
        public void UpdateLabelName(string oldName, string newName)
        {
            this.CheckLoginStatus();

            // Validation
            if (string.IsNullOrWhiteSpace(oldName))
            {
                throw new ArgumentNullException("oldName");
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentNullException("newName");
            }

            Core.GetJsonData(
                Core.ConstructUri(
                    "updateLabel?", 
                    string.Format("token={0}&old_name={1}&new_name={2}", this.ApiToken, oldName, newName), 
                    false));
        }

        /// <summary>
        /// Update an existing project.
        /// </summary>
        /// <param name="projectId">
        /// The id of the project that is to be updated.
        /// </param>
        /// <param name="name">
        /// New name.
        /// </param>
        /// <param name="color">
        /// New color.
        /// </param>
        /// <param name="indent">
        /// New indent level.
        /// </param>
        /// <param name="itemOrder">
        /// New way of sorting tasks.
        /// </param>
        /// <param name="isCollapsed">
        /// Toggle collapse.
        /// </param>
        /// <param name="isGroup">
        /// Toggle group.
        /// </param>
        public void UpdateProject(
            int projectId, 
            string name, 
            TodoistColor? color, 
            int? indent, 
            int? itemOrder, 
            bool? isCollapsed, 
            bool? isGroup)
        {
            this.CheckLoginStatus();

            // Validation
            TodoistColor? internalColor = color;
            if (color == null)
            {
                internalColor = this.GetProject(projectId).Color.TodoistColor;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                Project projectToBeChanged = this.GetProject(projectId);
                name = projectToBeChanged.Name;
            }

            if (isGroup != null && isGroup == true)
            {
                name = string.Format("*{0}", name);
            }

            Uri uri = Core.ConstructUri(
                "updateProject?", 
                string.Format(
                    "&project_id={0}&token={1}&name={2}&color={3}&indent={4}&order={5}&collapsed={6}", 
                    projectId, 
                    this.ApiToken, 
                    name, 
                    internalColor.GetHashCode(), 
                    indent, 
                    itemOrder, 
                    Convert.ToInt32(isCollapsed)), 
                false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Name cannot be null.");
            }
        }

        /// <summary>
        /// Updates how the projects are ordered.
        /// </summary>
        /// <param name="order">
        /// A JSON list of the project's order, could be [3,2,9,7]
        /// </param>
        /// <example>
        /// user.UpdateProjectOrdering(new int[] { 0, 2, 3, 1 });
        /// </example>
        public void UpdateProjectOrdering(int[] order)
        {
            this.CheckLoginStatus();

            // Validation
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int s in order)
            {
                sb.Append(s + ",");
            }

            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");
            Uri uri = Core.ConstructUri(
                "updateProjectOrders?", string.Format("token={0}&item_id_list={1}", this.ApiToken, sb), false);

            string jsonResponse = Core.GetJsonData(uri);
            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }
        }

        /// <summary>
        /// Update recurring dates and set them to next date regarding an item's date_string.
        /// </summary>
        /// <param name="itemIds">
        /// The ids of the items to update.
        /// </param>
        public void UpdateRecurringDate(int[] itemIds)
        {
            this.CheckLoginStatus();

            // Validation
            if (itemIds == null)
            {
                throw new ArgumentNullException("itemIds");
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }

            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");
            Uri uri = Core.ConstructUri(
                "updateRecurringDate?", string.Format("token={0}&ids={1}", this.ApiToken, sb), false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="newEmail">
        /// New email
        /// </param>
        /// <param name="newFullName">
        /// New name
        /// </param>
        /// <param name="newPassword">
        /// New password
        /// </param>
        /// <param name="newTimeZone">
        /// New timezone
        /// </param>
        /// <param name="newDateFormat">
        /// New dateformat
        /// </param>
        /// <param name="newTimeFormat">
        /// New timeformat
        /// </param>
        /// <param name="newStartPage">
        /// New startpage
        /// </param>
        public void UpdateUser(
            string newEmail, 
            string newFullName, 
            string newPassword, 
            string newTimeZone, 
            DateFormat? newDateFormat, 
            TimeFormat? newTimeFormat, 
            StartPage? newStartPage)
        {
            this.CheckLoginStatus();

            Uri uri = Core.ConstructUri(
                "updateUser?", 
                string.Format(
                    "token={0}&" + "email={1}&" + "full_name={2}&" + "password={3}&" + "timezone={4}&"
                    + "date_format={5}&" + "time_format={6}&" + "start_page={7}", 
                    this.ApiToken, 
                    newEmail, 
                    newFullName, 
                    newPassword, 
                    newTimeZone, 
                    newDateFormat, 
                    newTimeFormat, 
                    newStartPage), 
                true);

            string jsonResponse = Core.GetJsonData(uri);

            switch (jsonResponse)
            {
                case "\"ERROR_PASSWORD_TOO_SHORT\"":
                    throw new UpdateUserException(
                        "The password provided is too short. It must be at least 5 characters long.");
                case "\"ERROR_EMAIL_FOUND\"":
                    throw new UpdateUserException(
                        "The e-mail address provided has already been registered with Todoist with another account.");
            }

            this.jsonData = jsonResponse;
            this.AnalyseJson();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks user's login status.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws <see cref="ArgumentNullException"/> if the user is not logged in.
        /// </exception>
        internal void CheckLoginStatus()
        {
            if (string.IsNullOrWhiteSpace(this.ApiToken))
            {
                throw new ArgumentNullException(this.ApiToken, "You must login to do that.");
            }
        }

        /// <summary>
        /// The analyse project json.
        /// </summary>
        /// <param name="jsonData">
        /// The json data.
        /// </param>
        /// <returns>
        /// Returns a new project. The constructor for project(string jsonData) analyses the data itself.
        /// </returns>
        private static Project AnalyseProjectJson(string jsonData)
        {
            return new Project(jsonData);
        }

        /// <summary>
        /// The analyse json.
        /// </summary>
        private void AnalyseJson()
        {
            JObject o = JObject.Parse(this.JsonData);
            this.notifoAccount = (string)o.SelectToken("notifo");
            this.apiToken = (string)o.SelectToken("api_token");
            switch ((int)o.SelectToken("time_format"))
            {
                case 0:
                    this.timeFormat = TimeFormat.TwentyFourHourClock;
                    break;
                case 1:
                    this.timeFormat = TimeFormat.TwelveHourClock;
                    break;
            }

            switch ((int)o.SelectToken("sort_order"))
            {
                case 0:
                    this.sortOrder = SortOrder.OldestDatesFirst;
                    break;
                case 1:
                    this.sortOrder = SortOrder.NewestDatesFirst;
                    break;
            }

            this.fullName = (string)o.SelectToken("full_name");
            this.mobileNumber = (string)o.SelectToken("mobile_number");
            this.mobileHost = (string)o.SelectToken("mobile_host");
            this.timeZone = (string)o.SelectToken("timezone");

            this.id = (int)o.SelectToken("id");

            switch ((int)o.SelectToken("date_format"))
            {
                case 0:
                    this.dateFormat = DateFormat.DdMmYyyy;
                    break;
                case 1:
                    this.dateFormat = DateFormat.MmDdYyyy;
                    break;
            }

            this.premiumUntil = (string)o.SelectToken("premium_until");

            JToken timeZoneString = o.SelectToken("tz_offset");
            this.timeZoneOffset = new TimeZoneOffset(
                timeZoneString.First.Value<string>(), 
                timeZoneString.First.Next.Value<int>(), 
                timeZoneString.First.Next.Next.Value<int>(), 
                timeZoneString.First.Next.Next.Next.Value<bool>());

            switch ((string)o.SelectToken("default_reminder"))
            {
                case "email":
                    this.defaultReminder = DefaultReminder.Email;
                    break;
                case "mobile":
                    this.defaultReminder = DefaultReminder.Mobile;
                    break;
                case "notifo":
                    this.defaultReminder = DefaultReminder.Notifo;
                    break;
                case "no_defalt":
                    this.defaultReminder = DefaultReminder.NoDefault;
                    break;
            }

            this.email = (string)o.SelectToken("email");
        }

        #endregion
    }
}