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
    public class Note
    {
        private readonly string _content;
        private readonly int _id;
        private readonly int _itemId;
        private readonly string _jsonData;

        internal Note(string jsonData)
        {
            JArray o = JArray.Parse(jsonData);

            _id = (int) o.SelectToken("id");
            _itemId = (int) o.SelectToken("item_id");
            _content = (string) o.SelectToken("content");

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
        public int ItemId
        {
            get { return _itemId; }
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
        public string JsonData
        {
            get { return _jsonData; }
        }
    }
}