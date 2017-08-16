
using System.Collections.Generic;
using SF_PAGES.Pages;

namespace SF_PAGES
{
    public static class PageConfigurations
    {
        // holds the configuration of each screen(page) to be tested
        // to add a new page, first add he definition of it here
        //It would be much better to describe this data via XML, and possibly automatically extract that data from the web page itself.

        public static PageInfo Page1 = new PageInfo("YourSupplier", "YourEnergy", true, false, 1, PageOptions.Page1Elements);
        public static PageInfo Page2 = new PageInfo("YourEnergy", "YourDetials", false, false, 2, PageOptions.Page2Elements);
        public static PageInfo Page3 = new PageInfo("YourDetials", "YourResults", false, false, 3);
        public static PageInfo Page4 = new PageInfo("YourResults", "", false, true, 4);
    }

    public static class PageOptions
    {
        public static List<PageOption> Page1Elements = new List<PageOption>()
        {
            new PageOption(
                "Postcode",
                Defaults.OptionType.TEXTBOX,
                new List<string>(),
                "your-postcode",
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "FindPostcode",
                Defaults.OptionType.BUTTON,
                new List<string>(),
                "find-postcode",
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "ChangePostcode",
                Defaults.OptionType.BUTTON,
                new List<string>(),
                "change-postcode",
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "HaveBill",
                Defaults.OptionType.CHOICE,
                new List<string>(){"have-bill-label", "no-bill-label"},
                null,// if its a choice then we automatically choose from the list, so this can be null
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "Compare",
                Defaults.OptionType.CHOICE,
                new List<string>(){"compare-both-label", "compare-gas-label", "compare-electricity-label"},
                null,// if its a choice then we automatically choose from the list, so this can be null
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "Supplier",
                Defaults.OptionType.BESPOKE, // This one is awkward
                new List<string>(){ "dual-top-six-british-gas", "dual-top-six-edf", "dual-top-six-eon","dual-top-six-npower", "dual-top-six-scottish-power","dual-top-six-sse"},
                @"//label[@for='(Supplier)']/span/span",
                Defaults.LocatorType.XPATH
                ),
            new PageOption(
                "NEXT",
                Defaults.OptionType.BUTTON, 
                new List<string>(),
                "goto-your-supplier-details",
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "Who supplies your energy",
                Defaults.OptionType.SECTION,
                new List<string>(),
                @"//fieldset[@id='dual-energy-suppliers-question']/div",
                Defaults.LocatorType.XPATH
                ),
        };

        public static List<PageOption> Page2Elements = new List<PageOption>()
        {
            new PageOption(
                "Postcode",
                Defaults.OptionType.TEXTBOX,
                new List<string>(),
                "your-postcode",
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "FindPostcode",
                Defaults.OptionType.BUTTON,
                new List<string>(),
                "find-postcode",
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "ChangePostcode",
                Defaults.OptionType.BUTTON,
                new List<string>(),
                "change-postcode",
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "HaveBill",
                Defaults.OptionType.CHOICE,
                new List<string>(){"have-bill-label", "no-bill-label"},
                null,// if its a choice then we automatically choose from the list, so this can be null
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "Compare",
                Defaults.OptionType.CHOICE,
                new List<string>(){"compare-both-label", "compare-gas-label", "compare-electricity-label"},
                null,// if its a choice then we automatically choose from the list, so this can be null
                Defaults.LocatorType.ID
                ),
            new PageOption(
                "Supplier",
                Defaults.OptionType.BESPOKE, // why is this one such a pain?     
                new List<string>(),
                null,
                Defaults.LocatorType.CSS
                ),
            new PageOption(
                "Next",
                Defaults.OptionType.BUTTON, // why is this one such a pain?     
                new List<string>(),
                "goto-your-supplier-details",
                Defaults.LocatorType.CSS
                ),
        };
    }
}
