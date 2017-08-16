using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace SF_PAGES.Pages
{
    // controls access to pages to be used by the framework
    public class Navigator
    {
        RemoteWebDriver Driver;
        List<Page> pageList;
        WebDriverWait wait;

        public Navigator(Driver driver)
        {
            Assert.IsNotNull(driver);
            Driver = (RemoteWebDriver)driver.GetInstance();
            //driver.Manage().Window.Maximize();
            if (driver != null)//unlikely but defensive against a null object being given - not entirely sure if an assert above protects by test quit
            {
                TimeSpan timeout = new TimeSpan(0, 0, Defaults.timoutSecs);
                wait = new WebDriverWait(Driver, timeout);
            }
            pageList = new List<Page>();
            pageList.Add(new YourSupplier_P1(driver, wait, PageConfigurations.Page1));
            pageList.Add(new YourEnergy_P2(driver, wait, PageConfigurations.Page2));
            pageList.Add(new YourDetails_P3(driver, wait, PageConfigurations.Page3));
            pageList.Add(new YourResults_P4(driver, wait, PageConfigurations.Page4));
        }

        //returns a list of Pages which can be navigated around.
        public List<Page> getPages()
        {
            return pageList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="found"></param>
        /// <returns></returns>
        public Page getCurrentlyActivePage(ref bool found)
        {

            string URL = Driver.Url; // get the current URL (full)
            Uri currentURI = new Uri(URL); // create a Uri instance of it
            string currentpageName = currentURI.Segments.Last();
            currentpageName = currentpageName.Replace(@"/", "");
            found = false;
            Page currentlyActivePage = null;
            for (int index = 0; (index < pageList.Count() && found == false); index++)
            {
                currentlyActivePage = pageList[index];
                if (currentlyActivePage.PageInfo.pageName == currentpageName ||
                    URL == Defaults.baseURL || URL == Defaults.homePage)
                {
                    found = true;
                }
            }

            return currentlyActivePage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public Page getAPageByName(string pageName)
        {
            Page returnedPage = null;
            foreach (Page page in pageList)
            {
                if (page.PageInfo.nextPageName == pageName)
                {
                    return page;
                }
            }
            return returnedPage;
        }

        /// <summary>
        /// given a page num - returns the page - returns null when no page found
        /// </summary>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public Page getAPageByNumber(uint pageNum)
        {
            Page returnedPage = null;
            foreach (Page page in pageList)
            {
                if (page.PageInfo.pageNum == pageNum)
                {
                    return page;
                }
            }
            return returnedPage;
        }

        /// <summary>
        /// Takes care of the process of getting to a particular page for testing.
        /// Requires correct Page list configuration setup
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public bool navigateToPage(string page)// needs to consider current page and not restart at beginning
        {
            bool result = false;
            bool found = false;
            //make sure the list is sorted in order
            Page requiredPage = null;

            pageList.Sort((x, y) => x.PageInfo.pageNum.CompareTo(y.PageInfo.pageNum));

            for (int index = 0; (index < pageList.Count()); index++)
            {
                requiredPage = pageList[index];
                if (requiredPage.PageInfo.pageName == page)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                if (requiredPage.PageInfo.pageNum != 1)
                {
                    Page prevPage = null;
                    for (uint index = 1; index < requiredPage.PageInfo.pageNum; index++)
                    {
                        //navigate through the previous pages to get to the desired page
                        prevPage = getAPageByNumber(index);
                        if(prevPage == null)
                        {
                            throw new System.NullReferenceException("prevPage is null- navigateToPage()");
                        }
                        if(prevPage.NavigateTo())
                        {
                            if(prevPage.NavigateThrough())
                            {
                                result = true;
                            }
                        }
                    }
                }
                else
                {
                    //its the first page, just go to the base url
                    Assert.IsTrue(requiredPage.NavigateTo());
                }
            }
            else
            {
                //TODO - could not find the page
            }
            return result;
        }
    }
}
