package pages;

import org.openqa.selenium.*;
import org.openqa.selenium.support.ui.WebDriverWait;
import java.time.Duration;

public class LoginPage {
    private final WebDriver driver;
    private By email = By.id("userName");
    private By password = By.id("password");
    private By submit = By.id("login");
    private By dashboard = By.id("books-wrapper");

    public LoginPage(WebDriver driver){
        this.driver = driver;
    }

    public void open(String baseUrl){
        driver.navigate().to(baseUrl + "/login");
    }
    public void login(String e, String p){
        driver.findElement(email).clear(); driver.findElement(email).sendKeys(e);
        driver.findElement(password).clear(); driver.findElement(password).sendKeys(p);
        driver.findElement(submit).click();
    }
    public boolean isDashboardVisible(){
        new WebDriverWait(driver, Duration.ofSeconds(10))
                .until(d -> d.findElement(dashboard).isDisplayed());
        return true;
    }
}
