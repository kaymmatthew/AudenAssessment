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

        private IWebElement Slider => browser.FindElement(By.Name("amount"));
        private IWebElement loanDate(int day) =>
            browser.FindElement(By.XPath($"//button[@name='day'][.='{day}']"));
        private IWebElement FirstRepaymentDate => browser.FindElement(By.XPath("(//label)[2]"));
        private IWebElement cookiesbtn => browser.FindElement(By.XPath("//button[@id='consent_prompt_submit']"));
        private IWebElement SummaryOfLoan(int index) => 
            browser.FindElement(By.XPath($"(//ul/li)[{index}]//strong[@data-testid='loan-calculator-summary-amount']"));
        private IWebElement loanAmountValue =>
            browser.FindElement(By.XPath("//p[@data-testid='loan-amount-value']"));

        public void navigateToSite()
        {
            browser.Navigate().GoToUrl(SettingsReader.audenUrl);
        }

        public void SetLoanAmount(string amount,int offset)
        {
            browser.WaitFor(1);
            try
            {
                if (loanAmountValue.Text != amount)
                {
                    Actions SliderAction = new Actions(browser);
                    SliderAction.DragAndDropToOffset(Slider, offset, 0).Perform();
                    browser.WaitFor(1);
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        public string GetSliderMinValue()
        {
            browser.WaitFor(1);
            return Slider.GetAttribute("min"); 
        }

        public string GetSliderMaxValue()
        {
            browser.WaitFor(2);
            return Slider.GetAttribute("max"); 
        }

        public void SelectLoanday(int day) =>  loanDate(day).Click();
        public string GetFirstRepaymentDate()
        {
            browser.WaitFor(1);
            return FirstRepaymentDate.Text;
        }
            

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

        public string GetSummaryText(int index) => SummaryOfLoan(index).Text;
        public string GetloanAmountText() => loanAmountValue.Text;
    }
}
