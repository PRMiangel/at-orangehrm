namespace AT.OrangeHRM.UI.StepDefinitions.Steps.Commons
{
    using AT.OrangeHRM.UI.StepDefinitions.Commons;
    using OpenQA.Selenium;
    using System;
    using System.Linq;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Contains the steps form navigation.
    /// </summary>
    [Binding]
    public sealed class NavigationSteps : BaseUISteps
    {
        /// <summary>
        /// The menu locator.
        /// </summary>
        private const string menuLocator = "menu";

        /// <summary>
        /// The constructor for <see cref="NavigationSteps"/>.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        /// <param name="featureContext">The feature context.</param>
        public NavigationSteps(ScenarioContext scenarioContext, FeatureContext featureContext) :
            base(scenarioContext, featureContext)
        {
        }

        /// <summary>
        /// Navigates to menu and sub-menu items.
        /// </summary>
        /// <param name="menuItem">The menu item text.</param>
        /// <param name="subMenuItem">The sub-menu item text.</param>
        [Given("I navigate to (.*) > (.*)")]
        [When("I navigate to (.*) > (.*)")]
        public void NavigateToMenuItemAndSubMenuItem(string menuItem, string subMenuItem)
        {
            GetMenuItem(menuItem).Click();
            GetMenuItem(subMenuItem).Click();
        }

        /// <summary>
        /// Gets the menu and sub-menu item.
        /// </summary>
        /// <param name="menuItemText">The menu/sub-menu item.</param>
        /// <returns>A menu/sub-menu item element.</returns>
        private IWebElement GetMenuItem(string menuItemText)
        {
            var menu = WebBrowser.driver.FindElement(By.ClassName(menuLocator));

            var menuItems = menu.FindElements(By.TagName(HTMLTag.A));

            if (!menuItems.Any(menuItem => menuItem.Text.Equals(menuItemText)))
            {
                throw new Exception($"No menu item with name: '{menuItemText}'");
            }

            return menuItems.Where(menuItem => menuItem.Text.Equals(menuItemText)).First();
        }
    }
}
