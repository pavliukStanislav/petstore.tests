Feature: Create a pet

  Scenario: Create a pet with valid data
    Given valid data for a new pet
    When I create the pet
    Then the API returns HTTP 200 with the submitted pet data
