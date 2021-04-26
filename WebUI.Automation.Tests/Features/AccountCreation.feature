@Chrome 
Feature: Account Creation
	As a consumer
	I want to sign up for a zen account
	so that I can use Zen products


	Scenario: Create an account successfully
		Given I am on the 'Account Creation' page 
		And I have filled out all my details "Sara" "akbarpour.sara@gmail.com" "vazkon4321"
		And I have accepted the Terms of Service
		When I submit
		Then I am redirected to the 'Email Sent Confirmation' page
		And an account activation email is sent to my email address "akbarpour.sara@gmail.com"

	#	| name | Email    | password                                          |
#		| Sara    | akbarpour.sara@gmail.com    | vazkon4321                                          |
	
#	Scenario: Unable to create a duplicate account
#		Given I have already created my account
#		And I have filled out all my details using the same email address
#		When I submit
#		Then I see a validation error 'Email address is already in use. Try another.'
#		And a duplicate account is not created
#
#
#	Scenario Outline: Unable to create an account with invalid details
#		Given I am creating account with an invalid '<Field>'
#		When I attempt to submit
#		Then the submit button is disabled
#		And I see a validation error '<Error Message>'
#		
#		Examples:
#		| Example Description | Field    | Error Message                                          |
#		| Email is invalid    | Email    | Invalid email                                          |
#		| Password is invalid | Password | Use at least 6 characters. Include letters and numbers |
#
#
#	Scenario Outline: Unable to create an account with incomplete details
#		Given I am creating account with a missing '<Field>'
#		When I attempt to submit
#		Then the submit button is disabled
#		
#		Examples:
#		| Example Description            | Field            |
#		| Name is not filled             | Name             |
#		| Email is not filled            | Email            |
#		| Password is not filled         | Password         |
#		| Confirm Password is not filled | Confirm Password |
#		| ToS not accepted               | Terms of Service |	
#
#
#	Scenario: View Terms of Service during account creation
#		Given I am creating account
#		When I choose to view the Terms of Service
#		Then I am presented with the Terms of Service
#		And my account details are still in place	
#
#
#	Scenario: Unable to create an account with mismatch passwords
#		Given I am creating account with mismatch passwords
#		When I attempt to submit
#		Then the submit button is disabled