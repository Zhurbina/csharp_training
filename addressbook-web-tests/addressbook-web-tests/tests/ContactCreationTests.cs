using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;


        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("ALENA", "LIU");
            contact.Company = "OCS";
            app.Contacts.CreateContact(contact);
            app.LogOut.Logout();
        }
    }
}
