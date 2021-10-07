using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace AudenAssessment.PageObject
{
    public class ShortTermLoanPage
    {
        IWebDriver browser;
        public ShortTermLoanPage(IWebDriver browser)
        {
            this.browser = browser;
        }

        private IWebElement enterLoanAmount => browser.FindElement(By.XPath("//input[@id='amount']"));
        private IWebElement loanDate(int day) =>
            browser.FindElement(By.XPath($"//button[@name='day'][.='{day}']"));
        private IWebElement FirstRepaymentDate => browser.FindElement(By.XPath
            ("//span[contains(@class, 'first-repayment-date')]"));
        private IWebElement loanRepaymentMonths(int value) => 
            browser.FindElement(By.XPath($"//input[@name='repaymentLength']//following-sibling::label[.='{value}']"));
        private IWebElement cookiesbtn => browser.FindElement(By.XPath("//button[@id='consent_prompt_submit']"));
        private IList<IWebElement> SummaryOfLoan => 
            browser.FindElements(By.XPath("//strong[@data-testid='loan-calculator-summary-amount']"));
        private IWebElement loanAmountValue =>
            browser.FindElement(By.XPath("//p[@data-testid='loan-amount-value']"));

        public void navigateToSite()
        {
            browser.Navigate().GoToUrl(SettingsReader.audenUrl);
        }

        public void EntLoanAmount(string amount)
        {
            enterLoanAmount.SendKeys(amount);
        }

        public string GetSliderMinValue()
        {
            browser.WaitFor(1);
            return enterLoanAmount.GetAttribute("min");
        }

        public string GetSliderMaxValue()
        {
            browser.WaitFor(1);
            return enterLoanAmount.GetAttribute("max");
        }

        public void SelectLoanday(int day) => loanDate(day).Click();

        public string GetFirstRepaymentDate()
        {
            browser.WaitFor(1);
            return FirstRepaymentDate.Text;
        }

        public void SelectLoanRepaymentMonths(int value) => loanRepaymentMonths(value).Click();

        public void AcceptCookies()
        {
            browser.WaitFor(2);
            try
            {
                if (cookiesbtn.Displayed)
                {
                    cookiesbtn.Click();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public IList<IWebElement> GetSummaryText() => SummaryOfLoan.ToList();
        public string GetloanAmountText() => loanAmountValue.Text;
    }
}
