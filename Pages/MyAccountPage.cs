using UIAutomationChallenge.Driver;
using OpenQA.Selenium;

namespace UIAutomationChallenge.Pages
{
    class MyAccountPage : BaseClass
    {
        public static readonly string MyAccountUrl = $"{BaseUrl}?controller=my-account";

        By PageHeading = By.ClassName("page-heading");
        By UserNameTitle = By.ClassName("account");
        By LogOutButton = By.ClassName("logout");
    
        public string VerifyUserIsRedirectedToUserAccountPage()
        {
            FluentWaitForElementToBeVisible(PageHeading);
            return MyAccountUrl;
        }

        public string GetUserNameText()
        {
            return GetVisibleText(UserNameTitle);
        }

        public bool VerifySignOutButtonIsDisplayed(){
            try
            {
                WaitUntilElementToBeClickable(LogOutButton);
                return true;
            }
            catch (System.Exception)
            {
                WriteMessage ("Element was not found because this will not present");
                return false;
                throw;
            }
        }
    }
}
