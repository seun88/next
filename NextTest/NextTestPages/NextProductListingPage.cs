using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium2017Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NextTest.NextTestPages
{
    public class NextProductListingPage : BaseClass
    {
        private IList<IWebElement> productlistpage;

        public void AndIAmOnlistingpage()
        {
            productlistpage = GetElementsByClassName("Title");
            Assert.True(productlistpage.Count > 0, "is not displayed");
        }

        public NextProductDetailPage AndIClicklink()
        {
            productlistpage = GetElementsByClassName("Title");
            var element = driver.FindElement(By.ClassName("Title"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scrollTo(618,556)");
            
            //Thread.Sleep(5000);

            productlistpage.ElementAt(5).Click();

            return new NextProductDetailPage();


        }

        



        

        
    }
}
