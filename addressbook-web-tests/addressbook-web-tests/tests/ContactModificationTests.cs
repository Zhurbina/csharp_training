using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
         [Test]
         public void ContactModificationTest()
         {
            ContactData newData = new ContactData("Just1", "Max");
            app.Navigator.GoToHomePage();
            app.Contacts.ContactExists();

            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.ModifyContact(0, newData);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
