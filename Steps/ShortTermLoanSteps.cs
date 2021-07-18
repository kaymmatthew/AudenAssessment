using AudenAssessment.PageObject;
using BoDi;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

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

        [When(@"I slide to borrow '(.*)' with offset of (.*)")]
        public void WhenISlideToBorrow(string amount,int offset)
        {
            shortTermLoanPage.SetLoanAmount(amount, offset);
        }

        [When(@"I select payment date as (.*)")]
        public void WhenISelectPaymentDateAs(int day)
        {
            shortTermLoanPage.SelectLoanday(day);
        }

        [Then(@"First repayment date is friday '(.*)'")]
        public void ThenFirstRepaymentDateIsFridayOfJul(string firstRepaymentDate)
        {
            string paymentdateAlias = shortTermLoanPage.GetFirstRepaymentDate();
            Assert.AreEqual(firstRepaymentDate, paymentdateAlias,
                $"{firstRepaymentDate} not equal to {paymentdateAlias}");
        }

        [Then(@"The loan breakdown is as follows:")]
        public void ThenTheLoanBreakdownIsAsFollows(Table table)
        {
            string result = shortTermLoanPage.GetSummaryText(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(table.Rows[0]["Amount To Borrow"], shortTermLoanPage.GetSummaryText(1));
                Assert.AreEqual(table.Rows[0]["Interest"], shortTermLoanPage.GetSummaryText(2));
                Assert.AreEqual(table.Rows[0]["Repayment Total"], shortTermLoanPage.GetSummaryText(3));
                Assert.AreEqual(table.Rows[0]["Instalment Amount"], shortTermLoanPage.GetSummaryText(4));
            });
        }

        [Then(@"Slider amount is equal to loan amount")]
        public void ThenSliderAmountIsEqualAmountToBorrow()
        {
            string sliderValue = shortTermLoanPage.GetloanAmountText();
            string loanValue = shortTermLoanPage.GetSummaryText(1);
            Assert.AreEqual(sliderValue, loanValue.Replace(".00", string.Empty));
        }

        [Then(@"Slider minimum is '(.*)'")]
        public void ThenSliderMinimumIs(string expectedMinimumValue)
        {
            var actualMinValue =
                shortTermLoanPage.GetSliderMinValue();
                Assert.AreEqual(expectedMinimumValue, actualMinValue);
        }

        [Then(@"Slider maximum is '(.*)'")]
        public void ThenSliderMaximumIs(string expectedMaximumValue)
        {
            var actualMaxValue = 
                shortTermLoanPage.GetSliderMaxValue();
                Assert.AreEqual(expectedMaximumValue, actualMaxValue);
        }

        [Given(@"I accept cookies")]
        public void GivenIAcceptCookies()
        {
            shortTermLoanPage.AcceptCookies();
        }

    }
}
