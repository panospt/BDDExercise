Feature: RegisterSpecs

A short summary of the feature

@smoke
Scenario: [Successful user's login]
	Given User is navigated to home page
	When User logs in by providing valid credentials username panos2 and password qwert1
	Then User is successfully logged in

@smoke
Scenario Outline: [Invalid login]
	Given User is navigated to home page
	When User provides login username <username>
	And User provides login password <password>
	And User submits login form
	Then User is not logged in

Examples:
	| username | password |
	| asdf     | 123      |
	|          | 123      |
	| panos2   | 123      |
	| panos2   |          |
	| asdf     | qwert1   |

@smoke
Scenario: [Successful user's registration]
	Given User is navigated to home page
	And User is navigated to registration page
	When User provides first name firstName
	And User provides last name lastName
	And User provides address address1
	And User provides city city1
	And User provides state state1
	And User provides zip code zipCode1
	And User provides phone phone1
	And User provides SSN ssn1
	And User provides random username
	And User provides random password
	And User provides repeated random password
	And User submits registration form
	Then User is registered successfully

@smoke
Scenario: [User is already registered]
	Given User is navigated to home page
	And User is navigated to registration page
	When User provides first name firstName
	And User provides last name lastName
	And User provides address address1
	And User provides city city1
	And User provides state state1
	And User provides zip code zipCode1
	And User provides phone phone1
	And User provides SSN ssn1
	And User provides username panos2
	And User provides password qwert1
	And User provides repeated password qwert1
	And User submits registration form
	Then User is already registered

@smoke
Scenario: [Missing registration info]
	Given User is navigated to home page
	And User is navigated to registration page
	When User submits registration form
	Then First name is required
	And Last name is required
	And Address is required
	And City is required
	And State is required
	And Zip Code is required
	And SSN is required
	And Username is required
	And Password is required
	And Repeated password is required


