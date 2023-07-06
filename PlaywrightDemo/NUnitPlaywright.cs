using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemo.Pages;

namespace PlaywrightDemo;

public class NUnitPlaywright
{
    [SetUp]
    public async Task Setup()
    {
        
    }

    [Test]
    public async Task Test1()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var page = await browser.NewPageAsync();

        await page.GotoAsync("http://www.eaapp.somee.com");

        LoginPage loginPage = new LoginPage(page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");
        bool isExist = await loginPage.IsEmployeeDetailsExists();

        Assert.IsTrue(isExist);
    }
}