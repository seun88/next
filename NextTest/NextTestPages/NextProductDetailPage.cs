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
    public class NextProductDetailPage : BaseClass
    {
        private IWebElement product;
        private IWebElement colour;
        private IWebElement addtobasket;
        private IWebElement size;
        private IWebElement checkoutbtn;


        public void AndISelectproduct()
        {



            //product = GetElementById("dk_container_Fit-212315");
            //driver.FindElement(By.Id("dk_container_Fit-212315")).SendKeys("Petite");
            // Thread.Sleep(5000);

        }
        public void AndISelectcolour()
        {
            colour = GetElementById("dk_container_Colour-179228");
            driver.FindElement(By.Id("dk_container_Colour-179228")).SendKeys("Camel Stripe");



        }

        public void AndISelectsize()
        {
            size = GetElementById("dk_container_Size-928-434");
            driver.FindElement(By.Id("dk_container_Size-928-434")).SendKeys("20");

        }

        public void AndIClickaddtobasket()
        {

            addtobasket = GetElementByCssSelector(".nxbtn.primary.btn-addtobag.addToBagCTA.Enabled");
            addtobasket.Click();
            Thread.Sleep(1000);

        }

        public NextEmailPage AndIclickOncheckout()
        {
            
            checkoutbtn = GetElementByXpath("/html/body/header/div/section/div[4]/div[3]");
            //driver.FindElement(By.XPath("/html/body/header/div/section/div[4]/div[3]")).Click();
            checkoutbtn.Click();
            Thread.Sleep(5000);



            return new NextEmailPage();

             
        }
    }
}
