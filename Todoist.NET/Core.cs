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
using System.IO;
using System.Net;

namespace Todoist.NET
{
    /// <summary>
    /// 
    /// </summary>
    public static class Core
    {
        /// <summary>
        /// Returns JSON data from Todoist.com. Timeout period is 30 seconds.
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> generated in <see cref="Core.ConstructUri"/></param>
        /// <exception cref="WebException"></exception>
        /// <returns><see cref="string"/></returns>
        public static string GetJsonData(Uri uri)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Timeout = 30000;
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException webException)
            {
                throw new WebException(webException.Message);
            }
            string json;
            using (var sr = new StreamReader(response.GetResponseStream()))
                json = sr.ReadToEnd();
            return json;
        }

        /// <summary>
        /// Constructs a URI for Todoist.com
        /// </summary>
        /// <param name="query">Query for todoist.com/API ending with a question mark</param>
        /// <param name="parameters">URL parameters separated by ampersand</param>
        /// <param name="isSecure">Http or Https</param>
        /// <returns><see cref="Uri"/></returns>
        public static Uri ConstructUri(string query, string parameters, bool isSecure)
        {
            string protocol;
            switch (isSecure)
            {
                case true:
                    protocol = "https://";
                    break;
                case false:
                    protocol = "http://";
                    break;
                default:
                    goto case false;
            }
            var baseUri = new Uri(protocol + "todoist.com/API/" + query + parameters);
            return baseUri;
        }
    }
}