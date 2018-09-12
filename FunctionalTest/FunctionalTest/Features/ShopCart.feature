##
Feature: ShoppingCart
	In order to purchase items online
	As a shopper
	I want to add items to my online shopping basket


@mytag
Scenario: Login to site with incorrect details
	Given I log in with the following details:
	| userName               | 
	| lambert.egbe@gmail.com |
	Then I should be prompted with incorrect login message:
	| message                                            |
	| We cannot find an account with that e-mail address |

@mytag
Scenario: search products by using multiple search criteria
	Given I am on the ShoppingPage
	When  I search for shoes by the following criteria:
	| category | Type           | subGroup |
	| Clothing | Men's Clothing | Men      |
	Then I should be returned products with the searched criteria

@mytag	
Scenario: Update quantity of products in cart
	Given I am on the ShoppingPage
	And I have 3 products in the basket
	When I change the quantity of items in the basket to 1
	Then the number of items should be updated correctly to 1 

#Implemented like so as we have not created an account for this user.
#We do not have a test version of the app - 
#ideally we would want to clear DB and create user, 
#also user dummy payment details to check this functionality
Scenario: Checkout
	Given I am on the ShoppingPage
	And I have 3 products in the basket
	When I proceed to checkout 
	Then I should see be asked to provide my login information

#below is a boiler plate for this scenario. This is not implemented on purpose
#In the Utility class we have some helper functions to create some user details
#however, we do not have control of the test site and its services and this test could potentially be brittle
 @ignore
Scenario: Sign Up to site
	Given I sign up to site with valid details:
	| userName | password | OtherDetails |
	| test     | test     | tests        |
	When I return to the site and login with the created account:
	| userName | password |
	| test     | test     |
	Then I should successfully be logged into the site

