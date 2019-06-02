using NextTest.NextTestPages;
using Selenium2017Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NextTest.NextTestSteps
{
    [Binding]
    public sealed class NextStepDefinition1
    {
        private NextHomePage homepage;
        private NextProductListingPage listingpage;
        private NextProductDetailPage productspage;
        private NextEmailPage emailpage;

        [Given(@"I navigate to next site")]
        public void GivenINavigateToNextSite()
        {
            homepage = BaseClass.GivenINavigatetoNextHomePage();
            homepage.AndIAmOnNextHomePage();
            homepage.AndIInputproduct();
            

        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            listingpage = homepage.AndIclickOnsearchbutton();
        }

        [Then(@"i am on product details page")]
        public void ThenIAmOnProductDetailsPage()
        {
            listingpage.AndIAmOnlistingpage();
            productspage = listingpage.AndIClicklink();
            productspage.AndISelectproduct();
            productspage.AndISelectcolour();
            productspage.AndISelectsize();
            productspage.AndIClickaddtobasket();
            emailpage = productspage.AndIclickOncheckout();
            emailpage.AndIclickhelp();
            emailpage.Guestcheckout();



        }

        




    }
}
