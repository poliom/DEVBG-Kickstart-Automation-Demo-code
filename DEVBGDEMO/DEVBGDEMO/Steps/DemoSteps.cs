using DEVBGDEMO.Hooks;
using DEVBGDEMO.Pages;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DEVBGDEMO.Steps
{
    [Binding]
    internal class DemoSteps
    {

        [Given("select poduct number {int}")]
        public void GivenSelectPoductNumber(int productNumber)
        {
            string content = UiHooks.Products;

            var root = JToken.Parse(content);

            var jpath = $"$.products[?(@.id == {productNumber})].name";

            var nameToken = root.SelectTokens(jpath).FirstOrDefault();
            UiHooks.ProductName = nameToken.ToString();
            UiHooks.ProductNumber = productNumber.ToString();
        }

        [Given("get all products")]
        public void GivenGetAllProducts()
        {
            var client = new RestClient("https://automationexercise.com");
            var request = new RestRequest("/api/productsList", Method.Get);
            var response = client.Execute(request);
            var content = response.Content;

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            UiHooks.Products = content;
        }

        [When("go to slected product")]
        public void WhenGoToSlectedProduct()
        {
            var page = new DemoPage(UiHooks.Driver!);
            string productNumber = UiHooks.ProductNumber;
            page.Open("https://automationexercise.com/product_details/" + productNumber);
        }

        [Then("product page is open")]
        public void ThenProductPageIsOpen()
        {
            var page = new DemoPage(UiHooks.Driver!);
            string productName = UiHooks.ProductName;
            page.IsProductVisible(productName);
        }

    }
}
