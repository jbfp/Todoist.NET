using Newtonsoft.Json.Linq;

namespace TodoistDotNet
{
    public class Note
    {
        public Note(string jsonData)
        {
            JArray o = JArray.Parse(jsonData);

            Id = (int) o.SelectToken("id");
            ItemId = (int) o.SelectToken("item_id");
            Content = (string) o.SelectToken("content");

            JsonData = jsonData;
        }

        public int Id { get; private set; }
        public int ItemId { get; private set; }
        public string Content { get; private set; }
        public string JsonData { get; private set; }
    }
}