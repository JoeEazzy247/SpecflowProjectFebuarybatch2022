Feature: DemoQatest

A short summary of the feature
Background: 
	Given I am on demoqa.com

@RegressionTest
Scenario: Text box test
	When I click 'Elements'
	Then I am on Elements page
	When I click textbox menu
	Then I am on Text Box page
	When I enter firstname Joseph
	And I enter email abc@abc.com
	And I enter address details
	| currentAddress | parmanentAddress |
	| 19 name str    | 19 name str      |

@RegressionTest
Scenario Outline: Text box test2
	When I click '<Elem>'
	Then I am on <Elem> page
	When I click textbox menu
	Then I am on <Tbox> page
	When I enter firstname <fName>
	And I enter email <email>
	And I enter the following address details
	| currentAddress | parmanentAddress |
	| 17 name str    | 15 name str      |

Examples: 
| Elem     | Tbox     | fName  | email       | 
| Elements | Text Box | Joseph | abc@abc.com | 
| Elements | Text Box | Sam    | bac@bac.com | 
| Elements | Text Box | Peter  | peter@abc.com | 