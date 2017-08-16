using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SF_PAGES.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Page
    {
        public RemoteWebDriver Driver;
        public WebDriverWait Wait;
        public PageInfo PageInfo;
        //the following methods MUST be implimented by the implimentor
        public abstract bool NavigateThrough();
        public abstract bool NavigateTo();
        public abstract bool ClickNext();
        //public abstract bool enterValueIntoField(string value, string field);
        //public abstract bool chooseAnOption(string);

        public Page(Driver driver, WebDriverWait waiter, PageInfo pageInformation)
        {
            if(driver == null)
            {
                throw new System.ArgumentException("Parameter canot be Null", "driver");
            }
            Driver = (RemoteWebDriver)driver.GetInstance();
            Wait = waiter;
            PageInfo = pageInformation;
        }



        /// <summary>
        ///generic function for filling out a text field, this is a generic function intended for use on any text field (may need expanding)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="textboxName"></param>
        /// <returns></returns>
        public bool EnterValueIntoTextBox(string value, string textboxName)
        {
            textboxName = textboxName.Replace(" ", ""); // strip whitespace
            bool result = false;
            PageOption pageOption = null;
            for (int index = 0; index < PageInfo.PageOptions.Count(); index++)
            {
                if ((PageInfo.PageOptions[index].optionType == Defaults.OptionType.TEXTBOX)
                    && PageInfo.PageOptions[index].optionName.ToUpper() == textboxName.ToUpper()
                    )
                {
                    pageOption = PageInfo.PageOptions[index];
                    break;
                }
            }
            if (pageOption != null)

            {
                try
                {
                    IWebElement elementTextBox = Driver.FindElementById(pageOption.Locator); // should wait for it instead...use the waiter
                    elementTextBox.Clear();
                    elementTextBox.SendKeys(value);
                    result = true;
                }
                catch (Exception ex)
                {
                    //handle later
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceName"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        public bool ChooseAnOption(string choiceName, string choice)
        {
            bool result = false;
            choiceName = choiceName.Replace(" ", ""); // strip whitespace
            choice = choice.Replace(" ", ""); // strip whitespace
            PageOption pageOption = null;
            bool foundChoice = false;
            string chosenChoice = "";
            for (int index = 0; index < PageInfo.PageOptions.Count() && foundChoice == false; index++)
            {
                switch (PageInfo.PageOptions[index].optionType)
                {
                    case Defaults.OptionType.CHOICE:
                    case Defaults.OptionType.CHOICEBUTTONS:
                        if(PageInfo.PageOptions[index].optionName.ToUpper() == choiceName.ToUpper())
                        {
                            pageOption = PageInfo.PageOptions[index];
                            for (int choiceIndex = 0; index < pageOption.options.Count() && foundChoice == false; choiceIndex++)
                            {
                                if (pageOption.options[choiceIndex] == choice)
                                {
                                    chosenChoice = pageOption.options[choiceIndex];
                                    foundChoice = true;
                                }
                            }
                        }
                        break;
                }
                //if (
                //    (PageInfo.PageOptions[index].optionType == Defaults.OptionType.CHOICE )
                //    && PageInfo.PageOptions[index].optionName.ToUpper() == choiceName.ToUpper()
                //    )
                //{
                //    pageOption = PageInfo.PageOptions[index];
                //    for (int choiceIndex = 0; index < pageOption.options.Count() && foundChoice == false; choiceIndex++)
                //    {
                //        if (pageOption.options[choiceIndex] == choice)
                //        {
                //            chosenChoice = pageOption.options[choiceIndex];
                //            foundChoice = true;
                //        }
                //    }
                //}
            }
            if (foundChoice)
            {
                IWebElement elementChoice = null;
                switch (pageOption.LocatorType)
                {
                    case Defaults.LocatorType.CSS:
                        elementChoice = Driver.FindElementByCssSelector(chosenChoice); // should wait for it instead...use the waiter
                        break;
                    case Defaults.LocatorType.ID:
                        elementChoice = Driver.FindElementById(chosenChoice); // should wait for it instead...use the waiter
                        break;
                    case Defaults.LocatorType.XPATH:
                        elementChoice = Driver.FindElementByXPath(chosenChoice); // should wait for it instead...use the waiter
                        break;
                    default:
                        throw new System.NotSupportedException("Unsuported Defaults.LocatorType value");
                }
                if (elementChoice != null)
                {
                    elementChoice.Click();
                    result = true;
                } 

            }
            return result;
        }

        /// <summary>
        /// Returns Element from Page - Exception thrown if not found (Might be better not to throw an exception and handle differently . ASSERT?)
        /// PageOption contains the neccassaery information to locate that element 
        /// </summary>
        /// <param name="pageOption"></param>
        /// <returns></returns>
        public IWebElement GetElement( PageOption pageOption)
        {
            IWebElement element = null;
            switch (pageOption.LocatorType)
            {
                case Defaults.LocatorType.CSS:
                    // do soemthing particular for items needed to be located through the CSS
                        element = Driver.FindElementByCssSelector(pageOption.Locator);
                    break;
                case Defaults.LocatorType.ID:
                    // do something particular for items needed to be located through their ID
                        element = Driver.FindElementById(pageOption.Locator);
                    break;
                case Defaults.LocatorType.XPATH:
                    // do something particular for items needed to be located through their ID
                        element = Driver.FindElementByXPath(pageOption.Locator);
                    break;
                default:
                    throw new System.NotSupportedException("Unsuported Defaults.LocatorType value");
            }
            if(element == null)
            {
                throw new System.NullReferenceException("Can't find Element - GetElement()");
            }
            return element;
        }

        /// <summary>
        /// Looks up a page option based on given parameter name and performs a click action on that element
        /// </summary>
        /// <param name="ButtonName"></param>
        /// <returns>success/fail</returns>
        public bool ClickItemOnPage(string ButtonName)
        {
            ButtonName = ButtonName.Replace(" ", ""); // strip whitespace
            bool result = false;
            PageOption pageOption = GetPageOptionByName(ButtonName);
            if(pageOption != null)
            {
                IWebElement element = GetElement(pageOption);
                switch (pageOption.optionType)
                {
                    case Defaults.OptionType.BUTTON:
                    case Defaults.OptionType.RADIOBUTTONS:
                        if (element != null)
                        {
                            if (element.Enabled && element.Displayed)
                            {
                                element.Click();
                                result = true;
                            }
                        }
                        break;
                }
            }
            return result;
        }


        /// <summary>
        /// Wait for the default timeout for the given element to become visible, returns true if element is found and becomes visible
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsItemVisible(string item)
        {
            bool isVisible = false;
            PageOption pageOption = GetPageOptionByName(item);
            if(pageOption != null)
            {
                isVisible = false;
                try
                {
                    switch (pageOption.LocatorType)
                    {
                        case Defaults.LocatorType.ID:
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(pageOption.Locator)));
                            break;
                        case Defaults.LocatorType.XPATH:
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(pageOption.Locator)));
                            break;
                        case Defaults.LocatorType.CSS:
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(pageOption.Locator)));
                            break;
                        default:
                            throw new System.NotSupportedException("Unsuported Defaults.LocatorType value");
                    }
                    isVisible = true;// if no exception then element is visible
                }
                catch// this should catch the timeout exception only
                {
                    isVisible = true;
                    //todo
                }
                
            }
            return isVisible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool WaitOnItem(string item)
        {
            bool isVisible = false;
            PageOption pageOption = GetPageOptionByName(item);
            if (pageOption != null)
            {
                isVisible = false;
                IWebElement element = GetElement(pageOption);
                if (element != null)
                {
                    isVisible = element.Displayed;
                }
                else
                {
                    throw new System.NullReferenceException("element is null - Cant find Element - IsItemVisible()");
                }
            }
            else
            {
                throw new System.NullReferenceException("No Page Option Found- WaitOnItem()");
            }
            return isVisible;
        }

        /// <summary>
        /// returns a page option if one is found in the page information. null returned if not found.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="result"></param>
        /// <returns>Pageoption if successful</returns>
        private PageOption GetPageOptionByName(string name)
        {
            PageOption ret = null;
            foreach (PageOption option in PageInfo.PageOptions  )
            {
                if(option.optionName.ToUpper() == name.ToUpper())//seems case senstive - need to check
                {
                    ret = option;
                    break;
                }
            }
            return ret;
        }
    }
}
