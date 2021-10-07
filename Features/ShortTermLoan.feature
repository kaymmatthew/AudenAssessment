Feature: ShortTermLoan

@Regression
Scenario: Test Slider Functionality 
   Given I am on auden short term loan page
   And I accept cookies
   When I enter '£500' as the amount I would like to borrow
	 And I select payment date as 31
	 And I select '9' as the number of months it will take me to repay my loan 
	 And First repayment date is friday 'Friday 29 Oct 2021'
	Then The loan breakdown is as follow:
	 | Amount To Borrow | Interest | Repayment Total | Instalment Amount |
	 | £500.00          | £249.87  | £749.87         | £83.33            |
	

	