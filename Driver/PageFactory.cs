using Gauge.CSharp.Lib.Attribute;
using UIAutomationChallenge.Pages;

namespace UIAutomationChallenge.Driver
{
    class PageFactory : BaseClass
    {
       
        public static HomePage homePage;
        public static AuthenticationPage authenticationPage;
        public static CreateAnAccountPage createAnAccountPage;
        public static MyAccountPage myAccountPage;

        [BeforeSuite]
        public void init()
        {
            homePage = new HomePage();
            authenticationPage = new AuthenticationPage();
            createAnAccountPage = new CreateAnAccountPage();
            myAccountPage = new MyAccountPage();
        }
    }
}
