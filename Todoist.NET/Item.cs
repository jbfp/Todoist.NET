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
using Newtonsoft.Json.Linq;

namespace Todoist.NET
{
    /// <summary>
    /// 
    /// </summary>
    public class Item
    {
        private readonly string _content;
        private readonly string _dateString;
        private readonly string _dueDate;
        private readonly int _id;
        private readonly int _indent;
        private readonly bool _isChecked;
        private readonly bool _isInHistory;
        private readonly bool _isSubTasksCollapsed;
        private readonly int _itemOrder;
        private readonly int _ownerId;
        private readonly int _priority;
        private readonly int _projectId;
        private readonly string _jsonData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonData"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="jsonData"/> is null.</exception>
        public Item(string jsonData)
        {
            JObject o = JObject.Parse(jsonData);

            if (o.First == null)
                throw new ArgumentNullException(jsonData);

            _id = (int) o.SelectToken("id");
            _ownerId = (int) o.SelectToken("user_id");
            _isSubTasksCollapsed = Convert.ToBoolean((int) o.SelectToken("collapsed"));
            _isInHistory = Convert.ToBoolean((int) o.SelectToken("in_history"));
            _priority = (int) o.SelectToken("priority");
            _itemOrder = (int) o.SelectToken("item_order");
            _content = (string) o.SelectToken("content");
            _indent = (int) o.SelectToken("indent");
            _projectId = (int) o.SelectToken("project_id");
            _isChecked = Convert.ToBoolean((int) o.SelectToken("checked"));
            _dateString = (string) o.SelectToken("date_string");
            _dueDate = (string) o.SelectToken("due_date");
            _jsonData = jsonData;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int OwnerId
        {
            get { return _ownerId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSubtasksCollapsed
        {
            get { return _isSubTasksCollapsed; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsInHistory
        {
            get { return _isInHistory; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Priority
        {
            get { return _priority; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ItemOrder
        {
            get { return _itemOrder; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get { return _content; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Indent
        {
            get { return _indent; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectId
        {
            get { return _projectId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsChecked
        {
            get { return _isChecked; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DateString
        {
            get { return _dateString; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DueDate
        {
            get { return _dueDate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string JsonData
        {
            get { return _jsonData; }
        }
    }
}