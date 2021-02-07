using UIAutomationChallenge.Driver;
using OpenQA.Selenium;

namespace UIAutomationChallenge.Pages
{
    class AuthenticationPage : BaseClass
    {
        By RegisterEmailTextBox = By.Id("email_create");
        By CreateAccountButton = By.Id("SubmitCreate");
    
        public void FillEmailAddressInput(string email)
        {
            SendKeys(RegisterEmailTextBox, email);
        }

        public void ClickOnCreateAccountButton()
        {
            Click(CreateAccountButton);
        }
    }
}
