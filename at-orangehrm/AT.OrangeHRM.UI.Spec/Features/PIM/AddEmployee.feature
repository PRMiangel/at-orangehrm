@PIM
Feature: Add Employee
	As a Orange HRM user
	I want to be able to add a new employee
	So I can have all employees registered.

@CRUD @BVT
Scenario: Add a new Employee with First, Middle and Last Name fields
	Given I navigate to PIM > Add Employee
	When I Fill the following values
		| Field       | Value      |
		| First Name  | Purple     |
		| Middle Name | Hrm        |
		| Last Name   | Automation |
		And I click on Save button
		And I navigate to PIM > Employee List
		And I fill 'Purple Hrm Automation' in Employee Name field
		And I click on Search button
	Then I should see 'Purple Hrm' in the table
		And I should see 'Automation' in the table
