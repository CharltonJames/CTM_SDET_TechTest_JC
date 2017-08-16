

namespace SF_PAGES
{
    //contains statically defined default values
    public static class Defaults
    {
        public static string baseURL = @"https://energy.comparethemarket.com/energy/v2/";
        public static string homePage = @"https://energy.comparethemarket.com/energy/v2/?AFFCLIE=TSTT";
        public static string postCode = @"PE2 6YS";
        public static string email = @"CTMTest@JCtesting.com";
        public static int timoutSecs = 10; // page timeout
        public static string TestBrowser = "IE";  // options are IE, FF, C 
        public enum Suppliers { BG, EDF, EON, npower, SP, SSE, IDK };
        public enum OptionType { TEXTBOX, CHOICE, DROPBOX, BUTTON, CHOICEBUTTONS, BESPOKE, RADIOBUTTONS, DATEPICKER, SECTION };
        public enum LocatorType { ID, CSS, XPATH };
    }
}
