using NUnit.Framework;

namespace SpecflowProjectFebuarybatch2022.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        ScenarioContext _scenarioContext;
        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
             _scenarioContext.Add("firstnumber", number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _scenarioContext.Add("secondnumber", number);
        }

        [When("the two numbers are '(.*)'")]
        public void WhenTheTwoNumbersAreAdded(string calc)
        {
            ScenarioContext.Current["actualResult"] = calc.Equals("added")
                ? _scenarioContext.Get<int>("firstnumber") + _scenarioContext.Get<int>("secondnumber")
                : calc.Equals("subtracted") 
                ? _scenarioContext.Get<int>("secondnumber") - _scenarioContext.Get<int>("firstnumber")
                : calc.Equals("divided")
                ? _scenarioContext.Get<int>("secondnumber") / _scenarioContext.Get<int>("firstnumber") : 0;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.AreEqual(expectedResult, _scenarioContext.Get<int>("actualResult"));
        }
    }
}