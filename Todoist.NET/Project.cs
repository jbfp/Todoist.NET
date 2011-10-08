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

using Newtonsoft.Json.Linq;

namespace Todoist.NET
{
    /// <summary>
    /// 
    /// </summary>
    public class Project
    {
        private readonly int _cacheCount;
        private readonly TodoistColor _color;
        private readonly int _id;
        private readonly int _indent;
        private readonly int _itemOrder;
        private readonly string _jsonData;
        private readonly string _name;
        private readonly int _ownerId;
        private readonly bool _isGroup;
        private readonly int _isSubProjectsCollapsed;

        internal Project(string jsonData)
        {
            JObject o = JObject.Parse(jsonData);

            _ownerId = (int) o.SelectToken("user_id");
            _name = (string) o.SelectToken("name");
            _indent = (int) o.SelectToken("indent");
            _cacheCount = (int) o.SelectToken("cache_count");
            _id = (int) o.SelectToken("id");
            _itemOrder = (int) o.SelectToken("item_order");
            _isSubProjectsCollapsed = (int) o.SelectToken("collapsed");
            _isGroup = _name[0] == '*';

            switch ((string) o.SelectToken("color"))
            {
                case "#bde876":
                    _color = new TodoistColor(TodoistColorEnum.Green);
                    break;
                case "#ff8581":
                    _color = new TodoistColor(TodoistColorEnum.Red);
                    break;
                case "#ffc472":
                    _color = new TodoistColor(TodoistColorEnum.Orange);
                    break;
                case "#faed75":
                    _color = new TodoistColor(TodoistColorEnum.Yellow);
                    break;
                case "#a8c9e5":
                    _color = new TodoistColor(TodoistColorEnum.Blue);
                    break;
                case "#999999":
                    _color = new TodoistColor(TodoistColorEnum.MediumGrey);
                    break;
                case "#e3a8e5":
                    _color = new TodoistColor(TodoistColorEnum.Pink);
                    break;
                case "#dddddd":
                    _color = new TodoistColor(TodoistColorEnum.LightGrey);
                    break;
                case "#fc603c":
                    _color = new TodoistColor(TodoistColorEnum.Flame);
                    break;
                case "#ffcc00":
                    _color = new TodoistColor(TodoistColorEnum.Gold);
                    break;
                case "#74e8d4":
                    _color = new TodoistColor(TodoistColorEnum.LightOpal);
                    break;
                case "#3cd6fc":
                    _color = new TodoistColor(TodoistColorEnum.BrilliantCerulean);
                    break;
            }

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
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGroup
        {
            get { return _isGroup; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CacheCount
        {
            get { return _cacheCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public TodoistColor Color
        {
            get { return _color; }
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
        public int ItemOrder
        {
            get { return _itemOrder; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSubProjectsCollapsed
        {
            get { return _isSubProjectsCollapsed == 1; }
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