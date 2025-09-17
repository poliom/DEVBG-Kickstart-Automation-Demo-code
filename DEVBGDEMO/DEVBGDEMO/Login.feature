Feature: Login with API precondition

  Background:
    Given a user exists via the API

  Scenario: Successful login shows the dashboard
    When the user logs in via the UI
    Then the dashboard is visible

  Scenario: Successful login with user name and passowrd shows the dashboard
    When logs in with "poliom" and "QWerty!@4" password via the UI
    Then the dashboard is visible
