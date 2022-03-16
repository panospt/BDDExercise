using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDDExercise.Models;
using Microsoft.Playwright;

namespace BDDExercise.StepDefinitions
{
    [Binding]
    public class RegistrationSpecsStepDefinitions
    {
        private readonly RegistrationPage _registrationPage;

        public RegistrationSpecsStepDefinitions(IBrowser browser)
        {
            _registrationPage = new RegistrationPage(browser);
        }

        public string Password { get; set; }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Given(@"User is navigated to registration page")]
        public async Task GivenUserIsNavigatedToRegistrationPage()
        {
            await _registrationPage.NavigateToRegistrationPage();

        }

        [When(@"User provides first name (.*)")]
        public async Task WhenUserProvidesFirstName(string firstName)
        {
            await _registrationPage.SetFirstName(firstName);
        }

        [When(@"User provides last name (.*)")]
        public async Task WhenUserProvidesLastName(string lastName)
        {
            await _registrationPage.SetLastName(lastName);
        }

        [When(@"User provides address (.*)")]
        public async Task WhenUserProvidesAddress(string address)
        {
            await _registrationPage.SetAddress(address);
        }

        [When(@"User provides city (.*)")]
        public async Task WhenUserProvidesCity(string city)
        {
            await _registrationPage.SetCity(city);
        }

        [When(@"User provides state (.*)")]
        public async Task WhenUserProvidesState(string state)
        {
            await _registrationPage.SetState(state);
        }

        [When(@"User provides zip code (.*)")]
        public async Task WhenUserProvidesZipCode(string zipCode)
        {
            await _registrationPage.SetZipCode(zipCode);
        }

        [When(@"User provides phone (.*)")]
        public async Task WhenUserProvidesPhone(string phone)
        {
            await _registrationPage.SetPhone(phone);
        }

        [When(@"User provides SSN (.*)")]
        public async Task WhenUserProvidesSSN(string ssn)
        {
            await _registrationPage.SetSSN(ssn);
        }

        [When(@"User provides random username")]
        public async Task WhenUserProvidesRandomUsername()
        {
            string username = RandomString(5);
            await _registrationPage.SetUsername(username);
        }

        [When(@"User provides random password")]
        public async Task WhenUserProvidesRandomPassword()
        {
            string password = RandomString(5);
            Password = password;

            await _registrationPage.SetPassword(password);
        }

        [When(@"User provides repeated random password")]
        public async Task WhenUserProvidesRandomRepeatedPassword()
        {
            await _registrationPage.SetRepeatedPassword(Password);
        }

        [When(@"User provides username (.*)")]
        public async Task WhenUserProvidesUsername(string username)
        {
            await _registrationPage.SetUsername(username);
        }

        [When(@"User provides password (.*)")]
        public async Task WhenUserProvidesPassword(string password)
        {
            await _registrationPage.SetPassword(password);
        }

        [When(@"User provides repeated password (.*)")]
        public async Task WhenUserProvidesRepeatedPassword(string password)
        {
            await _registrationPage.SetRepeatedPassword(password);
        }

        [When(@"User submits registration form")]
        public async Task WhenUserSubmitsRegistrationForm()
        {
            await _registrationPage.SubmitRegistration();
        }

        [Then(@"User is registered successfully")]
        public async Task ThenUserIsRegisteredSuccessfully()
        {
            await _registrationPage.VerifyRegistration();
        }

        [Then(@"User is already registered")]
        public async Task ThenUserIsAlreadyRegistered()
        {
            await _registrationPage.VerifyAlreadyRegistered();
        }

        [Then(@"First name is required")]
        public async Task ThenFirstNameIsRequired()
        {
            await _registrationPage.FirstNameIsRequired();
        }

        [Then(@"Last name is required")]
        public async Task ThenLastNameIsRequired()
        {
            await _registrationPage.LastNameIsRequired();
        }

        [Then(@"Address is required")]
        public async Task ThenAddressIsRequired()
        {
            await _registrationPage.AddressIsRequired();
        }

        [Then(@"City is required")]
        public async Task ThenCityIsRequired()
        {
            await _registrationPage.CityIsRequired();
        }

        [Then(@"State is required")]
        public async Task ThenStateIsRequired()
        {
            await _registrationPage.StateIsRequired();
        }

        [Then(@"Zip Code is required")]
        public async Task ThenZipCodeIsRequired()
        {
            await _registrationPage.ZipCodeIsRequired();
        }

        [Then(@"SSN is required")]
        public async Task ThenSSNIsRequired()
        {
            await _registrationPage.SSNIsRequired();
        }

        [Then(@"Username is required")]
        public async Task ThenUsernameIsRequired()
        {
            await _registrationPage.UsernameIsRequired();
        }

        [Then(@"Password is required")]
        public async Task ThenPasswordIsRequired()
        {
            await _registrationPage.PasswordIsRequired();
        }

        [Then(@"Repeated password is required")]
        public async Task ThenRepeatedPasswordIsRequired()
        {
            await _registrationPage.RepeatedPasswordIsRequired();
        }

    }
}
