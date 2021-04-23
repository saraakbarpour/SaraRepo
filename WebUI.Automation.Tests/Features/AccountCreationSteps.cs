using System;
using TechTalk.SpecFlow;
using WebUI.Automation.Pages.AccountCreation;
using OpenQA.Selenium.Support.PageObjects;
using WebUI.Automation.Pages;
using NUnit.Framework;
using WebUI.Automation.WebDriver;

namespace WebUI.Automation.Tests.Features
{
    [Binding]
    public class AccountCreationSteps
    {
        //Page Object for AccountCreate page
        private readonly AccountCreationPage _AccountCreationPageObject;
        private WebDriverFactory _WebDriverFactory = new WebDriverFactory();
        private WebDriver = _WebDriverFactory.create();
     //       _AccountCreationPageObject = new AccountCreationPage()
       public AccountCreationSteps(WebDriverFactory _WebDriverFactory)
        {
            _AccountCreationPageObject = new AccountCreationPage(_WebDriverFactory.Create("Chrome"), null);
        }

        [Given(@"I am on the '(.*)' page")]
        public void GivenIAmOnThePage(string p0)
        {
           
        }
        
        [Given(@"I have filled out all my details correctly")]
        public void GivenIHaveFilledOutAllMyDetailsCorrectly(string name, string email, string password)
        {
            _AccountCreationPageObject.EnterName(name);
            _AccountCreationPageObject.EnterEmail(email);
            _AccountCreationPageObject.EnterPassword(password);
            _AccountCreationPageObject.EnterConfirmPassword(password);
        }
        
        [Given(@"I have accepted the Terms of Service")]
        public void GivenIHaveAcceptedTheTermsOfService()
        {
            _AccountCreationPageObject.CheckCheckBox();
        }
                    
        [When(@"I submit")]
        public void WhenISubmit()
        {
            _AccountCreationPageObject.ClickCreateAccount();
        }      
      
        [Then(@"I am redirected to the '(.*)' page")]
        public void ThenIAmRedirectedToThePage(string emailsentText)
        {
            Assert.Equals("An email has been sent", emailsentText);
        }
        
        [Then(@"an account activation email is sent to my email address")]
        public void ThenAnAccountActivationEmailIsSentToMyEmailAddress(string followdirectionText)
        {
            Assert.Equals("Follow the directions in your email to verify your account.", followdirectionText);
        }
    }
}

