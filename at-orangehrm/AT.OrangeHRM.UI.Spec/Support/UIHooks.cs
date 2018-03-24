namespace AT.OrangeHRM.UI.Spec.Support
{
    using AT.OrangeHRM.UI.StepDefinitions.Commons;
    using AT.OrangeHRM.UI.StepDefinitions.Steps;
    using AT.OrangeHRM.UI.StepDefinitions.Steps.auth;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Contains the UI hooks.
    /// </summary>
    [Binding]
    public sealed class UIHooks : BaseUISteps
    {
        /// <summary>
        /// The constructor for <see cref="UIHooks"/>.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        /// <param name="featureContext">The feature context.</param>
        public UIHooks(ScenarioContext scenarioContext, FeatureContext featureContext) :
            base(scenarioContext, featureContext)
        {
        }

        /// <summary>
        /// Opens the web browser.
        /// </summary>
        /// <param name="featureContext"></param>
        [BeforeScenario(Order = 10)]
        public static void OpenBrowser(FeatureContext featureContext)
        {
            var webBrowser = new WebBrowserSteps();
            featureContext[Keys.WebBrowser] = webBrowser;
            webBrowser.OpenWebBrowser("chrome");
        }

        /// <summary>
        /// Go to Orange HRM.
        /// </summary>
        /// <param name="featureContext"></param>
        [BeforeScenario(Order = 10)]
        public static void GotoOrangeHRM(FeatureContext featureContext)
        {
            ((WebBrowserSteps)featureContext[Keys.WebBrowser]).GoTo("http://opensource.demo.orangehrmlive.com");
        }

        /// <summary>
        /// Login into Orange HRM.
        /// </summary>
        [BeforeScenario]
        public void LoginIntoOrangeHRM()
        {
            var loginSteps = new LoginSteps(ScenarioContext, FeatureContext);

            loginSteps.LoginIntoOrangeHRM("Admin", "admin");
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }

        /// <summary>
        /// Closes the browser.
        /// </summary>
        /// <param name="featureContext"></param>
        [AfterFeature]
        public static void CloseBrowser(FeatureContext featureContext)
        {
            ((WebBrowserSteps)featureContext[Keys.WebBrowser]).CloseWebBrowser();
        }
    }
}
