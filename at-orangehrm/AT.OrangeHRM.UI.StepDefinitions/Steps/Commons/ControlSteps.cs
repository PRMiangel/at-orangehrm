namespace AT.OrangeHRM.UI.StepDefinitions.Steps.Commons
{
    using AT.OrangeHRM.UI.StepDefinitions.Commons;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System.Linq;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Contains the common control steps.
    /// </summary>
    [Binding]
    public sealed class ControlSteps : BaseUISteps
    {
        /// <summary>
        /// The button locator.
        /// </summary>
        private const string buttonLocator = "//*[@type='button' and @value='{0}']";

        /// <summary>
        /// The constructor for <see cref="ControlSteps"/>.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        /// <param name="featureContext">The feature context.</param>
        public ControlSteps(ScenarioContext scenarioContext, FeatureContext featureContext) :
            base(scenarioContext, featureContext)
        {
        }

        /// <summary>
        /// Clicks on a button.
        /// </summary>
        /// <param name="name"></param>
        [When(@"I click on (.*) button")]
        public void ClickTheButton(string name)
        {
            string locator = string.Format(buttonLocator, name);
            WebBrowser.driver.FindElement(By.XPath(locator)).Click();
        }

        /// <summary>
        /// Fills a value in a text field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        [When(@"I fill '(.*)' in (.*) field")]
        public void FillTextField(string value, string fieldName)
        {
            var inputs = WebBrowser.driver.FindElements(By.TagName(HTMLTag.Input));

            var inputsFiltered = inputs
                .Where(input =>
                input.GetAttribute("name").ToLower().Replace("_", "")
                .Contains(fieldName.ToLower().Replace(" ", ""))).ToList();

            inputsFiltered.First().SendKeys(value);
            inputsFiltered.First().SendKeys(OpenQA.Selenium.Keys.Tab);
        }

        /// <summary>
        /// Verify a value in a table.
        /// </summary>
        /// <param name="expectedResult"></param>
        [Then("I should see '(.*)' in the table")]
        public void VerifyValueInTheTable(string expectedResult)
        {
            var table = WebBrowser.driver.FindElement(By.Id("tableWrapper"));

            bool value = false;

            foreach (var cell in table.FindElements(By.TagName(HTMLTag.Td)))
            {
                if (cell.Text.Equals(expectedResult))
                {
                    value = true;
                    break;
                }
            }
            Assert.IsTrue(value, $"The value '{expectedResult}' was not displayed.");
        }
    }
}
