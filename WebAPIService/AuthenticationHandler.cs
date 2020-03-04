using System;
using System.Collections.Generic;
using System.Net;
using System.IdentityModel.Tokens;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebAPIService
{
    /// <summary>
    /// AuthenticationHandler
    /// This is a message handler that processes the user
    /// authentication to the Web API. This custom message handler
    /// should be added first to the processing pipeline. 
    /// Add this handler to the WebApiConfig file Registration under App_Start
    /// config.MessageHandlers.Add(new AuthenticationHandler());
    /// </summary>
    public class AuthenticationHandler : DelegatingHandler
    {
        // Represents the Authentication Scheme
        private const string SCHEME = "Basic";

        /// <summary>
        /// SendAsync
        /// TPL Message Handler for Authentication
        /// This method gets called as the application "chains" through
        /// its event handlers and the pipeline
        /// TPL cancellation token allows monitoring and cancellation 
        /// of the request. This demo does not monitor cancellation requests.
        /// Processes the Incoming Http Request Message
        /// Calls the base message handler to continue the processing pipeline
        /// Processes the final outgoing Http Response Message
        /// </summary>
        /// <param name="request">the incoming http request message object from the client</param>
        /// <param name="cancellationToken">a cancellation token that allows cancellation</param>
        /// <returns>a Task with the HttpResponseMessage object</returns>
		protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                    CancellationToken cancellationToken)
        {
            try
            {
                // Perform custom processing of the incoming http request
                ProcessRequestMessage(request);

                // Re-enter Processing Pipeline
                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

                // Exited the Processing Pipeline...
                // Perform custom response processing
                ProcessResponseMessage(response);

                // Return the response
                return response;
            } // end of try

            // Assumes an exception is due to user not being authorized
            catch (Exception)
            {
                // create a new http response with the status code of unauthorized
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Unauthorized);

                // Add the authorization scheme to the response header
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(SCHEME));

                // return the response
                return response;

            } // end of catch
        } // end of method

        /// <summary>
        /// ProcessRequestMessage
        /// Processes the incoming http request authorization headers
        /// Extracts the username and password, then validates them against
        /// a credential store of existing username and password
        /// If they are valid, it builds and sets a ClaimsPrincipal of identity
        /// We provide the credentials at this step early on in the pipeline
        /// processing before any of the Web API methods are called
        /// so that inside the Web API methods we are able to extract from the
        /// thread the context and authentication principal information...
        /// We can check out which groups the user belongs to, what permissions they have...
        /// All this can be filtered out at the method level now with simple attributes
        /// such as using [Authorize] attribute
        /// </summary>
        /// <param name="request">the incoming http request</param>
        private void ProcessRequestMessage(HttpRequestMessage request)
        {
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
                string userID = parts[0].Trim();

                // obtain the password
                string password = parts[1].Trim();

                try
                {
                    // Create a validator object
                    UserNamePasswordAuthenticator validator = new UserNamePasswordAuthenticator();

                    // Validate the Client username and password
                    if (!validator.Validate(userID, password))
                    {
                        // not registered and not authenticated
                        return;
                    }

                    // Client is Valid Registered User
                    // Create a new claim based on the username and password
                    List<Claim> claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, userID),
                        new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethods.Password)
                    };

                    // Create a Claims principal based on the username and password
                    ClaimsPrincipal principal = new ClaimsPrincipal(new[] { new ClaimsIdentity(claims, SCHEME) });

                    // Set the current thread principal to this newly created one
                    Thread.CurrentPrincipal = principal;

                    // Set the HttpContext to the principal object
                    if (HttpContext.Current != null)
                        HttpContext.Current.User = principal;

                }
                catch (Exception)
                {
                    throw;
                }


            } // end of if
        } // end of method

        /// <summary>
        /// ProcessResponseMessage
        /// Processes the final outgoing http response object to the client
        /// Checks to see if the response status code is unauthoriuzed
        /// The controller may have the [Authorize] requirement on a method. 
        /// If the response is unauthorized, then the process pipeline 
        /// falls here eventually
        /// </summary>
        /// <param name="response">outgoing http response message object</param>
		private void ProcessResponseMessage(HttpResponseMessage response)
        {
            // If user is unauthorized, reply to client indicating what
            // authentication scheme is required to proceed
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response.Headers.WwwAuthenticate.Add(
                    new AuthenticationHeaderValue(SCHEME));
            }
        } // end of method

    } // end of class
} // end of namespace