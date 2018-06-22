using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaffersParkMarinaLib
{
    public class Boat
    {

        protected string registrationNumber;    
        protected readonly double length;       
        protected readonly string manufacturer; 
        protected readonly int year;            
        Customer owner;

        //Properties >>
        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
            set
            {
                registrationNumber = value;
            }
        }

        public double Length
        {
            get
            {
                return length;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
        }

        public Customer Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        
        protected Boat()
        {
            RegistrationNumber = "Reg number not provided";
            Owner = null;
        }

        
        protected Boat(string regNumber, double length, string manufacturer, int year)
            : this()
        {
            RegistrationNumber = regNumber;
            this.length = length;
            this.manufacturer = manufacturer;
            this.year = year;
        }

       
        public override string ToString() 
        {
            string temp = string.Format("s: {0}, Length: {1}, Manufacturer: {2}, Year: {3}", RegistrationNumber, Length, Manufacturer, Year);
            if (Owner != null)
                temp += string.Format(",\n           Owned by: {0}", Owner.Name);
            return temp;
        }


     
        public override bool Equals(Object obj)
        {
            bool isEqual = true;

            
            if (obj == null || this.GetType() != obj.GetType())
                isEqual = false;
            else
            {
                
                Boat temp = (Boat)obj;
                if (RegistrationNumber == temp.RegistrationNumber)
                    isEqual = true;
                else
                    isEqual = false;
            }

            return isEqual;
        }
        
        public override int GetHashCode()
        {
            return Convert.ToInt32(RegistrationNumber);
        }

     
        public bool AssigneBoatToSlip(Slip aSlip)
        {
            return aSlip.AssignBoat(this);
        }

        
        public void RemoveBoatFromSlip(Slip aSlip)
        {
            aSlip.RemoveBoat(this);

        }
    }
}
