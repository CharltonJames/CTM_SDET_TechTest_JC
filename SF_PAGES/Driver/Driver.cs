using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SF_PAGES
{
    /// <summary>
    /// Class for Configuring and managing the Selenium Driver. This class will enable easy switching between browser drivers
    /// </summary>
    public class Driver
    {
        private  IWebDriver instance;

        public Driver()
        {
            switch (Defaults.TestBrowser)
            {
                case "IE":
                    SetInstance(new InternetExplorerDriver());
                    break;
                case "C":
                    SetInstance(new ChromeDriver());
                    break;
                case "FF":
                    SetInstance(new FirefoxDriver());
                    break;
            }
        }
        public  IWebDriver GetInstance()
        {
            return instance;
        }

        public  void SetInstance(IWebDriver value)
        {
            instance = value;
        }

        public string BaseAddress
        {
            get { return Defaults.baseURL; }
        }

        public  void Initialize()
        {
            GetInstance().Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(5) ;
        }
    }
}
