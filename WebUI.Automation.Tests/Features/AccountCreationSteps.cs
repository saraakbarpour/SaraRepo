using System;
using TechTalk.SpecFlow;
using WebUI.Automation.Pages.AccountCreation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebUI.Automation.Pages;

namespace WebUI.Automation.Tests.Features
{
    [Binding]
    public class AccountCreationSteps 
    {
        private new AccountCreationPage _AccountCreationPageObject;

        //private ChromeDriver chromeDriver;

        //public static IWebDriver driver;
        ////ChromeDriver driver = new ChromeDriver();
        //public AccountCreationSteps() => chromeDriver = new ChromeDriver();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p0"></param>

        [Given(@"I am on the '(.*)' page")]
        public       GivenIAmOnThePage(string p0)
        {
            //chromeDriver.Navigate().GoToUrl("https://wifi-test.zenhq.com/Account/Create");
            //// _AccountCreationPageObject.NavigateToURL();
            // driver.Navigate().GoToUrl("https://wifi-test.zenhq.com/Account/Create");
            return _AccountCreationPageObject.NavigateToURL();
            Console.WriteLine("I am on Account Creation Page" + p0);
          
            // _AccountCreationPageObject.NavigateToURL();

        }

    

        [Given(@"I have filled out all my details (.*) (.*) (.*)")]
        public void GivenIHaveFilledOutAllMyDetails(string name, string email, string password)
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
        
        [Then(@"an account activation email is sent to my email address '(.*)' ")]
        public void ThenAnAccountActivationEmailIsSentToMyEmailAddress(string followdirectionText)
        {
            Assert.Equals("Follow the directions in your email to verify your account.", followdirectionText);
        }
    }
}

