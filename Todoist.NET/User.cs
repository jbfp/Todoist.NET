#region License

// Copyright (c) 2011 Jakob Pedersen
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

#endregion

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Todoist.NET
{
    /// <summary>
    /// User's startpage on Todoist.com
    /// </summary>
    public enum StartPage
    {
        /// <summary>
        /// Infopage
        /// </summary>
        InfoPage,

        /// <summary>
        /// Blank page
        /// </summary>
        Blank,

        /// <summary>
        /// Project of choice (NYI)
        /// </summary>
        ProjectX
    }

    /// <summary>
    /// User's time format, either 12-hour clock or 24-hour clock
    /// </summary>
    public enum TimeFormat
    {
        /// <summary>
        /// 24-hour clock format, e.g. 13:00
        /// </summary>
        TwentyFourHourClock = 0,

        /// <summary>
        /// 12-hour clock format, e.g. 1 pm
        /// </summary>
        TwelveHourClock = 1
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DateFormat
    {
        /// <summary>
        /// DD-MM-YYY date format
        /// </summary>
        DdMmYyyy = 0,

        /// <summary>
        /// MM-DD-YYY date format
        /// </summary>
        MmDdYyyy = 1
    }

    /// <summary>
    /// When tasks are sorted by date, which tasks come first
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// Oldest tasks/items
        /// </summary>
        OldestDatesFirst = 0,

        /// <summary>
        /// Newest tasks/items
        /// </summary>
        NewestDatesFirst = 1
    }

    /// <summary>
    /// The device of choice to be reminded to, of tasks due
    /// </summary>
    public enum DefaultReminder
    {
        /// <summary>
        /// Remind by email
        /// </summary>
        Email,

        /// <summary>
        /// Remind by mobile phone
        /// </summary>
        Mobile,

        /// <summary>
        /// Remind by Notifo account
        /// </summary>
        Notifo,

        /// <summary>
        /// No reminders
        /// </summary>
        NoDefault
    }

    /// <summary>
    /// 
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// LoginFailed returned when login fail (usually due to wrong password/email)
        /// </summary>
        LoginFailed,

        /// <summary>
        /// LoginSucceeded when login succeeded
        /// </summary>
        LoginSucceeded
    }

    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        #region Properties

        private string _apiToken;
        private DateFormat _dateFormat;
        private DefaultReminder _defaultReminder;
        private string _email;
        private string _fullName;
        private int _id;
        private string _jsonData;
        private string _mobileHost;
        private string _mobileNumber;
        private string _notifoAccount;
        private string _premiumUntil;
        private SortOrder _sortOrder;
        private StartPage? _startPage;
        private TimeFormat _timeFormat;
        private string _timeZone;
        private TimeZoneOffset _timeZoneOffset;

        /// <summary>
        /// User’s unique id
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// User’s email
        /// </summary>
        public string Email
        {
            get { return _email; }
        }

        /// <summary>
        /// User’s real name
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
        }

        /// <summary>
        /// User’s token, which is used for almost every query
        /// </summary>
        public string ApiToken
        {
            get { return _apiToken; }
        }

        /// <summary>
        /// User’s default view on Todoist.com
        /// </summary>
        public StartPage? StartPage
        {
            get { return _startPage; }
        }

        /// <summary>
        /// User’s timezone in a string
        /// </summary>
        public string TimeZone
        {
            get { return _timeZone; }
        }

        /// <summary>
        /// User’s timezone offset
        /// </summary>
        public TimeZoneOffset TimeZoneOffset
        {
            get { return _timeZoneOffset; }
        }

        /// <summary>
        /// User's timeformat of choice -- 24-hour clock or 12-hour clock
        /// </summary>
        public TimeFormat TimeFormat
        {
            get { return _timeFormat; }
        }

        /// <summary>
        /// User's dateformat of choice -- DD-MM-YYYY or MM-DD-YYYY
        /// </summary>
        public DateFormat DateFormat
        {
            get { return _dateFormat; }
        }

        /// <summary>
        /// When viewing projects, are the the Oldest dates first or Oldest dates last
        /// </summary>
        public SortOrder SortOrder
        {
            get { return _sortOrder; }
        }

        /// <summary>
        /// User's Notifo account
        /// </summary>
        public string NotifoAccount
        {
            get { return _notifoAccount; }
        }

        /// <summary>
        /// User's mobile number
        /// </summary>
        public string MobileNumber
        {
            get { return _mobileNumber; }
        }

        /// <summary>
        /// User's mobile host
        /// </summary>
        public string MobileHost
        {
            get { return _mobileHost; }
        }

        /// <summary>
        /// When does the user's premium subscription expire?
        /// </summary>
        public string PremiumUntil
        {
            get { return _premiumUntil; }
        }

        /// <summary>
        /// What is the default reminder for the user (Premium feature)
        /// </summary>
        public DefaultReminder DefaultReminder
        {
            get { return _defaultReminder; }
        }

        /// <summary>
        /// A string of JSON data from Todoist.com
        /// </summary>
        public string JsonData
        {
            get { return _jsonData; }
        }

        #endregion

        #region User

        /// <summary>
        /// Constructor. Logs the user out first (which is basically a property reset)
        /// </summary>
        public User()
        {
            Logout();
        }

        /// <summary>
        /// Login user into Todoist to get a token. Required to do any communication.
        /// </summary>
        /// <param name="email">User's email address.</param>
        /// <param name="password">User's password.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="email"/> or <paramref name="password"/> is null.</exception>
        /// <exception cref="LoginFailedException">If <paramref name="email"/> or <paramref name="password"/> is incorrect.</exception>
        public LoginResult Login(string email, string password)
        {
            Logout();
            if (String.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(email);

            if (String.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(password);

            Uri uri = Core.ConstructUri(
                "login?",
                String.Format("email={0}&password={1}", email, password),
                true);
            string tempJson = Core.GetJsonData(uri);

            if (tempJson == "\"LOGIN_ERROR\"")
            {
                throw new LoginFailedException("Login failed.");
            }

            _jsonData = tempJson;
            AnalyseJson();

            return LoginResult.LoginSucceeded;
        }

        /// <summary>
        /// Resets all properties, because there is no real logging out from Todoist.com
        /// </summary>
        public void Logout()
        {
            _id = 0;
            _email = "";
            _fullName = "";
            _apiToken = "";
            _startPage = new StartPage();
            _timeZone = null;
            _timeZoneOffset = new TimeZoneOffset();
            _timeFormat = new TimeFormat();
            _dateFormat = 0;
            _sortOrder = SortOrder.OldestDatesFirst;
            _notifoAccount = "";
            _mobileNumber = "";
            _mobileHost = "";
            _premiumUntil = "";
            _defaultReminder = new DefaultReminder();
            _jsonData = "";
        }

        private void AnalyseJson()
        {
            JObject o = JObject.Parse(JsonData);
            _notifoAccount = (string) o.SelectToken("notifo");
            _apiToken = (string) o.SelectToken("api_token");
            switch ((int) o.SelectToken("time_format"))
            {
                case 0:
                    _timeFormat = TimeFormat.TwentyFourHourClock;
                    break;
                case 1:
                    _timeFormat = TimeFormat.TwelveHourClock;
                    break;
            }

            switch ((int) o.SelectToken("sort_order"))
            {
                case 0:
                    _sortOrder = SortOrder.OldestDatesFirst;
                    break;
                case 1:
                    _sortOrder = SortOrder.NewestDatesFirst;
                    break;
            }

            _fullName = (string) o.SelectToken("full_name");
            _mobileNumber = (string) o.SelectToken("mobile_number");
            _mobileHost = (string) o.SelectToken("mobile_host");
            _timeZone = (string) o.SelectToken("timezone");

            _id = (int) o.SelectToken("id");

            switch ((int) o.SelectToken("date_format"))
            {
                case 0:
                    _dateFormat = DateFormat.DdMmYyyy;
                    break;
                case 1:
                    _dateFormat = DateFormat.MmDdYyyy;
                    break;
            }

            _premiumUntil = (string) o.SelectToken("premium_until");

            JToken tzStr = o.SelectToken("tz_offset");
            _timeZoneOffset = new TimeZoneOffset(tzStr.First.Value<string>(),
                                                 tzStr.First.Next.Value<int>(),
                                                 tzStr.First.Next.Next.Value<int>(),
                                                 tzStr.First.Next.Next.Next.Value<bool>());

            switch ((string) o.SelectToken("default_reminder"))
            {
                case "email":
                    _defaultReminder = DefaultReminder.Email;
                    break;
                case "mobile":
                    _defaultReminder = DefaultReminder.Mobile;
                    break;
                case "notifo":
                    _defaultReminder = DefaultReminder.Notifo;
                    break;
                case "no_defalt":
                    _defaultReminder = DefaultReminder.NoDefault;
                    break;
            }

            _email = (string) o.SelectToken("email");
        }

        /// <summary>
        /// Registers a new user account with Todoist. The connection is secured with https.
        /// </summary>
        /// <param name="email">The new user's email address.</param>
        /// <param name="fullName">The new user's full name.</param>
        /// <param name="password">The new user's password.</param>
        /// <param name="timeZone">The new user's time zone in "Europe/Copenhagen" format.</param>
        /// <exception cref="RegistrationFailedException"><see cref="RegistrationFailedException"/></exception>
        public static void Register(string email, string fullName, string password, string timeZone)
        {
            Uri uri = Core.ConstructUri("register?",
                                        String.Format("email={0}&" +
                                                      "full_name={1}&" +
                                                      "password={2}&" +
                                                      "timezone={3}", email, fullName,
                                                      password, timeZone),
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
        /// Update user
        /// </summary>
        /// <param name="email">New email</param>
        /// <param name="fullName">New name</param>
        /// <param name="password">New password</param>
        /// <param name="timeZone">New timezone</param>
        /// <param name="dateFormat">New dateformat</param>
        /// <param name="timeFormat">New timeformat</param>
        /// <param name="startPage">New startpage</param>
        public void UpdateUser(string email, string fullName, string password, string timeZone,
                               DateFormat? dateFormat,
                               TimeFormat? timeFormat, StartPage? startPage)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("updateUser?",
                                        String.Format("token={0}&" +
                                                      "email={1}&" +
                                                      "full_name={2}&" +
                                                      "password={3}&" +
                                                      "timezone={4}&" +
                                                      "date_format={5}&" +
                                                      "time_format={6}&" +
                                                      "start_page={7}", ApiToken, email, fullName, password, timeZone,
                                                      dateFormat, timeFormat, startPage),
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

            _jsonData = jsonResponse;
            AnalyseJson();
        }

        #endregion

        #region Project

        /// <summary>
        /// Returns all of user's projects.
        /// </summary>
        public ReadOnlyCollection<Project> GetProjects()
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getProjects?", "token=" + ApiToken, false);
            string jsonResponse = Core.GetJsonData(uri);

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Project>(o.Root.Select(p => new Project(p.ToString())).ToList());
        }

        /// <summary>
        /// Return's data about a project. It does not have to be a project in the collection, 
        /// but it must still be a project the user owns. This will not add the project to the collection.
        /// </summary>
        /// <param name="projectId">The id of the project specified</param>
        /// <returns></returns>
        public Project GetProject(int projectId)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getProject?",
                                        String.Format("token={0}&project_id={1}", ApiToken, projectId),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            return AnalyseProjectJson(jsonResponse);
        }

        private static Project AnalyseProjectJson(string jsonData)
        {
            return new Project(jsonData);
        }

        /// <summary>
        /// Create a new project. Call <see cref="GetProjects"/> on the project collection to refresh it.
        /// </summary>
        /// <param name="projectName">Name</param>
        /// <param name="color">Color</param>
        /// <param name="indent">Indent level</param>
        /// <param name="order">Position in project list</param>
        public void CreateProject(string projectName, int indent, int order, Color color)
        {
            CheckLoginStatus();

            // Validation
            if (indent < 1 || indent > 4)
                throw new ArgumentOutOfRangeException(indent.ToString(),
                                                      "The indent value must be between 1 and 4.");
            if (String.IsNullOrWhiteSpace(projectName))
                throw new ArgumentNullException("projectName");

            // If color is null, set to default green
            if (color == null)
                color = new Color(TodoistColor.Green);

            Uri uri = Core.ConstructUri("addProject?",
                                        String.Format("token={0}&name={1}&indent={2}&order={3}&color={4}",
                                                      ApiToken, projectName, indent, order,
                                                      color.TodoistColor.GetHashCode()),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);
            if (jsonResponse == "\"ERROR_NAME_IS_EMPTY\"")
                throw new ProjectException("The project name cannot be null.");
        }

        /// <summary>
        /// Update an existing project.
        /// </summary>
        /// <param name="projectId">The id of the project that is to be updated</param>
        /// <param name="name">New name</param>
        /// <param name="color">New color</param>
        /// <param name="indent">New indent level</param>
        /// <param name="itemOrder">New way of sorting tasks</param>
        /// <param name="isCollapsed">Toggle collapse</param>
        public void UpdateProject(int projectId, string name, TodoistColor? color, int? indent, int? itemOrder,
                                  bool? isCollapsed)
        {
            CheckLoginStatus();

            // Validation
            TodoistColor? internalColor = color;
            if (color == null)
                internalColor = GetProject(projectId).Color.TodoistColor;

            if (String.IsNullOrWhiteSpace(name))
            {
                Project projectToBeChanged = GetProject(projectId);
                name = projectToBeChanged.Name;
            }

            Uri uri = Core.ConstructUri("updateProject?",
                                        String.Format(
                                            "&project_id={0}&token={1}&name={2}&color={3}&indent={4}&order={5}&collapsed={6}",
                                            projectId,
                                            ApiToken,
                                            name.Replace("*", String.Empty),
                                            internalColor.GetHashCode(),
                                            indent,
                                            itemOrder,
                                            Convert.ToInt32(isCollapsed)),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
                throw new ProjectException("Name cannot be null.");
        }

        /// <summary>
        /// Updates how the projects are ordered.
        /// </summary>
        /// <param name="order">A JSON list of the project's order, could be [3,2,9,7]</param>
        /// <example>
        /// user.UpdateProjectOrdering(new int[] { 0, 2, 3, 1 });
        /// </example>
        public void UpdateProjectOrdering(int[] order)
        {
            CheckLoginStatus();

            // Validation
            if (order == null)
                throw new ArgumentNullException("order");

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int s in order)
                sb.Append(s + ",");

            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
                sb.Remove(sb.Length - 1, 1);

            sb.Append("]");
            Uri uri = Core.ConstructUri(
                "updateProjectOrders?",
                String.Format("token={0}&item_id_list={1}", ApiToken, sb),
                false);

            string jsonResponse = Core.GetJsonData(uri);
            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
                throw new ProjectException("Project not found.");
        }

        /// <summary>
        /// Delete an existing project. Call <see cref="GetProjects"/> on the project collection to refresh it.
        /// </summary>
        /// <param name="projectId">The id of the project to delete</param>
        public void DeleteProject(int projectId)
        {
            CheckLoginStatus();

            Core.GetJsonData(
                Core.ConstructUri(
                    "deleteProject?",
                    String.Format("token={0}&project_id={1}", ApiToken, projectId),
                    false));
        }

        #endregion

        #region Item

        /// <summary>
        /// Returns a project's uncompleted items (tasks).
        /// </summary>
        /// <param name="projectId">The id of the project where the uncompleted items are from</param>
        /// <returns></returns>
        public ReadOnlyCollection<Item> GetUncompletedItemsByProjectId(int projectId)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getUncompletedItems?",
                                        String.Format("token={0}&project_id={1}",
                                                      ApiToken,
                                                      projectId),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Returns all user's completed items (tasks). Only available for Todoist Premium users.
        /// Will return null if there are no completed items, or if the user is not Premium.
        /// </summary>
        /// <param name="projectId">Filter the tasks by project_id.</param>
        /// <param name="label">Filter the tasks by label (could be home).</param>
        /// <param name="interval">Restrict time range, default is past 2 weeks.</param>
        /// <returns>Returns all user's completed items (tasks). Only available for Todoist Premium users.
        /// Will return null if there are no completed items, or if the user is not Premium.</returns>
        public ReadOnlyCollection<Item> GetAllCompletedItems(int? projectId, string label, string interval)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getAllCompletedItems?",
                                        String.Format("token={0}&project_id={1}&label={2}&interval={3}",
                                                      ApiToken, projectId, label, interval), false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            JObject o = JObject.Parse(jsonResponse);
            return new ReadOnlyCollection<Item>(o.Root.First.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Returns a project's completed items (tasks) - the tasks that are in history.
        /// </summary>
        /// <param name="projectId">The id of the project where the completed items are from</param>
        /// <returns>Returns a project's completed items (tasks) - the tasks that are in history.</returns>
        public ReadOnlyCollection<Item> GetCompletedItemsByProjectId(int projectId)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getCompletedItems?",
                                        String.Format("token={0}&project_id={1}",
                                                      ApiToken,
                                                      projectId),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.");
            }

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Returns a list of items by id.
        /// </summary>
        /// <param name="itemIds">int array of specific item ids</param>
        /// <returns>Returns a list of items by id.</returns>
        public ReadOnlyCollection<Item> GetItemsById(int[] itemIds)
        {
            CheckLoginStatus();

            // Validation
            if (itemIds == null)
                throw new ArgumentNullException("itemIds");

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }
            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
                sb.Remove(sb.Length - 1, 1);

            sb.Append("]");
            Uri uri = Core.ConstructUri("getItemsById?",
                                        String.Format("token={0}&ids={1}", ApiToken, sb),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Adds an item to a project.
        /// </summary>
        /// <param name="projectId">The id of the project the item is to be added to.</param>
        /// <param name="content">The text of the task.</param>
        /// <param name="priority">4 is urgent, 1 is default, natural.</param>
        /// <param name="indent">1 is top-level, 4 is lowest level.</param>
        /// <param name="itemOrder">Item index on the list.</param>
        public void AddItemToProject(int projectId, string content, int priority, int indent, int? itemOrder)
        {
            CheckLoginStatus();

            if (priority < 1 || priority > 4)
                throw new ArgumentOutOfRangeException(priority.ToString(),
                                                      "Priority must be between 1 and 4.");
            if (indent < 1 || indent > 4)
                throw new ArgumentOutOfRangeException(indent.ToString(),
                                                      "Indent must be between 1 and 4.");

            Uri uri = Core.ConstructUri("addItem?",
                                        String.Format(
                                            "token={0}&project_id={1}&content={2}&priority={3}&indent={4}&item_order={5}",
                                            ApiToken, projectId,
                                            content, priority, indent, itemOrder), false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
                throw new ProjectException("Project not found.");
            if (jsonResponse == "\"ERROR_WRONG_DATE_SYNTAX\"")
                throw new ItemException("Wrong date syntax.");
        }

        /// <summary>
        /// Update an existing item.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="content"></param>
        /// <param name="priority"></param>
        /// <param name="indent"></param>
        /// <param name="isCollapsed"></param>
        public void UpdateItem(int itemId, string content, int? priority, int? indent, bool? isCollapsed)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("updateItem?",
                                        String.Format(
                                            "token={0}&id={1}&content={2}&priority={3}&indent={4}&collapsed={5}",
                                            ApiToken, itemId, content, priority, indent, Convert.ToInt32(isCollapsed)),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_ITEM_NOT_FOUND\"")
                throw new ItemException("Item not found.");
        }

        /// <summary>
        /// Update the order of a project's tasks.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="itemIds"></param>
        public void UpdateItemOrdering(int projectId, int[] itemIds)
        {
            CheckLoginStatus();

            // Validation
            if (itemIds == null)
                throw new ArgumentNullException("itemIds");

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }
            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
                sb.Remove(sb.Length - 1, 1);

            sb.Append("]");
            Uri uri = Core.ConstructUri("getItemsById?",
                                        String.Format("token={0}&project_id={1}&ids={2}", ApiToken, projectId, sb),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
                throw new ProjectException("Project not found.");
        }

        /// <summary>
        /// Move items from one project to another.
        /// </summary>
        public void MoveItem(int projectId)
        {
            CheckLoginStatus();
            throw new NotImplementedException("Don't worry, this is next on the list.");
        }

        /// <summary>
        /// Update recurring dates and set them to next date regarding an item's date_string.
        /// </summary>
        /// <param name="itemIds"></param>
        public void UpdateRecurringDate(int[] itemIds)
        {
            CheckLoginStatus();

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
                sb.Remove(sb.Length - 1, 1);

            sb.Append("]");
            Uri uri = Core.ConstructUri("updateRecurringDate?", String.Format("token={0}&ids={1}", ApiToken, sb), false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Delete existing items.
        /// </summary>
        /// <param name="itemIds">The item ids, which are to be deleted.</param>
        public void DeleteItems(int[] itemIds)
        {
            CheckLoginStatus();

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
                sb.Remove(sb.Length - 1, 1);

            sb.Append("]");
            Uri uri = Core.ConstructUri("deleteItems?", String.Format("token={0}&ids={1}", ApiToken, sb), false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Complete items and move them to history.
        /// </summary>
        /// <param name="itemIds">The item ids, which are to be completed.</param>
        /// <param name="sendToHistory"></param>
        public void CompleteItems(int[] itemIds, bool? sendToHistory)
        {
            CheckLoginStatus();

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
                sb.Remove(sb.Length - 1, 1);

            sb.Append("]");
            Uri uri = Core.ConstructUri("completeItems?", String.Format("token={0}&ids={1}&in_history={2}",
                                                                        ApiToken, sb, Convert.ToInt32(sendToHistory)),
                                        false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// "Un-complete" items and move them to the active projects.
        /// </summary>
        /// <param name="itemIds">The item ids, which are to be "un-completed".</param>
        public void UncompleteItems(int[] itemIds)
        {
            CheckLoginStatus();

            // Validation
            if (itemIds == null)
                throw new ArgumentNullException("itemIds");

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (int itemId in itemIds)
            {
                sb.Append(itemId + ",");
            }
            if (sb.ToString().ElementAt(sb.Length - 1) == ',')
                sb.Remove(sb.Length - 1, 1);

            sb.Append("]");
            Uri uri = Core.ConstructUri("uncompleteItems?", String.Format("token={0}&ids={1}", ApiToken, sb), false);
            Core.GetJsonData(uri);
        }

        #endregion

        #region Note

        /// <summary>
        /// Adds a note to an item.
        /// </summary>
        /// <param name="itemId">The item id of where the note is to be added.</param>
        /// <param name="content">The text of the new note.</param>
        public void AddNoteToItem(int itemId, string content)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("addNote?",
                                        String.Format("token={0}&item_id={1}&content={2}", ApiToken, itemId, content),
                                        false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Delete an existing note.
        /// </summary>
        /// <param name="itemId">The item id, from where the note is to be deleted.</param>
        /// <param name="noteId">The note id, which is to be deleted.</param>
        public void DeleteNote(int itemId, int noteId)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("deleteNote?",
                                        String.Format("token={0}&item_id={1}&note_id={2}", ApiToken, itemId, noteId),
                                        false);
            Core.GetJsonData(uri);
        }

        /// <summary>
        /// Returns all notes of an item.
        /// </summary>
        /// <param name="itemId">The item id from where the notes are to be found.</param>
        /// <returns>Returns all notes of an item.</returns>
        public ReadOnlyCollection<Note> GetNotesByItemId(int itemId)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getNotes?", String.Format("token={0}&item_id={1}", ApiToken, itemId), false);
            string jsonResponse = Core.GetJsonData(uri);

            JArray o = JArray.Parse(jsonResponse);
            return new ReadOnlyCollection<Note>(o.Root.Select(note => new Note(note.ToString())).ToList());
        }

        #endregion

        internal void CheckLoginStatus()
        {
            if (String.IsNullOrWhiteSpace(ApiToken))
                throw new ArgumentNullException(ApiToken, "You must login to do that.");
        }
    }
}