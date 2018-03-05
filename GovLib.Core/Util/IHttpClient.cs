using System.Collections.Generic;

namespace GovLib.Util
{
    /// <summary>
    /// Contract for making HTTP requests.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Make an HTTP get request and return the response string..
        /// </summary>
        /// <param name="url">URL to make the HTTP request to.</param>
        /// <param name="headers">Headers to append to the HTTP request.</param>
        /// <returns>HTTP reponse string.</returns>
        string Get(string url, Dictionary<string, string> headers = null);
    }
}