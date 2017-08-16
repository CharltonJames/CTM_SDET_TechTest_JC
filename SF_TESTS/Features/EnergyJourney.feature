Feature: EnergyJourney
	In order to be able to correct mistakes on postocde entry
	As a user
	I want to be able to change the postcode after entering a valid postocde
	
	Note: these scenarios are simply a test of the framework abilities and not as asked for in the test. This is becuase i cannot impliment effect tests 
	Until the framework is completed and stable. Hopefully these demonstations at least show the ease at which the framework can take care of tasks for the
	person's writing the scenarios
@mytag
Scenario: Change postcode option
	Given I have navigated to the YourSupplier screen
	And I have entered PE2 6YS into the postcode field
	When I click the Find Postcode button
	Then I expect the ChangePostcode to be visible

Scenario: Show Pick Supplier
	Given I have navigated to the YourSupplier screen
	And I have entered PE2 6YS into the postcode field
	When I click the Find Postcode button
	Then I expect the Who supplies your energy to be visible

Scenario: Basic Move To second Screen
	Given I have navigated to the YourEnergy screen