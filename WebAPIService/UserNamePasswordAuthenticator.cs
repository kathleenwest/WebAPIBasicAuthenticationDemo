using System.Linq;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Text;
using WebAPIService.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Caching;
using System.Diagnostics;

namespace WebAPIService
{
    /// <summary>
    /// UserNamePasswordAuthenticator
    /// Custom User Name and Password Validator
    /// ........................
    /// Description:
    /// Documentation Reference
    /// https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-use-a-custom-user-name-and-password-validator
    /// .......................
    /// See project blog article for lessons learned and project architecture
    /// </summary>
    public class UserNamePasswordAuthenticator
    {
        // Memory Cache
        ObjectCache cache = MemoryCache.Default;

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="username">(string) User credential "username"</param>
        /// <param name="password">(string) User credential "password"</param>
        public bool Validate(string username, string password)
        {
            // User
            User user;

            #region ValidateUserRegistration

            // First try to find a registered user from the Memory Cache
            // Cache for Registered Users for Web API Authentication
            if (cache.Contains("RegisteredUsers"))
            {
                // Get the List of Entities from the Cache
                List<User> RegisteredUsers = (List<User>)cache.Get("RegisteredUsers");

                user = RegisteredUsers.FirstOrDefault(x => x.UserName == username);

                // Allow the Service Registration to Handle Unregistered User
                if (user == null)
                {
                    // Do not validate non-existing users
                    return false;
                }

            } // end of if

            else
            {
                // Cache does not contain registered users... or not setup
                return false;
            }
           
            #endregion ValidateUserRegistration


            #region AuthenticateRegisteredUser

            // Convert Password to Compare to Database Password
            // Password-Based Key Derivation Function
            byte[] bytesPassword = Encoding.Unicode.GetBytes(password);
            // Note: Cryptology values may not be suitable for production level, this is only a demo
            byte[] passwordHash = ServiceCryptology.GenerateHash(bytesPassword, user.Salt, user.WorkFactor, 256);

            // Authenticate the Existing User Password
            if (user != null && System.Text.Encoding.Default.GetString(user.Password) == System.Text.Encoding.Default.GetString(passwordHash))
            {
                // Authenticated, no other action necessary
                return true;
            }
            else
            {
                Debug.WriteLine("Unknown Username or Incorrect Password");
                throw new SecurityTokenException("Unknown Username or Incorrect Password");
            }

            #endregion AuthenticateRegisteredUser

        } // end of method

    } // end of class
} // end of namespace