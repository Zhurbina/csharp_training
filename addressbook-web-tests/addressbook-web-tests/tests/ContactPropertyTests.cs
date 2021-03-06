﻿using System;
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
    public class ContactPropertyTests : ContactTestBase
    {
        [Test]
        public void CompareContactInfoFromFormAndDetailsTest()
        {
            ContactData fromDetails = app.Contacts.GetContactInfoFromDetails(0);
            ContactData fromForm = app.Contacts.GetContactInformationFormEditForm(0);
            // Assert.AreEqual(fromDetails, fromForm);
            Assert.AreEqual(fromDetails.DetailsInfo, fromForm.DetailsInfo);
        }
    }
}