using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace BDDExercise.Models
{
    public class RegistrationPage : HomePage
    {
        public string PagePath = "https://parabank.parasoft.com/parabank/register.htm";
        public RegistrationPage(IBrowser browser) : base(browser)
        {
            BrowserContext = browser.Contexts.FirstOrDefault();
        }

        public async Task NavigateToRegistrationPage()
        {
            Page = await BrowserContext.NewPageAsync();
            await Page.GotoAsync(PagePath);
            await Page.ClickAsync("//a[@href='register.htm']");
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "screenshot.png"
            });

            await Page.IsVisibleAsync("//form[id='customerForm']");
        }

        public async Task SetFirstName(string firstName)
        {
            await Page.FillAsync("[id='customer.firstName']", firstName);
        }

        public async Task SetLastName(string lastName)
        {
            await Page.FillAsync("[id='customer.lastName']", lastName);
        }

        public async Task SetAddress(string address)
        {
            await Page.FillAsync("[id='customer.address.street']", address);
        }

        public async Task SetCity(string city)
        {
            await Page.FillAsync("[id='customer.address.city']", city);
        }

        public async Task SetState(string state)
        {
            await Page.FillAsync("[id='customer.address.state']", state);
        }

        public async Task SetZipCode(string zipCode)
        {
            await Page.FillAsync("[id='customer.address.zipCode']", zipCode);
        }

        public async Task SetPhone(string phone)
        {
            await Page.FillAsync("[id='customer.phoneNumber']", phone);
        }

        public async Task SetSSN(string ssn)
        {
            await Page.FillAsync("[id='customer.ssn']", ssn);
        }

        public async Task SetUsername(string username)
        {
            await Page.FillAsync("[id='customer.username']", username);
        }

        public async Task SetPassword(string password)
        {
            await Page.FillAsync("[id='customer.password']", password);
        }

        public async Task SetRepeatedPassword(string password)
        {
            await Page.FillAsync("[id='repeatedPassword']", password);
        }

        public async Task SubmitRegistration()
        {
            await Page.ClickAsync("[id='customerForm'] [type='submit']");
        }

        public async Task VerifyRegistration()
        {
            await Page.IsVisibleAsync("//*[@id='rightPanel']//h1[@class='title'][contains(text(), 'Welcome')]");
        }

        public async Task VerifyAlreadyRegistered()
        {
            await Page.IsVisibleAsync("//*[@id='customer.username.errors'][contains(text(), 'This username already exists')]");
        }

        public async Task FirstNameIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.firstName.errors'][contains(text(), 'First name is required')]");
        }

        public async Task LastNameIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.lastName.errors'][contains(text(), 'Last name is required')]");
        }

        public async Task AddressIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.address.street.errors'][contains(text(), 'Address is required')]");
        }

        public async Task CityIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.address.city.errors'][contains(text(), 'City is required')]");
        }

        public async Task StateIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.address.state.errors'][contains(text(), 'State is required')]");
        }

        public async Task ZipCodeIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.address.zipCode.errors'][contains(text(), 'Zip Code is required')]");
        }

        public async Task SSNIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.ssn.errors'][contains(text(), 'Social Security Number is required')]");
        }

        public async Task UsernameIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.username.errors'][contains(text(), 'Username is required')]");
        }

        public async Task PasswordIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='customer.password.errors'][contains(text(), 'Password is required')]");
        }

        public async Task RepeatedPasswordIsRequired()
        {
            await Page.IsVisibleAsync("//*[@id='repeatedPassword.errors'][contains(text(), 'Password confirmation is required')]");
        }
    }
}
