package steps;

import hooks.UiHooks;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import pages.LoginPage;
import static org.junit.jupiter.api.Assertions.assertTrue;

public class LoginSteps {
    @When("the user logs in via the UI")
    public void theUserLogsInViaTheUI() {
        var page = new LoginPage(UiHooks.driver);
        page.open(UiHooks.BASE_UI_URL);
        page.login(UiHooks.createdEmail, UiHooks.createdPassword);
    }

    @When("logs in with {string} and {string} password via the UI")
    public void logsInWithAndPasswordViaTheUI(String username, String password) {
        var page = new LoginPage(UiHooks.driver);
        page.open(UiHooks.BASE_UI_URL);
        page.login(username, password);
    }

    @Then("the dashboard is visible")
    public void theDashboardIsVisible() {
        var page = new LoginPage(UiHooks.driver);
        assertTrue(page.isDashboardVisible());
    }
}
