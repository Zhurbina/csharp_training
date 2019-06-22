using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    Address = GenerateRandomString(15),
                    HomePhone = Convert.ToString(rnd.Next(00000, 29999)),
                    MobilePhone = Convert.ToString(rnd.Next(30000, 59999)),
                    WorkPhone = Convert.ToString(rnd.Next(60000, 79999)),
                    Fax = Convert.ToString(rnd.Next(80000, 99999)),
                    Email1 = GenerateRandomString(5) + "@" + GenerateRandomString(5),
                    Email2 = GenerateRandomString(5) + "@" + GenerateRandomString(5),
                    Email3 = GenerateRandomString(5) + "@" + GenerateRandomString(5)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
