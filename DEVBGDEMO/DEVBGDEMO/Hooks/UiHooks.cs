using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace DEVBGDEMO.Hooks
{
    [Binding]
    public class UiHooks
    {
        public static IWebDriver? Driver { get; private set; }
        public static string? CreatedEmail { get; set; }
        public static string? CreatedPassword { get; set; }
        public static string? Products { get; set; }
        public static string? ProductNumber { get; set; }
        public static string? ProductName { get; set; }
        public static string BASE_UI_URL = "https://demoqa.com";

        [BeforeScenario(Order = 100)]
        public void StartBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void QuitBrowser()
        { 
            Driver?.Quit(); 
        }
    }
}
