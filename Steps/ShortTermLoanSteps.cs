using AudenAssessment.PageObject;
using BoDi;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using System.Linq;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;

namespace AudenAssessment.Steps
{
    [Binding]
    public sealed class ShortTermLoanSteps
    {
        private readonly ShortTermLoanPage shortTermLoanPage;
        private readonly ScenarioContext _scenarioContext;

        public ShortTermLoanSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            shortTermLoanPage = 
                objectContainer.Resolve<ShortTermLoanPage>();
        }

        [Given(@"I am on auden short term loan page")]
        public void GivenIAmOnAudenShortTermLoanPage()
        {
            shortTermLoanPage.navigateToSite();
        }

        [When(@"I enter '(.*)' as the amount I would like to borrow")]
        public void WhenIEnterAsTheAmountIWouldLikeToBorrow(string amount)
        {
            shortTermLoanPage.EntLoanAmount(amount);
        }

        [When(@"I select payment date as (.*)")]
        public void WhenISelectPaymentDateAs(int day)
        {
            shortTermLoanPage.SelectLoanday(day);
        }

        [When(@"First repayment date is friday '(.*)'")]
        public void WhenFirstRepaymentDateIsFriday(string repaymentDate)
        {
            Assert.AreEqual(repaymentDate, shortTermLoanPage.GetFirstRepaymentDate());
        }

        [When(@"I select '(.*)' as the number of months it will take me to repay my loan")]
        public void WhenISelectAsTheNumberOfMonthsMyLoanWillBePayedIn(int month)
        {
            shortTermLoanPage.SelectLoanRepaymentMonths(month);
        }

        [Then(@"The loan breakdown is as follow:")]
        public void ThenTheLoanBreakdownIsAsFollow(Table table)
        {
            string result = shortTermLoanPage.GetSummaryText().FirstOrDefault().Text;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(table.Rows[0]["Amount To Borrow"], shortTermLoanPage.GetSummaryText().ElementAt(0).Text);
                Assert.AreEqual(table.Rows[0]["Interest"], shortTermLoanPage.GetSummaryText().ElementAt(1).Text);
                Assert.AreEqual(table.Rows[0]["Repayment Total"], shortTermLoanPage.GetSummaryText().ElementAt(2).Text);
                Assert.AreEqual(table.Rows[0]["Instalment Amount"], shortTermLoanPage.GetSummaryText().ElementAt(3).Text);
            });
        }

        [Given(@"I accept cookies")]
        public void GivenIAcceptCookies()
        {
            shortTermLoanPage.AcceptCookies();
        }
    }
}
