namespace AT.OrangeHRM.UI.StepDefinitions.Steps.auth
{
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Contains the steps for the Login.
    /// </summary>
    [Binding]
    public sealed class LoginSteps : BaseUISteps
    {
        /// <summary>
        /// The user name locator.
        /// </summary>
        private string userNameLocator = "txtUsername";

        /// <summary>
        /// The password locator.
        /// </summary>
        private string passwordLocator = "txtPassword";

        /// <summary>
        /// The sign in locator.
        /// </summary>
        private string signInLocator = "btnLogin";

        /// <summary>
        /// The constructor for <see cref="LoginSteps"/>.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        /// <param name="featureContext">The feature context.</param>
        public LoginSteps(ScenarioContext scenarioContext, FeatureContext featureContext) :
            base(scenarioContext, featureContext)
        {
        }

        /// <summary>
        /// Logins into Orange HRM.
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password.</param>
        public void LoginIntoOrangeHRM(string userName, string password)
        {
            WebBrowser.driver.FindElement(By.Id(userNameLocator)).SendKeys(userName);
            WebBrowser.driver.FindElement(By.Id(passwordLocator)).SendKeys(password);
            WebBrowser.driver.FindElement(By.Id(signInLocator)).Submit();
        }
    }
}
