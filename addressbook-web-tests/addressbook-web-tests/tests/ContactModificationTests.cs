using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
         [Test]
         public void ContactModificationTest()
         {
            app.Contacts.ContactExists();

            ContactData newData = new ContactData("Just1", "Max");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.ModifyContact(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Name = newData.Name;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
