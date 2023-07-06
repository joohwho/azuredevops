using Microsoft.Playwright;

namespace PlaywrightDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        // Playwright
        using var playwright = await Playwright.CreateAsync();

        // Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        // Page
        var page = await browser.NewPageAsync();

        await page.GotoAsync("http://www.eaapp.somee.com");

        await page.ClickAsync("text='Login'");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eaapp1.jpg"
        });

        await page.FillAsync("#UserName", "admin");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eaapp2.jpg"
        });

        await page.FillAsync("#Password", "password");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eaapp3.jpg"
        });

        await page.ClickAsync("text='Log in'");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eaapp4.jpg"
        });

        var isExist = await page.Locator("text=Employee Details").IsVisibleAsync();

        Assert.IsTrue(isExist);
    }
}