﻿Feature: ShortTermLoan



@Regression
Scenario: Test Slider Functionality 
   Given I am on auden short term loan page
   And I accept cookies
   When I slide to borrow '£350' with offset of 2
	 And I select payment date as 31
   Then First repayment date is friday 'Friday 30 Jul 2021'
	 And The loan breakdown is as follows:
	 | AmountTo Borrow | Interest | Repayment Total | Instalment Amount |
	 | £350.00         | £83.20   | £433.20         | £144.41           |
	 And Slider amount is equal to loan amount
	 And Slider minimum is '200'
	 And Slider maximum is '500' 

	