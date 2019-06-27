using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allEmails, allPhones, detailsInfo;

        public ContactData()
        {
        }

        public ContactData(string lastName, string firstName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData(string detailsinfo)
        {
            DetailsInfo = detailsinfo;
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
            return "Lastname=" + LastName + "\r"
                + "Firstname=" + FirstName + "\r"
                + "Address=" + Address + "\r"
                + "Homephone=" + HomePhone + "\r"
                + "Mobilephone=" + MobilePhone + "\r"
                + "Workphone=" + WorkPhone + "\r"
                + "Email1=" + Email1 + "\r"
                + "Email2=" + Email2 + "\r"
                + "Email3=" + Email3;
        }

        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        [XmlIgnore, JsonIgnore]
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
                    allPhones = "";
                    if (HomePhone != "")
                    {
                        AllPhones += HomePhone + "\r\n";
                    }
                    if (MobilePhone != "")
                    {
                        AllPhones += MobilePhone + "\r\n";
                    }
                    if (WorkPhone != "")
                    {
                        AllPhones += WorkPhone + "\r\n";
                    }
                    return (Clean(AllPhones)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        [XmlIgnore, JsonIgnore]
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
                    allEmails = "";
                    if (Email1 != "")
                    {
                        AllEmails += Email1 + "\r\n";
                    }
                    if (Email2 != "")
                    {
                        AllEmails += Email2 + "\r\n";
                    }
                    if (Email3 != "")
                    {
                        AllEmails += Email3 + "\r\n";
                    }
                    return (AllEmails).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        [XmlIgnore, JsonIgnore]
        public string DetailsInfo
        {
            get
            {
                if (detailsInfo != null)
                {
                    return detailsInfo;
                }
                else
                {
                    detailsInfo = "";

                    if (FirstName != "")
                    {
                        detailsInfo += FirstName + " ";
                    }

                    if (LastName != "")
                    {
                        detailsInfo += LastName + "\r\n";
                    }

                    if (Address != "")
                    {
                        detailsInfo += Address + "\r\n\r\n";
                    }

                    if (HomePhone != "")
                    {
                        detailsInfo += "H: " + Clean(HomePhone) + "\r\n";
                    }

                    if (MobilePhone != "")
                    {
                        detailsInfo += "M: " + Clean(MobilePhone) + "\r\n";
                    }

                    if (WorkPhone != "")
                    {
                        detailsInfo += "W: " + Clean(WorkPhone) + "\r\n";
                    }

                    if (Fax != "")
                    {
                        detailsInfo += "F: " + Clean(Fax) + "\r\n\r\n";
                    }

                    if (Email1 != "")
                    {
                        detailsInfo += Email1 + "\r\n";
                    }

                    if (Email2 != "")
                    {
                        detailsInfo += Email2 + "\r\n";
                    }

                    if (Email3 != "")
                    {
                        detailsInfo += Email3 + "\r\n";
                    }

                    return detailsInfo.Trim();
                }
            }

            set
            {
                detailsInfo = value;
            }
        }

        private string Clean(string phone)
        {
            if (phone == "" || phone == null)
            {
                return "";
            }
            else
            {
                return Regex.Replace(phone, "[ -()]", "");
            }
        }
    }
}
