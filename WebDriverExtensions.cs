using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Drawing;

namespace Crawler
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementOrNull(this IWebElement driver, By locator)
        {
            try
            {
                return driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public static IWebElement FindElementOrNull(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public static IReadOnlyCollection<IWebElement> FindElementsOrNull(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElements(locator);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public static IWebDriver ConfigureWebDriver(string chromedriver, string chromePath)
        {

            //ChromeOptions chromeOptions = new ChromeOptions();
            ////chromeOptions.AddArguments("--disable-popup-blocking");
            ////string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36";
            //string userAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.84 Safari/537.36";

            //chromeOptions.AddArgument("--user-agent=" + userAgent);
            //chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            ////chromeOptions.AddArgument("--disable-automation");

            //chromeOptions.BinaryLocation = chromePath;
            //IWebDriver driver = new ChromeDriver(chromedriver, chromeOptions);
            //driver.Manage().Window.Maximize();
            //---------------------------------------------------------------------

            //https://github.com/fysh711426/UndetectedChromeDriver
            //var chromeDriver = "C:\\driver\\chromedriver-win64\\chromedriver.exe";
            //var chrome = "C:\\driver\\chrome-win64\\chrome.exe";
            //var options = new ChromeOptions();
            ////string userAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.84 Safari/537.36";

            ////options.AddArgument("--user-agent=" + userAgent);
            ////options.AddArgument("--disable-blink-features=AutomationControlled");

            //options.AddArguments("--lang=de");
            //var prefs = new Dictionary<string, object>
            //{
            //    ["profile.default_content_setting_values.geolocation"] = 1
            //};
            ////options.AddArgument("--auto-open-devtools-for-tabs");

            //var driver = UndetectedChromeDriver.Create(driverExecutablePath: chromeDriver,
            //    browserExecutablePath: chrome,
            //    options: options,
            //    hideCommandPromptWindow: true);
            //driver.ExecuteCdpCommand(
            //       "Emulation.setGeolocationOverride",
            //       new Dictionary<string, object>
            //       {
            //           ["latitude"] = 52.5200, // Berlin latitude
            //           ["longitude"] = 13.4050, // Berlin longitude
            //           ["accuracy"] = 100
            //       });

            //driver.ExecuteCdpCommand(
            //    "Emulation.setTimezoneOverride",
            //    new Dictionary<string, object>
            //    {
            //        ["timezoneId"] = "Europe/Berlin" // Berlin timezone
            //    });
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("start-maximized");
            //options.AddArguments("--disable-popup-blocking");
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.5993.89 Safari/537.36";
            //options.AddArguments("start-maximized");
            options.AddArgument("--user-agent=" + userAgent);
            options.AddArgument("--disable-blink-features=AutomationControlled");
            //options.AddArgument("--enable-automation");
            //options.AddArgument("--useAutomationExtension=false");
            //options.AddArguments("--disable-extensions");
            //options.AddArguments("--disable-plugins-discovery");
            //options.AddArguments("--disable-infobars");
            //options.AddArguments("--profile-directory=Default");
            //options.AddArguments("--disable-plugins-discovery");

            //-----------------------
            options.AddArgument("--enable-http2");

            options.BinaryLocation = chromePath;
            IWebDriver driver = new ChromeDriver(chromedriver, options);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1051);
            driver.Manage().Window.Position = new Point(0, 0);
            return driver;
        }
        public static IWebDriver ConfigureWebDriverFireFox(string pathDriver)
        {
            // Configure Firefox options
            FirefoxOptions firefoxOptions = new FirefoxOptions();

            firefoxOptions.BrowserExecutableLocation = pathDriver;

            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            driver.Manage().Window.Maximize();
            return driver;
        }


    }
}
