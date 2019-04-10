Feature: AddCourse
	In order to book a course
	As a user
	I want to add course(s) into the cart

# This is a scenario based test case to verify course details after adding a course on booking page
# by entering course name, delivery location and start date.
Scenario: Add a course by specific course information
	Given I have navigated to home page
	And I click cart link and go to booking page
	When I click add course link on booking page
	And I select a course 'ISTQB Foundation Certificate' on booking page
	And I select a delivery location 'Sydney' on booking page
	And I select option 1 in start date on booking page
	And I click add course button on booking page
	Then the booked course title should be 'ISTQB Foundation Certificate' on booking page
	And the booked delivery location should be 'Sydney' on booking page
	And the booked start date should be first option on booking page

# This is a data driven test case to verify that all available courses can be added on booking page
# Alternative way is to purchase Specflow + excel license and then to read all course names from excel sheet
Scenario Outline: All available courses can be added into cart
	Given I have navigated to home page
	And I click cart link and go to booking page
	When I click add course link on booking page
	And I select a course <course name> from example on booking page
	And I select option 1 in delivery location on booking page
	And I select option 1 in start date on booking page
	And I click add course button on booking page
	Then the booked course title should be <course name> from example on booking page
	When I click remove course link on booking page
	Then no course should be added on booking page
Examples:
| course name                                         |
| Complete Tester (Course Bundle)                     |
| ISTQB Foundation Certificate                        |
| ISTQB Usability Tester Certificate                  |
| ISTQB Advanced Test Analyst Certificate             |
| ISTQB Advanced Test Manager Certificate             |
| ISTQB Advanced Technical Test Analyst Certificate   |
| ISTQB Advanced Test Automation Engineer Certificate |
| ISTQB Advanced Security Tester Certificate          |
| ASTQB Mobile Testing Certificate                    |
| TMMi Professional Certificate                       |
| iSQI Scrum Master Pro Certification                 |
| ISTQB Foundation Agile Tester Extension             |
| iSQI Certified Agile Essentials                     |
| iSQI Certified Agile Business Analysis              |
| Leading SAFe Certification                          |
| SAFe for Teams Certification                        |
| SAFe DevOps Certification                           |
| BCS Business Analysis Foundation Certificate        |
| BCS Requirements Engineering Certificate            |
| BCS Modelling Business Processes Certificate        |
| BCS Business Analysis Practice Certificate          |
| User Acceptance Testing (UAT)                       |
| Professional Testing Processes                      |
| Risk Based Testing                                  |
| Test Team Leadership                                |
| DASA DevOps Fundamentals Certification              |