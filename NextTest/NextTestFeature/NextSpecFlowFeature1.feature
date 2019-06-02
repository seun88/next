Feature: NextSpecFlowFeature1
	In order to buy
	As a customer
	I want to be on the next site

@mytag
Scenario: Buy a dress
	Given I navigate to next site
	When I click the search button
	Then i am on product details page
