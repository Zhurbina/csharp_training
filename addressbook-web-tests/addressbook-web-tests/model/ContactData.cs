using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allEmails, allPhones;

        public ContactData(string lastName, string firstName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

           if ((LastName == other.LastName) && (FirstName == other.FirstName))
            {
                return true;
            }
            return false;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            if (LastName.CompareTo(other.LastName) > 0)
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) < 0)
            {
                return -1;
            }
            return 0;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "FirstName=" + FirstName + "LastName=" + LastName;
        }

        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Homephone { get; set; }
        public string Mobilephone { get; set; }
        public string Workphone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Address { get; internal set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;

            }
        }
        public string MobilePhone { get; private set; }
        public string HomePhone { get; private set; }
        public string WorkPhone { get; private set; }
    }
}
