using NextTest.NextTestPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium2017Test.Helper
{
    public class BaseClass
    {
        public static IWebDriver driver { get; set; }
        private static SelectElement select;


        static BaseClass()
        {
            driver = null;
            select = null;
        }


        public static void SelectByIndex(IWebElement element, int index)
        {
            select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public static void SelectByValue(IWebElement element, String value)
        {
            select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public static void SelectByText(IWebElement element, String text)
        {
            select = new SelectElement(element);
            select.SelectByText(text);
        }


        public static void LaunchBrowser(String browser)
        {
            switch (browser)
            {
                case "Chrome":
                    driver = initialiseChrome();
                    break;
                case "Firefox":
                    driver = initialiseFirefox();
                    break;
                default:
                    Console.WriteLine(browser + " is not recognised. So Firfox is launched instead");
                    driver = initialiseFirefox();
                    break;
            }

            driver.Manage().Window.Maximize();
        }

        private static IWebDriver initialiseChrome()
        {
            driver = new ChromeDriver();

            return driver;
        }

        private static IWebDriver initialiseFirefox()
        {
            driver = new FirefoxDriver();

            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Close();
            driver.Quit();
        }

        public static void LaunchUrl(String Url)
        {
            driver.Navigate().GoToUrl(Url);
        }

        public static Screenshot TakeScreenShot()
        {
            return ((ITakesScreenshot)driver).GetScreenshot();
        }

        public static void SaveScreenshot()
        {
            try
            {
                var dateNow = DateTime.Now.Date.ToString().Replace(@"/", "").Replace(@" ", "").Replace(@":", "");
                dateNow = dateNow.Substring(0, 8);

                var timeNow = DateTime.Now.TimeOfDay.ToString().Replace(@"/", "").Replace(@" ", "").Replace(@":", "").Replace(@".", "");
                timeNow = timeNow.Substring(0, 6);

                var fileName = String.Format("C:\\Screeshots\\{0}_{1}.png", dateNow, timeNow);

                var screenShot = TakeScreenShot();

              // screenShot.SaveAsFile(fileName, System.Drawing.Imaging.ImageFormat.Png);
                screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Screenshot cannot be written because of {0} ", e));
            }


        }

        private static IWebElement GetElement(By locator)
        {

            IWebElement element = null;
            int tryCount = 0;

            while (element == null)
            {
                try
                {

                    element = driver.FindElement(locator);

                }
                catch (Exception e)
                {
                    if (tryCount == 3)
                    {
                        SaveScreenshot();
                        throw e;
                    }

                    var second = new TimeSpan(0, 0, 2);
                    Thread.Sleep(second);

                    tryCount++;
                }
            }

            Console.WriteLine(element.ToString() + " is now retrieved");
            return element;

        }


        public static IWebElement GetElementById(String id)
        {
            By locator = By.Id(id);
            return GetElement(locator);
        }

        public static IWebElement GetElementByClassName(String className)
        {
            By locator = By.ClassName(className);
            return GetElement(locator);
        }

        public static IWebElement GetElementByName(String name)
        {
            By locator = By.Name(name);
            return GetElement(locator);
        }

        public static IWebElement GetElementByCssSelector(String cssSelector)
        {
            By locator = By.CssSelector(cssSelector);
            return GetElement(locator);
        }

        public static IWebElement GetElementByXpath(String xpath)
        {
            By locator = By.XPath(xpath);
            return GetElement(locator);
        }


        private static IList<IWebElement> GetElements(By locator)
        {

            IList<IWebElement> element = null;
            int tryCount = 0;

            while (element == null)
            {
                try
                {

                    element = driver.FindElements(locator);

                }
                catch (Exception e)
                {
                    if (tryCount == 3)
                    {
                        SaveScreenshot();
                        throw e;
                    }

                    var second = new TimeSpan(0, 0, 2);
                    Thread.Sleep(second);

                    tryCount++;
                }
            }

            Console.WriteLine(element.ToString() + " is now retrieved");
            return element;

        }

        public static IList<IWebElement> GetElementsById(String id)
        {
            By locator = By.Id(id);
            return GetElements(locator);
        }

        public static IList<IWebElement> GetElementsByClassName(String className)
        {
            By locator = By.ClassName(className);
            return GetElements(locator);
        }

        public static IList<IWebElement> GetElementsByName(String name)
        {
            By locator = By.Name(name);
            return GetElements(locator);
        }

        public static IList<IWebElement> GetElementsByCssSelector(String cssSelector)
        {
            By locator = By.CssSelector(cssSelector);
            return GetElements(locator);
        }

        public static IList<IWebElement> GetElementsByXpath(String xpath)
        {
            By locator = By.XPath(xpath);
            return GetElements(locator);
        }

        public static NextHomePage GivenINavigatetoNextHomePage()
        {
            LaunchUrl("https://www.next.co.uk/");

            return new NextHomePage();
           
        }

    }
}
