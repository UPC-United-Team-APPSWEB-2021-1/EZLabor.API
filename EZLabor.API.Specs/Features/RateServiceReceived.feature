Feature: RateServiceReceived
	Simple calculator for adding two numbers

@mytag
Scenario: Employer qualifies service to freelancer or service
	Given it is on the freelancer rating pop-up screen
	When is chosen which rating and feedback to give the freelancer
	Then the system sends the rating and notifies the company that their rating was successfully processed