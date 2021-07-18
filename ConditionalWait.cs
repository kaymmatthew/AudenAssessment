using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AudenAssessment
{
    public static class ConditionalWait
    {
        public static void WaitFor(this IWebDriver driver, int timeOut)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeOut));
        }
    }
}
