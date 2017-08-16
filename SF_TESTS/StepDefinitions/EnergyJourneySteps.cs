using TechTalk.SpecFlow;
using SF_PAGES.Pages;
using SF_PAGES;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SF_TESTS.StepDefinitions
{
    [Binding]
    public class EnergyJourneySteps
    {
        static Driver driver = null;
        static Navigator navControl = null;
        static Page currentPage = null;

        /// <summary>
        /// Becuase IEDriverServer fails to quit thus the .exe file is locked, this forces a kill of that process before running
        /// a test
        /// </summary>
        [BeforeTestRun]
        static void initMachine()
        {
            if(Defaults.TestBrowser == "IE")
            {
                foreach(var process in Process.GetProcessesByName("IEDriverServer"))// kill instances incase there are more than 1
                {
                    process.Kill();
                }
            }
            driver = new Driver();
            navControl = new Navigator(driver);
        }

        [AfterTestRun]
        static void deinitMachine()
        {
            if (Defaults.TestBrowser == "IE")
            {
                foreach (var process in Process.GetProcessesByName("IEDriverServer"))// kill instances incase there are more than 1
                {
                    process.Kill();
                }
            }
        }

        [Given(@"I have navigated to the (.*) screen")]
        [Given(@"I have navigated to the (.*) page")]
        public void GivenIHaveNaviagtedToTheScreen(string pageChoice)
        {
            Assert.IsTrue(navControl.navigateToPage(pageChoice));
        }


        [Given(@"I have entered (.*) into the (.*) field")]
        [Given(@"I enter (.*) into the (.*) field")]
        [Given(@"I enter (.*) into (.*)")]
        [Given(@"I have entered (.*) into (.*)")]
        public void GivenIHaveEnteredIntoTheField(string value, string field)
        {
            bool success = false;
            currentPage = navControl.getCurrentlyActivePage(ref success);
            Assert.IsTrue(success);
            currentPage.EnterValueIntoTextBox(value, field);
        }

        [When(@"I click the (.*) button")]
        public void WhenIClickThe_Button(string button)
        {
            Assert.IsTrue(currentPage.ClickItemOnPage(button));
            //ScenarioContext.Current.Pending();
        }

        [When(@"I have chosen the (.*) option")]
        [When(@"I have clicked the (.*) option")]
        public void WhenIHavechosenTheOption(string button)
        {
            Assert.IsTrue(currentPage.ClickItemOnPage(button));
            //ScenarioContext.Current.Pending();
        }

        [Then(@"I expect the (.*) section to be visible")]
        [Then(@"I expect the (.*) to be visible")]
        [Then(@"I expect the (.*) option to be visible")]
        [Then(@"I expect (.*) to be visible")]
        [Then(@"I expect (.*) option to be visible")]
        public void TheIExpectToBeVisible(string item)
        {
            bool success = false;
            currentPage = navControl.getCurrentlyActivePage(ref success);
            Assert.IsTrue(success);
            Assert.IsTrue(currentPage.IsItemVisible(item));
        }

        [Then(@"I expect the (.*) be hidden")]
        [Then(@"I expect the (.*) option be hidden")]
        [Then(@"I expect (.*) to be hidden")]
        [Then(@"I expect (.*) option be hidden")]
        public void TheIExpectToBeHidden(string item)
        {
            bool success = false;
            currentPage = navControl.getCurrentlyActivePage(ref success);
            Assert.IsTrue(success);
            Assert.IsFalse(currentPage.IsItemVisible(item));
        }

    }
}
