using System;
using System.IO;
using System.Net;

namespace TodoistDotNet
{
    public class Core
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> generated in <see cref="Core.ConstructUri"/></param>
        /// <returns></returns>
        public static string GetJsonData(Uri uri)
        {
            WebRequest request = WebRequest.Create(uri);
            var response = (HttpWebResponse) request.GetResponse();
            string json;
            using (var sr = new StreamReader(response.GetResponseStream()))
                json = sr.ReadToEnd();
            return json;
        }

        /// <summary>
        /// Constructs a URI 
        /// </summary>
        /// <param name="query">The URL parameter, e.g. login? or getTimezones?</param>
        /// <param name="parameters">The parameters for the <paramref name="query"/>, e.g. email="x"&"password="y". 
        ///                          Must always be separated with an ampersand</param>
        /// <param name="isSecure">Specifies if the connection to the server must be secure, i.e. https or http. Defaults to http.</param>
        /// <returns>Returns a <see cref="Uri"/>.</returns>
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