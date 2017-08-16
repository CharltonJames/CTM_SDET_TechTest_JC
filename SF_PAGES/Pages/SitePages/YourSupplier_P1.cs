using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace SF_PAGES.Pages
{
    public class YourSupplier_P1 : Page
    {

        public YourSupplier_P1(Driver driver, WebDriverWait waiter, PageInfo pageinformation)
            : base(driver, waiter, pageinformation)
        {

        }

        /// <summary>
        /// used by navigation controller - each page impliments requirements to move through to the next page
        /// default values are automatically used ( need to add support for "Scenarios" if previous screen answers affect next screen)
        /// </summary>
        /// <returns></returns>
        public override bool NavigateThrough()
        {
            bool result = false;
            if (Driver != null)
            {
                try
                {
                    if (EnterValueIntoTextBox(Defaults.postCode, "postcode"))//default postcode
                    {
                        if (ClickItemOnPage("Find Postcode"))
                        {
                            if (IsItemVisible("NEXT"))
                            {
                                //This should not be needed - needs investigation 
                                Thread.Sleep(1000); // I dont know why the click button is not working when its visible & enabled - browser too slow?
                                if (ClickNext())
                                {
                                    result = true;
                                }
                                
                            }
                                
                        }
                    }
                }
                catch (Exception ex)
                {
                    //TODO:
                }
            }

            return result;
        }

        /// <summary>
        /// used by navigation controller to move to a page
        /// </summary>
        /// <returns>success</returns>
        public override bool NavigateTo()
        {
            bool result = false;

            if (Driver != null)
            {
                try
                {
                    Driver.Navigate().GoToUrl(Defaults.homePage);
                    result = true;
                }
                catch (Exception ex)
                {
                    //TODO
                }
                
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool ClickNext()// if this is always just going to be this call then it might be better off in the base class
        {
            return ClickItemOnPage("NEXT");
        }


    }
}
