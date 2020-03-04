using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.Serialization;
using System.IO;
using System.Net.Http.Headers;


namespace Client
{
    public partial class Main : Form
    {
        #region fields

        // Http Client for Web Requests
        private HttpClient client;

        // Path to Web API Service
        private const string path = "http://localhost:56925/api/values/";

        // Path to Web API Registration User Service
        private const string registrationPath = "http://localhost:56925/api/registration/";

        // The default user credentials 
        private string username = "";
        private string password = "";

        #endregion fields

        #region constructor

        /// <summary>
        /// Main
        /// Main entry point for form
        /// </summary>
        public Main()
        {
            InitializeComponent();

        } // end of main

        #endregion constructor

        #region events

        /// <summary>
        /// btnGetAll_Click
        /// Processes the button click event when a user
        /// clicks on Get * Get All Entities
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Setup Http Client
                client = new HttpClient() { BaseAddress = new Uri(path) };

                // The Demo Web API Controller GET * Does not require authorization
                // Parse Credentials (may not be required for Web API)
                ParseCredentials("", "");

                // Call the Service
                List<string> entities = GetAll(client);

                // Update the UI
                lstEntities.Items.Clear();

                foreach (string entity in entities)
                {
                    lstEntities.Items.Add(entity);    
                }
            }
            catch (Exception ex)
            {
                // Create Message Box to Inform the User
                string message = $"Error in Web API Request: {ex.Message}";
                string title = "Web API Tester Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
        } // end of method

        /// <summary>
        /// btnGetId_Click
        /// Processes the button click event when a user
        /// clicks on Get Request (by Id)
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnGetId_Click(object sender, EventArgs e)
        {
            try
            {
                // Setup Http Client
                client = new HttpClient() { BaseAddress = new Uri(path) };

                // The Demo Web API Controller GET (1) does not require authorization
                // Parse Credentials (may not be required for Web API)
                ParseCredentials("", "");

                // Try to Parse the Id Text Box
                int id = 0;

                if (int.TryParse(txtId.Text, out id))
                {
                    // Call the Service
                    string entity = Get(client, id);

                    // Update the UI
                    lstEntities.Items.Clear();
                    lstEntities.Items.Add(entity);
                }

                else
                {
                    MessageBox.Show("Please Enter a Valid Integer for the ID");
                }

            }
            catch (Exception ex)
            {
                // Create Message Box to Inform the User
                string message = $"Error in Web API Request: {ex.Message}";
                string title = "Web API Tester Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
        } // end of method

        /// <summary>
        /// btnPost_Click
        /// Processes the user request to POST or Add
        /// an entity to the Web API Service
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                // Setup Http Client
                client = new HttpClient() { BaseAddress = new Uri(path) };

                // Parse Credentials (may not be required for Web API)
                ParseCredentials(txtUsername.Text, txtPassword.Text);

                // Parse the Entity Value
                string value = txtValue.Text;

                // Validate the Value Field is Not Empty
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show($"Please enter a value in the entity textbox");
                    return;
                }

                // Call the Service Method
                AddItem(client, value);

                // Refresh the UI
                btnGetAll_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Create Message Box to Inform the User
                string message = $"Error in Web API Request: {ex.Message}";
                string title = "Web API Tester Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }

        } // end of method

        /// <summary>
        /// btnPut_Click
        /// Processes the user request to PUT or Replace
        /// an entity to the Web API Service
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnPut_Click(object sender, EventArgs e)
        {

            try
            {
                // Setup Http Client
                client = new HttpClient() { BaseAddress = new Uri(path) };

                // Parse Credentials (may not be required for Web API)
                ParseCredentials(txtUsername.Text, txtPassword.Text);

                // Try to Parse the Id Text Box
                int id = 0;

                // Parse the Entity Value
                string value = txtValue.Text;

                // Validate the Entity Identifier Id Field
                if (!int.TryParse(txtId.Text, out id))
                {
                    MessageBox.Show("Please Enter a Valid Integer for the ID");
                    return;
                }

                // Validate the Value Field is Not Empty
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show($"Please enter a value in the entity textbox");
                    return;
                }

                // Call the Service Method
                ReplaceItem(client, value, id);

                // Refresh the UI
                btnGetAll_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Create Message Box to Inform the User
                string message = $"Error in Web API Request: {ex.Message}";
                string title = "Web API Tester Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
        } // end of method

        /// <summary>
        /// btnDelete_Click
        /// Processes the user request to Delete
        /// an entity from the Web API Service
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Setup Http Client
                client = new HttpClient() { BaseAddress = new Uri(path) };

                // Parse Credentials (may not be required for Web API)
                ParseCredentials(txtUsername.Text, txtPassword.Text);

                // Try to Parse the Id Text Box
                int id = 0;

                // Validate the Entity Identifier Id Field
                if (!int.TryParse(txtId.Text, out id))
                {
                    MessageBox.Show("Please Enter a Valid Integer for the ID");
                    return;
                }

                // Call the Service Method
                DeleteItem(client, id);

                // Refresh the UI
                btnGetAll_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Create Message Box to Inform the User
                string message = $"Error in Web API Request: {ex.Message}";
                string title = "Web API Tester Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
        } // end of method

        /// <summary>
        /// btnClear_Click
        /// Processes the broom/clear button click
        /// event to clear the user text boxes
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtValue.Clear();
        } // end of method 

        /// <summary>
        /// btnClearCredentials_Click
        /// Processes the broom/clear button click
        /// event to clear the user credentials text boxes
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnClearCredentials_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

        } // end of method

        /// <summary>
        /// lstEntities_SelectedValueChanged
        /// If there is more than one entry in the Form ListBox
        /// then it determines the index location to make the
        /// Web API testing interface easier. 
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e"> not used</param>
        private void lstEntities_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstEntities.Items.Count > 1)
            {
                txtId.Text = lstEntities.SelectedIndex.ToString();
            }
        } // end of method

        /// <summary>
        /// Register
        /// Button click event handler
        /// Register the user credentials on the Web API
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e"> not used</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {

            try
            {
                // Setup Http Client
                client = new HttpClient() { BaseAddress = new Uri(registrationPath) };

                // Parse Credentials (may not be required for Web API)
                ParseCredentials(txtUsername.Text, txtPassword.Text);

                // Call the Service Method
                Register(client);

            }
            catch (Exception ex)
            {
                // Create Message Box to Inform the User
                string message = $"Error in Web API Request: {ex.Message}";
                string title = "Web API Tester Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }

        } // end of the method

        #endregion events

        #region methods

        /// <summary>
        /// ParseCredentials
        /// Parses the username and password
        /// Validation is not required per design
        /// </summary>
        private void ParseCredentials(string UserName, string Password)
        {
            username = UserName;
            password = Password;

            // Add Authorization Header to http client object
            string creds = String.Format("{0}:{1}", username, password);
            byte[] bytes = Encoding.ASCII.GetBytes(creds);
            AuthenticationHeaderValue header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));
            client.DefaultRequestHeaders.Authorization = header;

        } // end of method

        /// <summary>
        /// GetAll
        /// Calls the Web API to retrieve all the entities available
        /// The result is a List of type string containing entities
        /// Unsuccessful requests are thrown as an exception
        /// to the caller.
        /// </summary>
        /// <param name="client">the HttpClient proxy</param>
        /// <returns>a List<string> of entities</returns>
        private static List<string> GetAll(HttpClient client)
        {
            // List of Entities
            List<string> entities = new List<string>();

            // Setup the Request 
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, string.Empty))
            {
                // Build the Request Headers
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("Accept-Charset", "utf-8");

                // Setup the Response and Make the Service Call
                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    // Verify the Response is Good
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the results and stream to a List<string>
                        // Takes XML and Streams to Memory 
                        Stream stream = response.Content.ReadAsStreamAsync().Result;
                        if (response.Content.Headers.ContentType.MediaType.Contains("/xml"))
                        {
                            DataContractSerializer ser = new DataContractSerializer(typeof(List<string>));
                            entities = (List<string>)ser.ReadObject(stream);
                        }
                    }
                    else
                    {
                        string message = $"Response from Service: {response?.StatusCode} : {response.ReasonPhrase}";
                        throw new Exception(message);
                    }
                } // end of using
            } // end of using

            return entities;

        } // end of GetAll Method

        /// <summary>
        /// Get
        /// Calls the Web API Service to retrieve the entity by id
        /// The result is single entity (string)
        /// Unsuccessful requests are thrown as an exception
        /// to the caller.
        /// </summary>
        /// <param name="client">the HttpClient proxy</param>
        /// <param name="id">the entity identifier (int) </param>
        /// <returns>the entity (string) by the identifier </returns>
        private static string Get(HttpClient client, int id)
        {
            // Entity (Default Empty)
            string entity = string.Empty;

            // Setup the Request with the URI Format Added
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{id}"))
            {
                // Build the Request Headers
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("Accept-Charset", "utf-8");

                // Setup the Response and Make the Service Call
                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    // Verify the Response is Good
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the results and stream to a string object
                        // Takes XML and Streams to Memory 
                        Stream stream = response.Content.ReadAsStreamAsync().Result;
                        if (response.Content.Headers.ContentType.MediaType.Contains("/xml"))
                        {
                            DataContractSerializer ser = new DataContractSerializer(typeof(string));
                            entity = (string)ser.ReadObject(stream);
                        }
                    }
                    else
                    {
                        string message = $"Response from Service: {response?.StatusCode} : {response.ReasonPhrase}";
                        throw new Exception(message);
                    }
                } // end of using
            } // end of using

            return entity;

        } // end of Get Method

        /// <summary>
        /// AddItem
        /// Calls the Web API to POST (Add) an entity
        /// Alerts the user if successful
        /// Unsuccessful requests are thrown as an exception
        /// to the caller.
        /// </summary>
        /// <param name="client">the HttpClient proxy</param>
        /// <param name="item">the entity (string) to be added</param>
        private static void AddItem(HttpClient client, string item)
        {
            // Create an HttpRequest with Post 
            // Second parameter is string.empty because we are not modifying the URI
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, string.Empty))
            {
                // Build headers for Request
                // Not necessary as we do not get results but kept for reference
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("Accept-Charset", "utf-8");

                // Build content for the the HttpRequest Body
                DataContractSerializer ser = new DataContractSerializer(typeof(string));

                // Serialize the entity
                using (MemoryStream ms = new MemoryStream())
                {
                    // Writes the entity item (string) to a Memory Stream
                    ser.WriteObject(ms, item);

                    // Extracts the MemoryStream object as an array of bytes
                    // Then converts to a UTF8 Encoded string
                    string content = UTF8Encoding.UTF8.GetString(ms.ToArray());

                    // Creates and assigns the string content to the Request
                    request.Content = new StringContent(content, Encoding.UTF8, "application/xml");
                }

                // Call the Web API and Analyze Response
                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success in Post");
                    }
                    else
                    {
                        string message = $"Response from Service: {response?.StatusCode} : {response.ReasonPhrase}";
                        throw new Exception(message);
                    }
                } // end of using
            } // end of using

        } // end of AddItem Method

        /// <summary>
        /// ReplaceItem
        /// Calls the Web API to PUT (Replace) an entity
        /// Alerts the user if successful
        /// Unsuccessful requests are thrown as an exception
        /// to the caller.
        /// </summary>
        /// <param name="client">the HttpClient proxy</param>
        /// <param name="item">the entity (string) to be replaced</param>
        /// <param name="id">the entity identifier (int) </param>
        private static void ReplaceItem(HttpClient client, string item, int id)
        {
            // Create an HttpRequest with Put 
            // Second parameter is string.empty because we are not modifying the URI
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"{id}"))
            {
                // Build headers for Request
                // Not necessary as we do not get results but kept for reference
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("Accept-Charset", "utf-8");

                // Build content for the the HttpRequest Body
                DataContractSerializer ser = new DataContractSerializer(typeof(string));

                // Serialize the entity
                using (MemoryStream ms = new MemoryStream())
                {
                    // Writes the entity item (string) to a Memory Stream
                    ser.WriteObject(ms, item);

                    // Extracts the MemoryStream object as an array of bytes
                    // Then converts to a UTF8 Encoded string
                    string content = UTF8Encoding.UTF8.GetString(ms.ToArray());

                    // Creates and assigns the string content to the Request
                    request.Content = new StringContent(content, Encoding.UTF8, "application/xml");
                }

                // Call the Web API and Analyze Response
                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success in Put");
                    }
                    else
                    {
                        string message = $"Response from Service: {response?.StatusCode} : {response.ReasonPhrase}";
                        throw new Exception(message);
                    }
                } // end of using
            } // end of using

        } // end of ReplaceItem Method

        /// <summary>
        /// DeleteItem
        /// Calls the Web API to delete the entity by id
        /// Alerts the user if successful
        /// Unsuccessful requests are thrown as an exception
        /// to the caller.
        /// </summary>
        /// <param name="client">the HttpClient proxy</param>
        /// <param name="id">the entity identifier (int) </param>
        private static void DeleteItem(HttpClient client, int id)
        {
            // Setup the Request with the URI Format Added
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{id}"))
            {
                // Build the Request Headers
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("Accept-Charset", "utf-8");

                // Setup the Response and Make the Service Call
                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    // Verify the Response is Good
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success in Delete");
                    }
                    else
                    {
                        string message = $"Response from Service: {response?.StatusCode} : {response.ReasonPhrase}";
                        throw new Exception(message);
                    }
                } // end of using
            } // end of using

        } // end of Delete Method

        /// <summary>
        /// Register
        /// Calls the Web API to register the user with credentials
        /// Alerts the user if successful
        /// Unsuccessful requests are thrown as an exception
        /// to the caller.
        /// </summary>
        /// <param name="client">the HttpClient proxy</param>
        private static void Register(HttpClient client)
        {
            // Setup the Request with the URI Format Added
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, string.Empty))
            {

                // Build the Request Headers
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("Accept-Charset", "utf-8");
                // Empty Content
                request.Content = new StringContent("", Encoding.UTF8, "application/xml");

                // Setup the Response and Make the Service Call
                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    // Verify the Response is Good
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success in Registration");
                    }
                    else
                    {
                        string message = $"Response from Service: {response?.StatusCode} : {response.ReasonPhrase}";
                        throw new Exception(message);
                    }
                } // end of using
            } // end of using

        } // end of Register Method

        #endregion methods

        } // end of class
} // end of namespace
