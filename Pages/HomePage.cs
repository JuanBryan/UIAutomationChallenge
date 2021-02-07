using UIAutomationChallenge.Driver;
using OpenQA.Selenium;

namespace UIAutomationChallenge.Pages
{
    class HomePage : BaseClass
    {
        public readonly string HomeUrl = $"{BaseUrl}/index.php";
        readonly By HomeLogo = By.Id("header_logo");
        readonly By SignInButton = By.ClassName("login");
        
        public void ClickOnSignIn()
        {
            Click(SignInButton);
        }

        public void NavigateToUrl()
        {
            NavigateToUrl(HomeUrl);
            WaitUntilElementToBeClickable(HomeLogo);
        }

    }
}
