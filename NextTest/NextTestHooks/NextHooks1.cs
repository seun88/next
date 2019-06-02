using Selenium2017Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NextTest.NextTestHooks
{
    [Binding]
    public sealed class NextHooks1
    {
        

        [BeforeScenario]
        public void BeforeScenario()
        {
            BaseClass.LaunchBrowser("Chrome");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BaseClass.CloseBrowser();
        }
    }
}
