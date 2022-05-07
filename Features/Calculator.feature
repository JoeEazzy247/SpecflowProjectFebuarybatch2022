Feature: Calculator

Simple calculator for adding **two** numbers

@smokeTest
Scenario: Add the following numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are 'added'
	Then the result should be 120


Scenario Outline: Add the following numbers in example table
	Given the first number is <firstnumber>
	And the second number is <secondnumber>
	When the two numbers are '<calc>'
	Then the result should be <result>

Examples: 
| firstnumber | secondnumber | result | calc       |
| 50          | 70           | 120    | added      |
| 50          | 70           | 20     | subtracted |