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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Todoist.NET
{
    /// <summary>
    /// 
    /// </summary>
    public enum StartPage
    {
        InfoPage,
        Blank,
        ProjectX
    }

    /// <summary>
    /// 
    /// </summary>
    public enum TimeFormat
    {
        TwentyFourHourClock = 0,
        TwelveHourClock = 1
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DateFormat
    {
        DdMmYyyy = 0,
        MmDdYyyy = 1
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SortOrder
    {
        OldestDatesFirst = 0,
        NewestDatesFirst = 1
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DefaultReminder
    {
        Email,
        Mobile,
        Notifo,
        NoDefault
    }

    /// <summary>
    /// 
    /// </summary>
    public enum LoginResult
    {
        LoginFailed,
        LoginSucceeded
    }

    /// <summary>
    /// 
    /// </summary>
    public struct TimeZoneOffset
    {
        public string GmtString;
        public int HourOffset;
        public bool IsDaylightSavingsTime;
        public int MinuteOffset;

        public TimeZoneOffset(string gmtString,
                              int hourOffset,
                              int minuteOffset,
                              bool isDaylightSavingsTime)
        {
            GmtString = gmtString;
            HourOffset = hourOffset;
            MinuteOffset = minuteOffset;
            IsDaylightSavingsTime = isDaylightSavingsTime;
        }
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
        private string[] _timeZone;
        private TimeZoneOffset _timeZoneOffset;

        public int Id
        {
            get { return _id; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string FullName
        {
            get { return _fullName; }
        }

        public string ApiToken
        {
            get { return _apiToken; }
        }

        public StartPage? StartPage
        {
            get { return _startPage; }
        }

        public string[] TimeZone
        {
            get { return _timeZone; }
        }

        public TimeZoneOffset TimeZoneOffset
        {
            get { return _timeZoneOffset; }
        }

        public TimeFormat TimeFormat
        {
            get { return _timeFormat; }
        }

        public DateFormat DateFormat
        {
            get { return _dateFormat; }
        }

        public SortOrder SortOrder
        {
            get { return _sortOrder; }
        }

        public string NotifoAccount
        {
            get { return _notifoAccount; }
        }

        public string MobileNumber
        {
            get { return _mobileNumber; }
        }

        public string MobileHost
        {
            get { return _mobileHost; }
        }

        public string PremiumUntil
        {
            get { return _premiumUntil; }
        }

        public DefaultReminder DefaultReminder
        {
            get { return _defaultReminder; }
        }

        public string JsonData
        {
            get { return _jsonData; }
        }

        #endregion

        #region User

        public User()
        {
            ResetUser();
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
            ResetUser();
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();

            Uri uri = Core.ConstructUri(
                "login?",
                String.Format("email={0}&password={1}", email, password),
                true);
            string tempJson = Core.GetJsonData(uri);

            if (tempJson == "\"LOGIN_ERROR\"")
            {
                throw new LoginFailedException("Login failed.", new Exception(tempJson));
            }

            _jsonData = tempJson;
            AnalyseJson();

            return LoginResult.LoginSucceeded;
        }

        public void ResetUser()
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

        /// <summary>
        /// 
        /// </summary>
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

            JToken tz = o.SelectToken("timezone");
            _timeZone = tz.ToString().Split('/');

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
        /// <param name="timezone">The new user's timezone in "Europe/Copenhagen" format.</param>
        /// <exception cref="RegistrationFailedException"><see cref="RegistrationFailedException"/></exception>
        public void Register(string email, string fullName, string password, string timezone)
        {
            Uri uri = Core.ConstructUri("register?",
                                        String.Format("email={0}&" +
                                                      "full_name={1}&" +
                                                      "password={2}&" +
                                                      "timezone={3}", email, fullName,
                                                      password, timezone),
                                        true);
            string jsonResponse = Core.GetJsonData(uri);

            switch (jsonResponse)
            {
                case "\"ALREADY_REGISTRED\"":
                    throw new RegistrationFailedException(
                        "The e-mail address provided has already been registered with Todoist with another account.",
                        new Exception(jsonResponse));
                case "\"TOO_SHORT_PASSWORD\"":
                    throw new RegistrationFailedException(
                        "The password provided is too short. It must at least 5 characters long.",
                        new Exception(jsonResponse));
                case "\"INVALID_EMAIL\"":
                    throw new RegistrationFailedException(
                        "The e-mail address provided is invalid. Please use a valid e-mail address.",
                        new Exception(jsonResponse));
                case "\"INVALID_TIMEZONE\"":
                    throw new RegistrationFailedException(
                        "The timezone provided is invalid. Please use the format \"Europe/Copenhagen\"",
                        new Exception(jsonResponse));
                case "\"INVALID_FULL_NAME\"":
                    throw new RegistrationFailedException("The name provided is invalid.",
                                                          new Exception(jsonResponse));
                case "\"UNKNOWN_ERROR\"":
                    throw new RegistrationFailedException("Unknown error. Please try again."
                                                          , new Exception(jsonResponse));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="fullName"></param>
        /// <param name="password"></param>
        /// <param name="timeZone"></param>
        /// <param name="dateFormat"></param>
        /// <param name="timeFormat"></param>
        /// <param name="startPage"></param>
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
                        "The password provided is too short. It must be at least 5 characters long.",
                        new Exception(jsonResponse));
                case "\"ERROR_EMAIL_FOUND\"":
                    throw new UpdateUserException(
                        "The e-mail address provided has already been registered with Todoist with another account.",
                        new Exception(jsonResponse));
            }

            _jsonData = jsonResponse;
            AnalyseJson();
        }

        #endregion

        #region Project

        /// <summary>
        /// Returns all of user's projects.
        /// </summary>
        public List<Project> GetProjects()
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getProjects?", "token=" + ApiToken, false);
            string jsonResponse = Core.GetJsonData(uri);

            JArray o = JArray.Parse(jsonResponse);
            return o.Root.Select(p => new Project(p.ToString())).ToList();
        }

        /// <summary>
        /// Return's data about a project. It does not have to be a project in the collection, 
        /// but it must still be a project the user owns. This will not add the project to the collection.
        /// </summary>
        /// <param name="projectId"></param>
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
                throw new ProjectException("Project not found.", new Exception(jsonResponse));
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
        /// <param name="projectName"></param>
        /// <param name="color"></param>
        /// <param name="indent"></param>
        /// <param name="order"></param>
        public void CreateProject(string projectName, int indent, int order, TodoistColor color)
        {
            CheckLoginStatus();

            if (indent < 1 || indent > 4)
            {
                throw new ArgumentOutOfRangeException(indent.ToString(),
                                                      new Exception("The indent value must be between 1 and 4."));
            }

            Uri uri = Core.ConstructUri("addProject?",
                                        String.Format("token={0}&name={1}&indent={2}&order={3}&color={4}",
                                                      ApiToken, projectName, indent, order,
                                                      color.TodoistColorEnum.GetHashCode()),
                                        false);
            string jsonResponse = Core.GetJsonData(uri);
            if (jsonResponse == "\"ERROR_NAME_IS_EMPTY\"")
            {
                throw new ProjectException("The project name cannot be null.",
                                           new Exception(jsonResponse));
            }
        }

        /// <summary>
        /// Update an existing project.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="indent"></param>
        /// <param name="itemOrder"></param>
        /// <param name="isCollapsed"></param>
        public void UpdateProject(int projectId, string name, TodoistColorEnum? color, int? indent, int? itemOrder,
                                  bool? isCollapsed)
        {
            CheckLoginStatus();

            TodoistColorEnum? internalColor = color;
            if (color == null)
                internalColor = GetProject(projectId).Color.TodoistColorEnum;


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
                throw new ProjectException("Name cannot be null.",
                                           new Exception(jsonResponse));
        }

        /// <summary>
        /// Updates how the projects are ordered.
        /// </summary>
        /// <param name="order"></param>
        public void UpdateProjectOrders(int[] order)
        {
            CheckLoginStatus();

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
                throw new NullReferenceException();
        }

        /// <summary>
        /// Delete an existing project. Call <see cref="GetProjects"/> on the project collection to refresh it.
        /// </summary>
        /// <param name="projectId"></param>
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
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<Item> GetUncompletedItemsByProjectId(int projectId)
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
                throw new ProjectException("Project not found.", new Exception(jsonResponse));
            }

            JArray o = JArray.Parse(jsonResponse);
            return new List<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
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
        public List<Item> GetAllCompletedItems(int? projectId, string label, string interval)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getAllCompletedItems?",
                                        String.Format("token={0}&project_id={1}&label={2}&interval={3}",
                                                      ApiToken, projectId, label, interval), false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
            {
                throw new ProjectException("Project not found.", new Exception(jsonResponse));
            }

            JObject o = JObject.Parse(jsonResponse);
            return new List<Item>(o.Root.First.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Returns a project's completed items (tasks) - the tasks that are in history.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>Returns a project's completed items (tasks) - the tasks that are in history.</returns>
        public List<Item> GetCompletedItemsByProjectId(int projectId)
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
                throw new ProjectException("Project not found.", new Exception(jsonResponse));
            }

            JArray o = JArray.Parse(jsonResponse);
            return new List<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
        }

        /// <summary>
        /// Returns a list of items by id.
        /// </summary>
        /// <param name="itemIds"></param>
        /// <returns>Returns a list of items by id.</returns>
        public List<Item> GetItemsById(int[] itemIds)
        {
            CheckLoginStatus();

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
            return new List<Item>(o.Root.Select(item => new Item(item.ToString())).ToList());
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
                                                      new Exception("Priority must be between 1 and 4."));
            if (indent < 1 || indent > 4)
                throw new ArgumentOutOfRangeException(indent.ToString(),
                                                      new Exception("Indent must be between 1 and 4."));

            Uri uri = Core.ConstructUri("addItem?",
                                        String.Format(
                                            "token={0}&project_id={1}&content={2}&priority={3}&indent={4}&item_order={5}",
                                            ApiToken, projectId,
                                            content, priority, indent, itemOrder), false);
            string jsonResponse = Core.GetJsonData(uri);

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
                throw new ProjectException("Project not found.", new Exception(jsonResponse));
            if (jsonResponse == "\"ERROR_WRONG_DATE_SYNTAX\"")
                throw new ItemException("Wrong date syntax.", new Exception(jsonResponse));
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
                throw new ItemException("Item not found.", new Exception(jsonResponse));
        }

        /// <summary>
        /// Update the order of a project's tasks.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="itemIds"></param>
        public void UpdateItemOrdering(int projectId, int[] itemIds)
        {
            CheckLoginStatus();

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

            if (jsonResponse == "\"ERROR_PROJECT_NOT_FOUND\"")
                throw new ProjectException("Project not found.", new Exception(jsonResponse));
        }

        /// <summary>
        /// Move items from one project to another.
        /// </summary>
        public void MoveItem(int projectId)
        {
            CheckLoginStatus();
        }

        /// <summary>
        /// Update recurring dates and set them to next date regarding an item's date_string.
        /// </summary>
        /// <param name="itemIds"></param>
        public void UpdateRecurringDate(int[] itemIds)
        {
            CheckLoginStatus();

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
        /// Uncomplete items and move them to the active projects.
        /// </summary>
        /// <param name="itemIds">The item ids, which are to be uncompleted.</param>
        public void UncompleteItems(int[] itemIds)
        {
            CheckLoginStatus();

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
        public List<Note> GetNotesFromItemId(int itemId)
        {
            CheckLoginStatus();

            Uri uri = Core.ConstructUri("getNotes?", String.Format("token={0}&item_id={1}", ApiToken, itemId), false);
            string jsonResponse = Core.GetJsonData(uri);

            JArray o = JArray.Parse(jsonResponse);
            return new List<Note>(o.Root.Select(note => new Note(note.ToString())).ToList());
        }

        #endregion

        internal void CheckLoginStatus()
        {
            if (String.IsNullOrWhiteSpace(ApiToken))
                throw new NullReferenceException("You must login to do that.");
        }
    }
}