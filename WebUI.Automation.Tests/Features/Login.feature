@Chrome 
Feature: Login
As a Gmail user
I want to be able to log in to Gmail
So that I can access my emails

	Scenario: Valid Gmail login
		Given I am on the Gmail login screen
		When I submit my valid credentials
		Then I see my Gmail Inbox


	Scenario: Invalid Gmail login
		Given I am on the Gmail login screen
		When I submit invalid credentials
		Then I remain on the Gmail login screen
		And I am shown a message indicating that my credentials are incorrect
		

	Scenario: Sign out from Gmail
		Given I have logged in to my Gmail
		When I sign out
		Then I am navigated to the Gmail login screen