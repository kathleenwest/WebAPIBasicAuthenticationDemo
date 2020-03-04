using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Web.Http;
using WebAPIService.Models;

namespace WebAPIService.Controllers
{
    /// <summary>
    /// RegistrationController
    /// Controller responsible for registering users
    /// to use the Web API methods that require
    /// authentication
    /// </summary>
    public class RegistrationController : ApiController
    {
        #region Fields and Properties

        // Memory Cache
        ObjectCache cache = MemoryCache.Default;

        // List of Registered Users
        public List<User> RegisteredUsers { get; private set; }

        // Represents the Authentication Scheme
        private const string SCHEME = "Basic";

        #endregion Fields and Properties

        /// <summary>
        /// RegistrationController
        /// Constructor
        /// Cache simulates calls to/from database backend
        /// </summary>
        public RegistrationController()
        {
            // Cache for Registered Users for Web API Authentication
            if (!cache.Contains("RegisteredUsers"))
            {
                // Simple List of People for CRUD Example
                RegisteredUsers = new List<User>();

                // Add Admin Username/Password
                RegisteredUsers.Add(new Models.User("admin", "god"));

                // Add Generic Test User
                RegisteredUsers.Add(new Models.User("testuser", "password"));

                // Cache Expiration set to 30 minutes in the future
                CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30) };

                // Add a new Cache!
                cache.Add("RegisteredUsers", RegisteredUsers, policy);

            } // end of if
        } // end of method

        /// <summary>
        /// GET: api/Registration
        /// Gets an IEnumerable list of type string
        /// registered users in this Web API application
        /// </summary>
        /// <returns>IEnumerable list of type string</returns>
        public IEnumerable<string> Get()
        {
            RegisteredUsers = (List<User>)cache.Get("RegisteredUsers");
            return RegisteredUsers.Select(s => s.ToString()).ToList();
        } // end of method

        /// <summary>
        /// GET: api/Registration/5
        /// Gets a single string value of a registered user
        /// in the index of the list. Returns a bad request
        /// if the index is out of range.
        /// </summary>
        /// <param name="id">index of the registered user</param>
        /// <returns>string of the registered user at the index</returns>
        public string Get(int id)
        {
            // Get the List of Entities from the Cache
            RegisteredUsers = (List<User>)cache.Get("RegisteredUsers");

            // Don't Process if ID is out of Range 0-entity,count
            if (id >= RegisteredUsers.Count || id < 0)
            {
                // Make a bad response and throw it
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(message);
            }
            else
            {
                return RegisteredUsers[id].ToString();
            }
        } // end of method

        /// <summary>
        /// POST: api/Registration
        /// This method extracts the username and password
        /// from the authorization header in the http request
        /// and adds it to a list of registered users
        /// </summary>
        /// <param name="value">not used</param>
        public void Post([FromBody]string value)
        { 
            // Get current request
            HttpRequestMessage request = this.Request;

            // Extract the headers from the request
            HttpRequestHeaders headers = request.Headers;

            // Check to see if the authorization header is not null AND
            // Check to see if the authorization scheme matches our design (ex: Basic)
            if (headers.Authorization != null && SCHEME.Equals(headers.Authorization.Scheme))
            {
                // Try to parse the encoded username and password
                // Assume user id and password Base64 encoded as "userid:password"

                // Assume the encoding scheme
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");

                // Takes the information out of the authorization header
                // Convert from a Base64 Encoded string to a regular string
                string credentials = encoding.GetString(Convert.FromBase64String(headers.Authorization.Parameter));

                // Split the information
                string[] parts = credentials.Split(':');

                // obtain the username
                string username = parts[0].Trim();

                // obtain the password
                string password = parts[1].Trim();

                // Verify User is not already registered
                // First try to find a registered user from the Memory Cache
                // Cache for Registered Users for Web API Authentication
                if (cache.Contains("RegisteredUsers"))
                {
                    // Get the List of Entities from the Cache
                    RegisteredUsers = (List<User>)cache.Get("RegisteredUsers");

                    // Try to find an existing user in the registered users
                    User user = RegisteredUsers.FirstOrDefault(x => x.UserName == username);

                    if (user == null)
                    {
                        // Create a new user
                        user = new User(username, password);

                        // Add to the cache
                        RegisteredUsers.Add(user);

                    }
                    else
                    {
                        // Duplicate User
                        // Make a bad response and throw it
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Conflict);
                        response.ReasonPhrase = "User already registered. Please choose a different username.";
                        throw new HttpResponseException(response);
                    }

                } // end of if

            } // end of if
            else
            {
                // Make a bad response and throw it
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Request authorization header cannot be null or must use BASIC scheme.";
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(SCHEME));
                throw new HttpResponseException(response);
            }

        } // end of method

        //// PUT: api/Registration/5
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="value"></param>
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Registration/5
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        //public void Delete(int id)
        //{
        //}

    } // end of class
} // end of namespace
