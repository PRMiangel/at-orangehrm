using AT.OrangeHRM.UI.StepDefinitions.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AT.OrangeHRM.UI.StepDefinitions.Steps
{
    public abstract class BaseUISteps
    {
        protected FeatureContext FeatureContext;
        protected ScenarioContext ScenarioContext;

        protected BaseUISteps(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            ScenarioContext = scenarioContext;
            FeatureContext = featureContext;
        }

        protected WebBrowserSteps WebBrowser
        {
            get
            {
                if (!FeatureContext.Keys.Any(key => key.Equals(Keys.WebBrowser)))
                {
                    throw new Exception("You don't have a session for the web browser.");
                }

                return (WebBrowserSteps)FeatureContext[Keys.WebBrowser];
            }
        }
    }
}
