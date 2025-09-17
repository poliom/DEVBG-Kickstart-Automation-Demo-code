using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVBGDEMO.Pages
{
    internal class DemoPage
    {
        private readonly IWebDriver _driver;
        private IWebElement ProductTitle => _driver.FindElement(By.XPath("//*[@class=\"product-information\"]/h2"));

        public DemoPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}");
        }

        public bool IsProductVisible(string productTitle)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            bool isVisible = wait.Until(_ => ProductTitle.Displayed); // check title is present

            if (isVisible) // if title present, check the matching string title
            {
                return ProductTitle.Text.Equals(productTitle, StringComparison.Ordinal);
            }
            else
            {
                return false;
            }
        }
    }
}
