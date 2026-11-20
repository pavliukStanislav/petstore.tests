Feature: Create a pet

  Scenario Outline: Create and retrieve a pet with different field values
    Given pet data with "<id>", "<category>", "<name>", "<photoUrls>", "<tags>" and "<status>"
    When I create the pet
    Then the create response contains the submitted pet data
    And the pet can be retrieved with the submitted data

    Examples:
      | id     | category | name     | photoUrls | tags       | status    |
      | absent | partial  | ordinary | empty     | two        | sold      |
      | valid  | full     | long     | empty     | without-id | available |
      | valid  | full     | ordinary | not-url   | two        | pending   |
      | absent | absent   | unicode  | not-url   | without-id | absent    |
      | absent | empty    | empty    | one       | two        | available |
      | valid  | full     | empty    | empty     | absent     | absent    |
      | absent | empty    | ordinary | one       | without-id | pending   |
      | valid  | absent   | empty    | not-url   | one        | available |
      | valid  | full     | unicode  | one       | empty      | sold      |
      | valid  | absent   | long     | one       | two        | absent    |
      | absent | partial  | long     | not-url   | empty      | available |
      | valid  | empty    | ordinary | two       | empty      | absent    |
      | absent | full     | long     | two       | one        | pending   |
      | absent | empty    | long     | not-url   | absent     | sold      |
      | absent | absent   | empty    | empty     | empty      | pending   |
      | valid  | partial  | unicode  | one       | absent     | pending   |
      | absent | absent   | ordinary | two       | absent     | available |
      | absent | absent   | unicode  | two       | two        | sold      |
      | valid  | partial  | empty    | two       | without-id | sold      |
      | absent | empty    | unicode  | empty     | one        | sold      |
      | absent | partial  | ordinary | one       | one        | absent    |
      | valid  | full     | unicode  | two       | empty      | available |

  Scenario: Create a pet with only required fields
    Given a pet named "test-pet-required-fields" with photo URL "https://example.com/pets/required-fields.jpg"
    When I create the pet
    Then the create response contains the submitted pet data
    And the pet can be retrieved with the submitted data

# Found a bug, we shoul NOT have an ability to create a pet with no name, but the API allows it
Scenario: Create a pet without name
	Given a pet with no name with photo URL "https://example.com/pets/empty-tag.jpg"
	When I create the pet
	Then the pet can NOT be retrieved with the submitted data
    Then the API returns HTTP 400

# Found a bug, we shoul NOT have an ability to create a pet with no photo URLs, but the API allows it
Scenario: Create a pet without photos
	Given a pet named "test-pet-required-fields" without photo URL
	When I create the pet
	Then the pet can NOT be retrieved with the submitted data
    Then the API returns HTTP 400

  Scenario: Create a pet with a category containing only an ID
    Given a pet named "test-pet-category-id" with photo URL "https://example.com/pets/category-id.jpg"
    And its category ID is "101"
    When I create the pet
    Then the create response contains the submitted pet data
    And the pet can be retrieved with the submitted data

  Scenario: Create a pet with a tag containing only an ID
    Given a pet named "test-pet-tag-id" with photo URL "https://example.com/pets/tag-id.jpg"
    And it has a tag with ID "201"
    When I create the pet
    Then the create response contains the submitted pet data
    And the pet can be retrieved with the submitted data

  Scenario: Create a pet with an empty tag
    Given a pet named "test-pet-empty-tag" with photo URL "https://example.com/pets/empty-tag.jpg"
    And it has an empty tag
    When I create the pet
    Then the create response contains the submitted pet data
    And the pet can be retrieved with the submitted data

  Scenario: Create a pet with repeated photo URLs
    Given a pet named "test-pet-repeated-photos" with photo URL "https://example.com/pets/repeated.jpg"
    And another photo URL "https://example.com/pets/repeated.jpg"
    When I create the pet
    Then the create response contains the submitted pet data
    And the pet can be retrieved with the submitted data

  Scenario: Create a pet with Unicode in category and tag names
    Given a pet named "test-pet-unicode" with photo URL "https://example.com/pets/unicode.jpg"
    And its category is named "коте 🐾"
    And it has a tag named "моє 🐾"
    When I create the pet
    Then the create response contains the submitted pet data
    And the pet can be retrieved with the submitted data

  Scenario: Create a pet with negative ID
    Given a pet named "test-pet-id-1" with photo URL "https://example.com/pets/boundary-id.jpg"
    And its ID is "-1"
    And its status is "available"
    When I create the pet
    Then the create response contains the submitted pet data with random ID
    And the pet can NOT be retrieved by ID "-1"

  Scenario: Create a pet with the largest ID
    Given a pet named "test-pet-id-max" with photo URL "https://example.com/pets/id-max.jpg"
    And its ID is "9223372036854775807"
    And its status is "available"
    When I create the pet
    Then the create response contains the submitted pet data
    And the pet can be retrieved with the submitted data

# Found a bug, responce code is 500
Scenario: Create a pet with the out of range ID
    Given a pet named "test-pet-id-max" with photo URL "https://example.com/pets/id-max.jpg"
    And its ID is "9223372036854775810"
    And its status is "available"
    When I create the pet
    Then the API returns HTTP 400
    