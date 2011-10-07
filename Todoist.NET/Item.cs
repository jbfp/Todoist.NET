using Newtonsoft.Json.Linq;
using System;

namespace TodoistDotNet
{
    public class Item
    {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonData"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="jsonData"/> is null.</exception>
        public Item(string jsonData)
        {
            var o = JObject.Parse(jsonData);
            
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
    }
}