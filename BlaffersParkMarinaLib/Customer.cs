using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaffersParkMarinaLib
{
    public class Customer
    {
        //Fields >>
        const int MAX_BOATS = 3;

        string name;
        string address;
        string phoneNumber;
        Boat[] boats;
        Slip[] leasedSlips;

       
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                if (isPhoneNumberValid(value))
                    phoneNumber = value;
                else
                    phoneNumber = "";
            }
        }

        public Boat[] Boats
        {
            get
            {
                return boats;
            }
        }

        public Slip[] LeasedSlips
        {
            get
            {
                return leasedSlips;
            }
        }

       
        private static bool isPhoneNumberValid(string phoneNumber)
        {
            bool telNumberValid = true;
            if (phoneNumber.Length == 10)
            {
                char[] temp = phoneNumber.ToCharArray();
                for (int i = 0; i < 10; i++)
                {
                    if (temp[i] < '0' || temp[i] > '9')
                    {
                        telNumberValid = false;
                        break;
                    }

                }
            }
            else
            {
                telNumberValid = false;
            }
            return telNumberValid;
        }

   
        public override string ToString()
        {
            string temp = "";
            temp += string.Format("Customer: {0}, Address: {1}, Phone: {2}\n", Name, Address, PhoneNumber);
            temp += "\t Boats owning:\n";
            
            foreach (Boat item in Boats)
            {
                if (item != null)
                    temp += "\t   " + item + "\n";
            }
            temp += "\tLeasing slips:\n";

            foreach (Slip item in LeasedSlips)
            {
                if (item != null)
                    temp += "\t   " + item + "\n";
            }

            return temp;
        }

        
        public void AddBoat(Boat aBoat)
        {
            bool success = false;
            if (!isBoatAdded(aBoat))
            {
                for (int i = 0; i < MAX_BOATS; i++)
                {
                    if (Boats[i] == null)
                    {
                        Boats[i] = aBoat;
                        aBoat.Owner = this;
                        success = true;
                        break;
                    }
                }
            }

            if (!success)
                Console.WriteLine("Max number of boats already assigned");
        }

        internal void AddSlip(Slip aSlip)
        {

            for (int i = 0; i < MAX_BOATS; i++)
            {
                if (LeasedSlips[i] == aSlip)
                {
                    break;
                }
                else if (LeasedSlips[i] == null)
                {
                    LeasedSlips[i] = aSlip;
                    break;
                }

            }
        }


       
        private bool isBoatAdded(Boat aBoat)
        {
            bool found = false;
            foreach (Boat item in Boats)
            {
                if (item != null)
                    if (item.RegistrationNumber == aBoat.RegistrationNumber) 
                    {
                        found = true;
                        break;
                    }

            }
            return found;
        }

       
        public Customer()
        {
            boats = new Boat[MAX_BOATS];
            leasedSlips = new Slip[MAX_BOATS];
        }

       
        public Customer(string name, string address, string phoneNumber)
            : this()
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
