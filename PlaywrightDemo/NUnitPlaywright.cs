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
        Console.WriteLine("CreateAsync");
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        Console.WriteLine("LaunchAsync");
        var page = await browser.NewPageAsync();
        Console.WriteLine("NewPageAsync");

        await page.GotoAsync("http://www.eaapp.somee.com");
        Console.WriteLine("GotoAsync");

        LoginPage loginPage = new LoginPage(page);
        Console.WriteLine("LoginPage");
        await loginPage.ClickLogin();
        Console.WriteLine("ClickLogin");
        await loginPage.Login("admin", "password");
        Console.WriteLine("Login");
        bool isExist = await loginPage.IsEmployeeDetailsExists();
        Console.WriteLine("IsEmployeeDetailsExists");

        Assert.IsTrue(isExist);
        Console.WriteLine("Assert.IsTrue");
        Console.WriteLine("Passed!");
    }
}