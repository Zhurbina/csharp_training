﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private string index;

        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactHelper ModifyContact(int v, ContactData newData)
        {

            manager.Navigator.GoToHomePage();
            SelectContact(v);
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();

            return this;
        }


        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + v + "]")).Click();
            return this;
        }

        public ContactHelper Remove(int v)
        {

            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveContact();

            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();

            return this;
        }


        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToContactPage();

            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }


    }
}
