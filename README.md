# INTRODUCTION:

This Visual Studio 2017 Solution contains two projects:
	SF_PAGES
		This project contains framework related code, default values and configuration data
	SF_TESTS
		This project contains the test suite.

This solution contains example tests and the framework code used for the CTM-SDET techincal test. 
The framework is built around the use of Selenium for driving web interaction and Specflow for defining the test scenarios/cases and is written in C#.

## Prerequisites

In order to replicate the development environment used to run the existing tests please ensure the following:
	1.Operating System = Windows 7 - 64Bit
	2.Browser Version = IE11 - 11.0.9600.18783
		Update Versions: 11.0.44 (KB4025252)
	3.The user has admin rights on the machine
		
On the following link, please ensure the information within the "Required Configuration" section has been performed on IE11:
https://github.com/SeleniumHQ/selenium/wiki/InternetExplorerDriver

		
## Notes

The following important points should be noted by anyone running the tests in this project:

1. The IE driver appears to be very slow at entering text into text fields so please give the driver time to action these commands
2. The IEDriverServer.exe is set to automatically copy to the build output directory with every build. If the driver is currently loaded in memory then an error may be raised on a build. If this happens please force this application down form the task manager. The framework will automatically attempt to kill this process before and after the tests however this action will not occur if the user is debugging and stops the tests.
3. 	The solution has not been been ran on any other machine.
		
		
## Future Improvements

The following improvements would benefit the flexibility of the framework:
	1. The definition of default values should be stored in a different format and not hardcoded into the project. I would like this to be externally provided in a friendly format such as XML or JSON however this would require extra work to parse the data from these formats
	2. The definition of PageOptions should also be moved to XML or JSON so as to allow the framework to be flexible for other web sites
	3. It might be possible to automatically generate the XML or JSON data for the web site under test through some form of data scraping(investigation needed)

The following improvements/notes should be made (unfinished):
	1. Not all Locator options are supported and handling of certain actions on certain element types is not fully finished.
	2. Framework functions return simple pass/fail (true, false) and should be providing better feedback for debugging
	3. The framework has only been tested through real usage - Unit tests should be added.
	4. The tests should be re-ran on different browsers to understand how the framework performs.

## Version
N/A

## Author

James Charlton - jamescharlton1@aol.com