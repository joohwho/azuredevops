using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo.Pages;

public class LoginPage
{
    private IPage _page;
    private ILocator _linkLogin => _page.Locator("text='Login'");
    private ILocator _inputUserName => _page.Locator("#UserName");
    private ILocator _inputPassword => _page.Locator("#Password");
    private ILocator _btnLoginIn => _page.Locator("input", new PageLocatorOptions { HasTextString = "Log in" });
    private ILocator _linkEmployeeDetails => _page.Locator("text=Employee Details");

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task ClickLogin() => await _linkLogin.ClickAsync();

    public async Task Login(string username, string password)
    {
        await _inputUserName.FillAsync(username);
        await _inputPassword.FillAsync(password);
        await _btnLoginIn.ClickAsync();
    }

    public async Task<bool> IsEmployeeDetailsExists() => await _linkEmployeeDetails.IsVisibleAsync();
}
