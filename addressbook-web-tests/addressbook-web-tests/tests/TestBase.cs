﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            string letter;
            var chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789 ";
            int pos;

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < max; i++)
            {
                pos = rnd.Next(chars.Length);
                letter = chars.Substring(pos, 1);
                builder.Append(Convert.ToChar(letter));
            }

            return builder.ToString();
        }
    }
}
