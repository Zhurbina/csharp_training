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
                ContactData newData = new ContactData("Max1", "Just1");

                app.Contacts.ModifyContact(1, newData);
         }
    }
}
