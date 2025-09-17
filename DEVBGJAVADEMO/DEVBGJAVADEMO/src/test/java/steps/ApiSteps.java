package steps;

import hooks.UiHooks;
import io.cucumber.java.en.Given;
import io.restassured.http.ContentType;
import io.restassured.response.Response;
import static io.restassured.RestAssured.given;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class ApiSteps {
    private static final String BASE_API_URL = "https://demoqa.com";

    @Given("a user exists via the API")
    public void aUserExistsViaTheApi() {
        String email = "poliom";
        String password = "QWerty!@34";

        String json = "{\"userName\":\"" + email + "\",\"password\":\"" + password + "\"}";

        Response response =
                given()
                        .baseUri(BASE_API_URL)
                        .contentType(ContentType.JSON)
                        .body(json)
                        .when()
                        .post("/Account/v1/Login");

        String content = response.asString();
        assertEquals(200, response.statusCode(), content);

        UiHooks.createdEmail = email;
        UiHooks.createdPassword = password;
    }
}
