using Crawler.Models;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using System.Diagnostics;

namespace Crawler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebDriver _webDriver;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            var chrome = "wwwroot//chrome-win64//chrome.exe";
            var chromeDriver = "wwwroot//chromedriver-win64//chromedriver.exe";
            _webDriver = WebDriverExtensions.ConfigureWebDriver(chromeDriver, chrome);
        }

        public async Task<IActionResult> Index()
        {
            var url = "https://abadis.ir/name/all/avestai/";
            _webDriver.Navigate().GoToUrl(url);

            //await Task.Delay(TimeSpan.FromSeconds(5));
            // Locate the parent element containing the names
            IWebElement boxNames = _webDriver.FindElement(By.ClassName("boxNames"));

            // Locate all the child elements with class "boxName"
            IReadOnlyCollection<IWebElement> boxNameElements = boxNames.FindElements(By.ClassName("boxName"));
            var names = new List<string>();
            // Iterate through each boxName element
            foreach (IWebElement boxNameElement in boxNameElements)
            {
                string name = boxNameElement.FindElementOrNull(By.CssSelector("span.boxGirl > a"))?.Text;
                if (name == null)
                {
                    name = boxNameElement.FindElementOrNull(By.CssSelector("span.boxBoy > a"))?.Text;
                }
                names.Add(name);
            }

            return View(names);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
