package hooks;

import io.cucumber.java.After;
import io.cucumber.java.Before;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;

public class UiHooks {
    public static WebDriver driver;
    public static String createdEmail;
    public static String createdPassword;
    public static String BASE_UI_URL = "https://demoqa.com";

    @Before(order = 100)
    public void startBrowser(){
        ChromeOptions opts = new ChromeOptions();
        driver = new ChromeDriver(opts);
        driver.manage().window().maximize();
    }

    @After
    public void quitBrowser(){
        if(driver != null){
            driver.quit();
        }
    }
}
