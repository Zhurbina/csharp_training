using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        public string Name;
        private string company = "";

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
            return "FirstName=" + FirstName + " LastName=" + LastName;
        }

        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public string Company { get; set; }

    }
}
