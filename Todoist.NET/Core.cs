// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Core.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Static methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Static methods.
    /// </summary>
    public static class Core
    {
        #region Public Methods

        /// <summary>
        /// Constructs a URI for Todoist.com.
        /// </summary>
        /// <param name="query">
        /// Query for todoist.com/API ending with a question mark.
        /// </param>
        /// <param name="parameters">
        /// URL parameters separated by ampersand.
        /// </param>
        /// <param name="isSecure">
        /// Http or Https.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/>
        /// </returns>
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

        /// <summary>
        /// Returns JSON data from Todoist.com. Timeout period is 30 seconds.
        /// </summary>
        /// <param name="uri">
        /// The <see cref="Uri"/> generated in <see cref="Core.ConstructUri"/>
        /// </param>
        /// <exception cref="WebException">
        /// Throws <see cref="WebException"/> if the connection times out.
        /// </exception>
        /// <returns>
        /// A <see cref="string"/> of JSON data.
        /// </returns>
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
            {
                json = sr.ReadToEnd();
            }

            return json;
        }

        #endregion
    }
}