using UIAutomationChallenge.Driver;
using OpenQA.Selenium;
using UIAutomationChallenge.ObjectModels;
using UIAutomationChallenge.Utils;

namespace UIAutomationChallenge.Pages
{
    class CreateAnAccountPage : BaseClass
    {
        #region Your Personal Information
        By TitleMrRadioBtn = By.Id("uniform-id_gender1");
        By TitleMrsRadioBtn = By.Id("uniform-id_gender2");
        By FirstNameInput = By.Id("customer_firstname");
        By LastNameInput = By.Id("customer_lastname");
        By PasswordInput = By.Id("passwd");
        By DaysDropdown = By.Id("days");
        By MonthsDropdown = By.Id("months");
        By YearsDropdown = By.Id("years");
        #endregion

        #region Your Address
        By AddressInput = By.Id("address1");
        By CityInput = By.Id("city");
        By StateDropDown = By.Id("id_state");
        By ZipPostalCode = By.Id("postcode");
        By CountryDropDown = By.Id("id_country");
        By MobilePhoneInput = By.Id("phone_mobile");
        By AliasAddressInput = By.Id("alias");
        #endregion

        By RegisterButton = By.Id("submitAccount");

        public void CreateNewAccount(User user)
        {
            WaitUntilElementToBeClickable(TitleMrRadioBtn);
            if (user.Title.Equals("Mr."))
                Click(TitleMrRadioBtn);
            else
                Click(TitleMrsRadioBtn);
            
            SendKeys(FirstNameInput, user.FirstName);
            SendKeys(LastNameInput, user.LastName);
            SendKeys(PasswordInput, user.Password);
            SelectByValue(DaysDropdown, user.DateBirth.Day.ToString());
            SelectByValue(MonthsDropdown, user.DateBirth.Month.ToString());
            SelectByValue(YearsDropdown, user.DateBirth.Year.ToString());
            SendKeys(CityInput, user.City);
            SelectByText(StateDropDown, user.State);
            SendKeys(ZipPostalCode, user.ZipCode.ToString());
            SelectByText(CountryDropDown, user.Country);
            SendKeys(AddressInput, user.Address);
            SendKeys(MobilePhoneInput, user.MobilePhone.ToString());
            SendKeys(AliasAddressInput, user.AddressAlias);

            DataGenerator.AddMoreUsersToCsvFile(user);
        }
        public void ClickOnRegisterButton()
        {
            Click(RegisterButton);
        }
    }
}
