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
    public class NextHomePage : BaseClass
    {
        private IWebElement logo;
        private IWebElement validproduct;
        private IWebElement searchproduct;

        public void AndIAmOnNextHomePage()
        {
            logo = GetElementById("header-logo");
            Assert.True(logo.Displayed, "is not displayed");
        }

        public void AndIInputproduct()
        {
            validproduct = GetElementById("sli_search_1");
            validproduct.Clear();


            validproduct.SendKeys("Knitwear");
        }

        public NextProductListingPage AndIclickOnsearchbutton()
        {
            searchproduct = GetElementByClassName("SearchButton");
            searchproduct.Click();

            return new NextProductListingPage();

        }
    }
}
