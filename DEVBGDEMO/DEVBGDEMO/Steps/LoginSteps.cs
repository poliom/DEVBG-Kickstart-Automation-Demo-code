using Reqnroll;
using FluentAssertions;
using DEVBGDEMO.Hooks;
using DEVBGDEMO.Pages;

namespace DEVBGDEMO.Steps
{
    [Binding]
    public class LoginSteps
    {
        [When("the user logs in via the UI")]
        public void WhenUserLogsInViaUi()
        {
            var page = new LoginPage(UiHooks.Driver!);
            page.Open(UiHooks.BASE_UI_URL);
            page.Login(UiHooks.CreatedEmail!, UiHooks.CreatedPassword!);
        }

        [When(@"logs in with ""([^""]+)"" and ""([^""]+)"" password via the UI")]
        public void WhenUserLogsInViaUi(string username, string password)
        {
            var page = new LoginPage(UiHooks.Driver!);
            page.Open(UiHooks.BASE_UI_URL);
            page.Login(username, password);
        }

        [Then("the dashboard is visible")]
        public void ThenDashboardVisible()
        {
            var page = new LoginPage(UiHooks.Driver!);
            page.IsDashboardVisible().Should().BeTrue("dashboard should be visible after successful login");
        }
    }
}
