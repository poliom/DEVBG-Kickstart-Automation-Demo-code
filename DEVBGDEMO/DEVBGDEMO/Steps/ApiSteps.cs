using Reqnroll;
using RestSharp;
using FluentAssertions;
using DEVBGDEMO.Hooks;
using System.Net;
using NUnit.Framework;

namespace DEVBGDEMO.Steps
{
    [Binding]
    public class ApiSteps
    {
        private static string BASE_API_URL = "https://demoqa.com";

        [Given("a user exists via the API")]
        public static void GivenUserExistsViaApi()
        {
            var email = "poliom";
            var password = "QWerty!@34";

            var client = new RestClient(BASE_API_URL);
            var request = new RestRequest("/Account/v1/Login", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{""userName"":""" + email + @""",""password"":""" + password + @"""}";
            request.AddStringBody(body, DataFormat.Json);
            var response = client.Execute(request);
            var content = response.Content;

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            UiHooks.CreatedEmail = email;
            UiHooks.CreatedPassword = password;
        }
    }
}
