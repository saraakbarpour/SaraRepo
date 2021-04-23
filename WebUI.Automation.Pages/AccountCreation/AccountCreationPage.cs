using System;
using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages.AccountCreation
{
	public class AccountCreationPage : BasePage
	{
        [FindsBy(How = How.Id, Using = "Name")] private static IWebElement nameTextbox;

        [FindsBy(How = How.Id, Using = "Email")] private static IWebElement emailTextbox;

        [FindsBy(How = How.Id, Using = "Password")] private static IWebElement passwordTextbox;

        [FindsBy(How = How.Id, Using = "ConfirmPassword")] private static IWebElement confirmPasswordTextbox;

        [FindsBy(How = How.Id, Using = "AcceptTermsAndConditions")] private static IWebElement AcceptTermsAndConditions;

        [FindsBy(How = How.Id, Using = "btnCreateAccount")] private static IWebElement createAccountButton;
        public AccountCreationPage(IExtendedWebDriver webDriver, Options options) : base(webDriver)
        {
            PageUrl = new Uri(options.SiteUri, "Account/Create").ToString();
        }

        public void EnterName(string name)
        {
            nameTextbox.Clear();
            nameTextbox.SendKeys(name);
        }

        public void EnterEmail(string email)
        {
            //Clear text box
            emailTextbox.Clear();
            //Enter text
            emailTextbox.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            //Clear text box
            passwordTextbox.Clear();
            //Enter text
            passwordTextbox.SendKeys(password);
        }
        public void EnterConfirmPassword(string password)
        {
            //Clear text box
            confirmPasswordTextbox.Clear();
            //Enter text
            confirmPasswordTextbox.SendKeys(password);
        }

        public void ClickCreateAccount()
        {
            //Click the add button
            createAccountButton.Click();

        }
        public void CheckCheckBox()
        {
            //Click the add button
            AcceptTermsAndConditions.Click();

        }
    }
}
