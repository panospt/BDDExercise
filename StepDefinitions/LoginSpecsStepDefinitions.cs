using BDDExercise.Models;
using Microsoft.Playwright;
using System;
using TechTalk.SpecFlow;

namespace BDDExercise.StepDefinitions
{
    [Binding]
    public class LoginSpecsStepDefinitions
    {
        private readonly HomePage _homePage;

        public LoginSpecsStepDefinitions(HomePage homePage)
        {
            _homePage = homePage;
        }

        [Given(@"User is navigated to home page")]
        public async Task GivenUserIsNavigatedToHomePage()
        {
            await _homePage.NavigateToHomePage();

        }

        [When(@"User logs in by providing valid credentials username (.*) and password (.*)")]
        public async Task WhenUserProvidesValidCredentials(string username, string password)
        {
            await _homePage.SetUsername(username);
            await _homePage.SetPassword(password);
            await _homePage.ClickLoginButton();
        }

        [Then(@"User is successfully logged in")]
        public async Task ThenUserIsSuccessfullyLoggedIn()
        {
            await _homePage.VerifySuccessfulLogin();
        }

        [When(@"User provides login username (.*)")]
        public async Task WhenUserProvidesLoginUsername(string username)
        {
            await _homePage.SetUsername(username);
        }

        [When(@"User provides login password (.*)")]
        public async Task WhenUserProvidesLoginPassword(string password)
        {
            await _homePage.SetUsername(password);
        }

        [When(@"User submits login form")]
        public async Task WhenUserSubmitsLogin()
        {
            await _homePage.ClickLoginButton();
        }

        [Then(@"User is not logged in")]
        public async Task ThenUserIsNotLoggedIn()
        {
            await _homePage.VerifyLoginIsUnsuccessful();
        }
    }

}
