using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo;

public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Test]
    public async Task Test1()
    {
        await Page.ClickAsync("text='Login'");

        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eaapp1.jpg"
        });

        await Page.FillAsync("#UserName", "admin");
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eaapp2.jpg"
        });

        await Page.FillAsync("#Password", "password");
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eaapp3.jpg"
        });

        await Page.ClickAsync("text='Log in'");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eaapp4.jpg"
        });

        await Expect(Page.Locator("text=Employee Details")).ToBeVisibleAsync();
    }
}