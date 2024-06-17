Feature: Products
    As a warehouse manager
    I want to be able to add products to the database
    So that I can keep track of the inventory

Scenario: An authencated warehouse manager
    Given the user is authenticated as warehouse manager
    When the user opens the product management page
    Then the user needs to be able to add a new product
   