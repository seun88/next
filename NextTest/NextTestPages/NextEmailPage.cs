using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2017Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTest.NextTestPages
{
    public class NextEmailPage : BaseClass
    {
        private IWebElement guest;
        private IWebElement help;


        public void AndIclickhelp()
        {
            help = GetElementByXpath("//*[@id='pri']/ul/li[1]/a");
            Assert.True(help.Displayed, "not on email page");
        }

        public void Guestcheckout()
        {
            //guest = GetElementByXpath("//*[@id='EmailOrAccountNumber']");
            //driver.FindElement(By.XPath("//*[@id='EmailOrAccountNumber']")).SendKeys("seun");
        }
    }
}
