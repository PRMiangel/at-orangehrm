namespace AT.OrangeHRM.UI.StepDefinitions.Steps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Contains the web browser steps.
    /// </summary>
    [Binding]
    public sealed class WebBrowserSteps
    {
        /// <summary>
        /// The selenium driver.
        /// </summary>
        internal IWebDriver driver;

        /// <summary>
        /// Opens the web browser.
        /// </summary>
        /// <param name="browserName"></param>
        [Given("I open (chrome) web browser")]
        public void OpenWebBrowser(string browserName)
        {
            driver = new ChromeDriver();
        }

        /// <summary>
        /// Goes to the given URL.
        /// </summary>
        /// <param name="url"></param>
        [Given("I go to '(.*)'")]
        public void GoTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Closes the web browser
        /// </summary>
        [When("I close the web browser")]
        public void CloseWebBrowser()
        {
            driver.Quit();
        }
    }
}
