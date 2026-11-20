Feature: Delete a pet

  Scenario: Deleting a created pet makes it unavailable
    Given a new pet is prepared and created
    When I delete the pet
    Then the pet is no longer available

  Scenario: Deleting a pet does not remove a different pet
    Given two new pets are created
    When I delete the first pet
    Then the second pet can still be retrieved

  Scenario: An unknown pet cannot be deleted
    When I delete an unknown pet
    Then the API returns HTTP 404

  Scenario Outline: Deleting a pet with an invalid ID is rejected
    When I delete a pet using the invalid ID "<id>"
    Then the API returns HTTP 404

    Examples:
      | id                   |
      | not-a-number         |
      | 1.5                  |
      | 9223372036854775808 |
