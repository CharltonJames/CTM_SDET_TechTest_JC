﻿
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SF_PAGES.Pages
{
    public class YourDetails_P3 : Page
    {
        public YourDetails_P3(Driver driver, WebDriverWait waiter, PageInfo pageinformation)
            : base(driver, waiter, pageinformation)
        {

        }

        public override bool NavigateThrough()
        {
            bool result = false;

            if (Driver != null)
            {


            }


            return result;
        }

        public override bool NavigateTo()
        {
            bool result = false;

            if (Driver != null)
            {


            }


            return result;
        }

        public override bool ClickNext()
        {
            return ClickItemOnPage("NEXT");
        }
    }
}
