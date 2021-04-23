using System;
using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages.AccountCreation
{
    public class AccountVerification : BasePage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div[2]/div/div/form/div[1]/h2")] private static IWebElement emailSentText;

        [FindsBy(How = How.Id, Using = "btnResendEmail")] private static IWebElement btnResendEmail;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div[2]/div/div/form/div[2]/p")] private static IWebElement followdirectionText;

        public AccountVerification(IExtendedWebDriver webDriver, Options options) : base(webDriver)
        {
            PageUrl = new Uri(options.SiteUri, "Account/VerificationEmailSent").ToString();
        }

    }
}
