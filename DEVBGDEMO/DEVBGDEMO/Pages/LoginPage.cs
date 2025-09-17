using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace DEVBGDEMO.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private IWebElement EmailInput => _driver.FindElement(By.Id("userName"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement SubmitBtn => _driver.FindElement(By.Id("login"));
        private IWebElement DashboardMarker => _driver.FindElement(By.Id("books-wrapper"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/login");
        }

        public void Login(string email, string password)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
            SubmitBtn.Click();
        }

        public bool IsDashboardVisible()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(_ => DashboardMarker.Displayed);
        }
    }
}
