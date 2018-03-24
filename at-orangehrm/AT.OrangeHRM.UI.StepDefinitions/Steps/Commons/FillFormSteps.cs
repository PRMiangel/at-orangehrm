namespace AT.OrangeHRM.UI.StepDefinitions.Steps.Commons
{
    using AT.OrangeHRM.UI.StepDefinitions.Commons;
    using OpenQA.Selenium;
    using System;
    using System.Linq;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Contains fill form steps
    /// </summary>
    [Binding]
    public sealed class FillFormSteps : BaseUISteps
    {
        /// <summary>
        /// The constructor for <see cref="FillFormSteps"/>.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        /// <param name="featureContext">The feature context.</param>
        public FillFormSteps(ScenarioContext scenarioContext, FeatureContext featureContext) :
            base(scenarioContext, featureContext)
        {
        }

        /// <summary>
        /// Fills the given fields with the given values of the table.
        /// </summary>
        /// <param name="table">The table.</param>
        [When("I Fill the following values?")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(Table table)
        {
            foreach (var row in table.Rows)
            {
                GetField(row[0]).SendKeys(row[1]);
            }
        }

        /// <summary>
        /// Gets the field element given its name.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <returns>The text field element.</returns>
        private IWebElement GetField(string fieldName)
        {
            var inputs = WebBrowser.driver.FindElements(By.TagName(HTMLTag.Input));

            var inputsFiltered = inputs
                .Where(input => input.GetAttribute("id").ToLower().Equals(fieldName.ToLower().Replace(" ", ""))).ToList();

            if (!inputsFiltered.Any())
            {
                throw new Exception($"No text field with name: {fieldName}");
            }

            return inputsFiltered.First();
        }
    }
}
