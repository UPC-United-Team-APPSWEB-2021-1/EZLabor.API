Feature: VisualizeOffers
	List Offers by EmployerId

@mytag
Scenario: Show all the offers
	Given I want to see information of the offers 
	When I choose one employer 
	Then the system returns a list of offers