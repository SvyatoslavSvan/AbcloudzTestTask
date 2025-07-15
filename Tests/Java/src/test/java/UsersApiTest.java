import io.restassured.RestAssured;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;

class UsersApiTest {

    @BeforeAll
    static void configure() {
        RestAssured.baseURI = "https://localhost:7255";
        RestAssured.useRelaxedHTTPSValidation();
    }

    @Test
    void createUser_validPayload_returnsCreatedUser() {
        String payload = """
            {
              "fullName": "Alice Smith",
              "email": "alice.smith@example.com",
              "dateOfBirth": "1995-06-15"
            }
            """;

        given()
            .contentType("application/json")
            .body(payload)
        .when()
            .post("/api/User")
        .then()
            .statusCode(201)                                        
            .contentType(containsString("application/json"))
            .body("id", notNullValue())                             
            .body("fullName", equalTo("Alice Smith"))
            .body("email", equalTo("alice.smith@example.com"))
            .body("dateOfBirth", equalTo("1995-06-15"));
    }

    @Test
    void createUser_invalidEmail_returnsBadRequest() {
        String payload = """
            {
              "fullName": "Alice Smith",
              "email": "notAnEmail",
              "dateOfBirth": "1995-06-15"
            }
            """;

        given()
            .contentType("application/json")
            .body(payload)
        .when()
            .post("/api/User")
        .then()
            .statusCode(400)                                        
            .contentType(containsString("application/json"))
            .body("message.toLowerCase()", containsString("invalid email"));
    }
}
