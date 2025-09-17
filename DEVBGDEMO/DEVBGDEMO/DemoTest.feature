Feature: DemoTest

@tag1
Scenario: Open produt from shop
	Given get all products
		And select poduct number 11
	When go to slected product
	Then product page is open
