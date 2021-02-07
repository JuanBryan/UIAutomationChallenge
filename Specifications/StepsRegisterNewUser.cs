using System;
using UIAutomationChallenge.Driver;
using Gauge.CSharp.Lib.Attribute;
using UIAutomationChallenge.Utils;

namespace UIAutomationChallenge.Implementation
{
    class StepsRegisterNewUser : PageFactory
    {  
		[BeforeScenario]
        public void LogOut()
        {
            DataGenerator.ClearCsvFile();
        }

		[Step("Given the user go to Home Page")]
		public void GivenTheUserGoToHomePage()
		{
			homePage.NavigateToUrl();
		}
	
		[Step("When  the user clicks on Sign in button")]
		public void WhenTheUserClicksOnSignInButton()
		{
			homePage.ClickOnSignIn();
		}
	
		[Step("And   the user fill in email address to create account")]
		public void AndTheUserFillInEmailAddressToCreateAccount()
		{
			authenticationPage.FillEmailAddressInput(DataGenerator.GenerateRandomEmail());
		}
	
		[Step("And   the user clicks Create an account")]
		public void AndTheUserClicksCreateAnAccount()
		{
			authenticationPage.ClickOnCreateAccountButton();
		}
	
		[Step("And   the user fill all fields with correct data")]
		public void AndTheUserFillAllFieldsWithCorrectData()
		{
			createAnAccountPage.CreateNewAccount(DataGenerator.GenerateRandomUser());
		}
	
		[Step("And   the user clicks on Register Button")]
		public void AndTheUserClicksOnRegisterButton()
		{
			createAnAccountPage.ClickOnRegisterButton();
		}
	
		[Step("Then  the user verifies that the account page is displayed")]
		public void ThenTheUserVerifiesThatTheAccountPageIsDisplayed()
		{
			AssertContains(myAccountPage.VerifyUserIsRedirectedToUserAccountPage(), Environment.GetEnvironmentVariable("APP_MY_ACCOUNT") , "The account Page was not displayed");
		}
	
		[Step("Then  the user verifies that the proper username is shown in the header")]
		public void ThenTheUserVerifiesThatTheProperUsernameIsShownInTheHeader()
		{
			AreEqual(myAccountPage.GetUserNameText(), Utility.GetUsernameFromCSV(), "The name Account is not equal than the user used");
		}
	
		[Step("Then  the user verifies that log out action is available")]
		public void ThenTheUserVerifiesThatLogOutActionIsAvailable()
		{
			AssertTrue(myAccountPage.VerifySignOutButtonIsDisplayed(), "The logout action is not available");
		}
	}
}