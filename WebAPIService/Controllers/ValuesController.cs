using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Caching;
using System.Diagnostics;
using WebAPIService.Models;
using System.Net.Http.Headers;
using System.Text;

namespace WebAPIService.Controllers
{
    /// <summary>
    /// ValuesController
    /// Web API Controller for the Demo
    /// Services CRUD requests for the Demo project
    /// </summary>
    public class ValuesController : ApiController
    {
        #region Fields and Properties

        // Memory Cache
        ObjectCache cache = MemoryCache.Default;

        // List of people
        List<string> people;

        // List of Registered Users
        public List<User> RegisteredUsers { get; private set; }

        // Represents the Authentication Scheme
        //private const string SCHEME = "Basic";

        #endregion Fields and Properties

        /// <summary>
        /// ValuesController
        /// Constructs temporary caches that simulates
        /// calls to backend databases. 
        /// </summary>
        public ValuesController()
        {
            // Cache of people entities representing characters from
            // Star Trek TNG for use in CRUD 
            if (!cache.Contains("People"))
            {
                // Simple List of People for CRUD Example
                people = new List<string>();

                // Add some generic values
                people.Add("Patrict Stewart");
                people.Add("Brent Spiner");
                people.Add("Jonathon Frakes");
                people.Add("Marina Sirtus");
                people.Add("Gates McFadden");
                people.Add("Michael Dorn");
                people.Add("LeVar Burton");
                people.Add("Wil Wheaton");
                people.Add("Denise Crosby");
                people.Add("Majel Barrett");
                people.Add("Colm Meaney");
                people.Add("Whoopi Goldberg");
                people.Add("John Di Lancie");
                people.Add("Diana Muldaur");
                people.Add($"Cached: {DateTime.Now.ToLongTimeString()}");

                // Cache Expiration set to 2 minutes in the future
                CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2) };

                // Add a new Cache!
                cache.Add("People", people, policy);

            } // end of if

            // Cache for Registered Users for Web API Authentication
            if (!cache.Contains("RegisteredUsers"))
            {
                // Simple List of People for CRUD Example
                RegisteredUsers = new List<User>();

                // Add Admin Username/Password
                RegisteredUsers.Add(new Models.User("admin","god"));

                // Add Generic Test User
                RegisteredUsers.Add(new Models.User("testuser", "password"));

                // Cache Expiration set to 30 minutes in the future
                CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30) };

                // Add a new Cache!
                cache.Add("RegisteredUsers", RegisteredUsers, policy);

            } // end of if

        } // end of constructor

        /// <summary>
        /// Get (Collection)
        /// Gets the entire collection of the entities
        /// GET api/values
        /// </summary>
        /// <returns>a collection (IEnumerable) of entities </returns>
        public IEnumerable<string> Get()
        {
            // Get the List of Entities from the Cache
            return (List<string>)cache.Get("People");

        } // end of method

        /// <summary>
        /// Get (Single)
        /// Gets the entity by the identifier
        /// GET api/values/5
        /// IF index out of range => Returns a HttpStatusCode.BadRequest
        /// </summary>
        /// <param name="id">identifier (int) of the entity</param>
        /// <returns>the entity value (string) at the identifer</returns>
        public string Get(int id)
        {
            // Get the List of Entities from the Cache
            people = (List<string>)cache.Get("People");

            // Don't Process if ID is out of Range 0-entity,count
            if (id >= people.Count || id < 0)
            {
                // Make a bad response and throw it
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(message);
            }
            else
            {
                return people[id];
            }         
        } // end of method

        /// <summary>
        /// Post
        /// Adds a new entity to the collection
        /// POST api/values
        /// </summary>
        /// <param name="value">the value (string) of the entity</param>
        [Authorize]
        public void Post([FromBody]string value)
        {
            // Get the List of Entities from the Cache
            people = (List<string>)cache.Get("People");

            // Add the entity
            people.Add(value);
         
        } // end of method

        /// <summary>
        /// Put
        /// Replaces the entity with an identifier with a new value.
        /// PUT api/values/5
        /// IF index out of range => Returns a HttpStatusCode.BadRequest
        /// </summary>
        /// <param name="id">identifier (int) of the entity to replace</param>
        /// <param name="value">value (string) to replace the existing entity value</param>
        [Authorize]
        public void Put(int id, [FromBody]string value)
        {
            // Get the List of Entities from the Cache
            people = (List<string>)cache.Get("People");

            // Don't Process if ID is out of Range 0-entity,count
            if (id >= people.Count || id < 0)
            {
                // Make a bad response and throw it
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(message);
            }

            //Update the Entity
            people[id] = value;

        } // end of method

        /// <summary>
        /// Delete
        /// Deletes an entity based on the id
        /// DELETE api/values/5
        /// IF index out of range => Returns a HttpStatusCode.BadRequest
        /// </summary>
        /// <param name="id">identifier (id) of the entity</param>
        [Authorize]
        public void Delete(int id)
        {
            // Get the List of Entities from the Cache
            people = (List<string>)cache.Get("People");

            // Don't Process if ID is out of Range 0-entity,count
            if (id >= people.Count || id < 0)
            {
                // Make a bad response and throw it
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(message);
            }

            // Delete the Entity
            people.RemoveAt(id);

        } // end of method

    } // end of class
} // end of namespace
