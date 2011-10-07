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
    public class Item
    {
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

            Id = (int) o.SelectToken("id");
            OwnerId = (int) o.SelectToken("user_id");
            IsSubTasksCollapsed = Convert.ToBoolean((int) o.SelectToken("collapsed"));
            IsInHistory = Convert.ToBoolean((int) o.SelectToken("in_history"));
            Priority = (int) o.SelectToken("priority");
            ItemOrder = (int) o.SelectToken("item_order");
            Content = (string) o.SelectToken("content");
            Indent = (int) o.SelectToken("indent");
            ProjectId = (int) o.SelectToken("project_id");
            IsChecked = Convert.ToBoolean((int) o.SelectToken("checked"));
            DateString = (string) o.SelectToken("date_string");
            DueDate = (string) o.SelectToken("due_date");
            JsonData = jsonData;
        }

        public int Id { get; private set; }
        public int OwnerId { get; private set; }
        public bool IsSubTasksCollapsed { get; private set; }
        public bool IsInHistory { get; private set; }
        public int Priority { get; private set; }
        public int ItemOrder { get; private set; }
        public string Content { get; private set; }
        public int Indent { get; private set; }
        public int ProjectId { get; private set; }
        public bool IsChecked { get; private set; }
        public string DateString { get; private set; }
        public string DueDate { get; private set; }
        public string JsonData { get; private set; }
    }
}