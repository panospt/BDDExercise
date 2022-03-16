using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace BDDExercise.Models
{
    public class HomePage
    {
        public string PagePath = "https://parabank.parasoft.com/parabank";
        public IPage Page { get; set; }
        public IBrowserContext BrowserContext { get; set; }
        public IBrowser Browser { get; set; }

        public HomePage(IBrowser browser)
        {
            Browser = browser;
        }

        public async Task NavigateToHomePage()
        {
            var BrowserContext = await Browser.NewContextAsync();
            Page = await BrowserContext.NewPageAsync();

            await Page.GotoAsync(PagePath);
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "screenshot.png"
            });
        }

        public async Task SetUsername(string username)
        {
            await Page.FillAsync("[name='username']", "");
            await Page.FillAsync("[name='username']", username);
        }

        public async Task SetPassword(string password)
        {
            await Page.FillAsync("[name='password']", "");
            await Page.FillAsync("[name='password']", password);
        }

        public async Task ClickLoginButton()
        {
            await Page.ClickAsync("[name='login'] [type='submit']");
        }

        public async Task VerifySuccessfulLogin()
        {
            await Page.IsVisibleAsync("[id='accountTable']");
        }

        public async Task VerifyLoginIsUnsuccessful()
        {
            await Page.IsVisibleAsync("//*[@id='rightPanel']//p[@class='error'][contains(text(), 'Please enter a username and password.')]");
        }

    }
}
