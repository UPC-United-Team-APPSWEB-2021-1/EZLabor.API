Feature: EditProfile
	Simple test for editing a user profile

@mytag
Scenario: Update personal data
	Given I create an freelancer account 
	When I update the personal data
	Then The updated info should return