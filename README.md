# WebAPIBasicAuthenticationDemo

ASP.Net Web API Basic Authentication Demo Application + Client Tester CRUD (Get, Post, Put, Delete) Windows Form Application

--------------
Project Article Here: https://portfolio.katiegirl.net/2020/03/04/asp-net-web-api-basic-authentication-demo-application-client-tester-crud-get-post-put-delete-windows-form-application/


This project presents a Visual Studio solution including a simple demo ASP.Net Web API Basic Authentication Service Application and a “Tester” Client (Windows Form Application) that allows the user to test the Web API with CRUD operations (GET, POST, PUT, DELETE) that service design requires authentication (except the Get). In addition to demonstrating standard CRUD capabilities, the Web API service implements a .Net Memory Cache (MemoryCache) and custom username and password validator. Passwords are stored securely using Password-Based Key Derivation Function PBKD cryptology. The client “tester” windows form application is not intended as a UX/UI demo but used to test and verify that the backend authentication service allows the user to register with a username and password and verify the Web API CRUD functions based on basic authentication scheme. Lastly, the project is shown in the demo section with a video and screen captures. Note: Every Web API Authentication service should use secure transport. For brevity, this demo project does not implement or discuss the complicated detail nature of SSL/TLS.

--------------
The demo project consists of these simple component topics:


ASP.Net Web API Service (Hosted by IIS Express) Application Project “WebAPIService”

Client “Tester to Service” Windows Form Application Project “Client”


---------------
ASP.Net Web API Service Application


The ASP.Net Web Application template was used to create a simple Web API service and was hosted on my local development machine using IIS Express launched from Visual Studio. The API functions will be discussed after other topics. 


---------------
Topics


User Modeling

Memory Cache “MemoryCache” .Net Implementation

PBDK (Password-Based Key Derivation) Secure Password Cryptology

Custom Username and Password Validator

Authentication Handler

Registration Controller

Values Controller
