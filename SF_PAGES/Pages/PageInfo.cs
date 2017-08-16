using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_PAGES.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public class PageInfo
    {
        public string pageName { get; set; }
        public string nextPageName { get; set; }
        public bool isFirstPage { get; set; }
        public bool isLastPage { get; set; }
        public uint pageNum { get; set; }
        public List<PageOption> PageOptions; // this is TODO see explanation below
        public PageInfo(string _pageName, string _nextPageName, bool _isFirstPage, bool _isLastPage, uint _pageNum)
        {
            pageName = _pageName;
            nextPageName = _nextPageName;
            isFirstPage = _isFirstPage;
            isLastPage = _isLastPage;
            pageNum = _pageNum;
        }

        // the list of ID's is to be used to store the entire list of all ID's on this page, this enables each page to be content neutral
        //
        public PageInfo(string _pageName, string _nextPageName, bool _isFirstPage, bool _isLastPage, uint _pageNum, List<PageOption> pageOptions)
        {
            pageName = _pageName;
            nextPageName = _nextPageName;
            isFirstPage = _isFirstPage;
            isLastPage = _isLastPage;
            pageNum = _pageNum;
            PageOptions = pageOptions;
        }



    }

    /// <summary>
    /// 
    /// </summary>
    public class PageOption
    {
        public string optionName;
        public Defaults.OptionType optionType;
        public List<string> options;
        public string Locator;
        public Defaults.LocatorType LocatorType;

        public PageOption(string optName, Defaults.OptionType optType, List<string> optionList, string locator, Defaults.LocatorType locatortype)
        {
            optionName = optName;
            optionType = optType;
            options = optionList;
            Locator = locator;
            LocatorType = locatortype;
        }
    }
}
