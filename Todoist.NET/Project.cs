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
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Todoist.NET
{
    public class Project
    {
        private int _isSubProjectsCollapsed;
        private string _name;

        internal Project(string jsonData)
        {
            JObject o = JObject.Parse(jsonData);

            OwnerId = (int) o.SelectToken("user_id");
            Name = (string) o.SelectToken("name");
            Indent = (int) o.SelectToken("indent");
            CacheCount = (int) o.SelectToken("cache_count");
            Id = (int) o.SelectToken("id");
            ItemOrder = (int) o.SelectToken("item_order");
            IsSubProjectsCollapsed = (int) o.SelectToken("collapsed") == 1;

            switch ((string) o.SelectToken("color"))
            {
                case "#bde876":
                    Color = new TodoistColor(TodoistColorEnum.Green);
                    break;
                case "#ff8581":
                    Color = new TodoistColor(TodoistColorEnum.Red);
                    break;
                case "#ffc472":
                    Color = new TodoistColor(TodoistColorEnum.Orange);
                    break;
                case "#faed75":
                    Color = new TodoistColor(TodoistColorEnum.Yellow);
                    break;
                case "#a8c9e5":
                    Color = new TodoistColor(TodoistColorEnum.Blue);
                    break;
                case "#999999":
                    Color = new TodoistColor(TodoistColorEnum.MediumGrey);
                    break;
                case "#e3a8e5":
                    Color = new TodoistColor(TodoistColorEnum.Pink);
                    break;
                case "#dddddd":
                    Color = new TodoistColor(TodoistColorEnum.LightGrey);
                    break;
                case "#fc603c":
                    Color = new TodoistColor(TodoistColorEnum.Flame);
                    break;
                case "#ffcc00":
                    Color = new TodoistColor(TodoistColorEnum.Gold);
                    break;
                case "#74e8d4":
                    Color = new TodoistColor(TodoistColorEnum.LightOpal);
                    break;
                case "#3cd6fc":
                    Color = new TodoistColor(TodoistColorEnum.BrilliantCerulean);
                    break;
            }

            JsonData = jsonData;
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value.Replace("*", String.Empty);
                IsGroup = value.ElementAt(0) == '*';
            }
        }

        public bool IsGroup { get; private set; }
        public int CacheCount { get; private set; }
        public TodoistColor Color { get; set; }
        public int Indent { get; private set; }
        public int ItemOrder { get; set; }

        public bool IsSubProjectsCollapsed
        {
            get { return _isSubProjectsCollapsed == 1; }
            set { _isSubProjectsCollapsed = value ? 1 : 0; }
        }

        public string JsonData { get; private set; }
    }
}