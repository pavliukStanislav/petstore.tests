Feature: Get a pet

  Scenario: An unknown pet cannot be retrieved
    When I retrieve an unknown pet
    Then the API returns HTTP 404

  Scenario Outline: Retrieving a pet with an invalid ID is rejected
    When I retrieve a pet using the invalid ID "<id>"
    Then the API returns HTTP 404

    Examples:
      | id                   |
      | not-a-number         |
      | 1.5                  |
      | 9223372036854775808  |
