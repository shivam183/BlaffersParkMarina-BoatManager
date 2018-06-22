using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaffersParkMarinaLib
{
    public class Slip
    {
   
        const double MIN_SLIP_LENGTH = 10;
        const double MIN_SLIP_DEPTH = 5;
        const double MIN_SLIP_WIDTH = 2;

        string slipId;
        readonly double width;
        readonly double length;
        readonly double depth;
        Customer leasee;
        Boat boatInSlip;

     
        public string SlipId
        {
            get
            {
                return slipId;
            }

            set
            {
                slipId = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }

        }

        public double Length
        {
            get
            {
                return length;
            }

        }

        public double Depth
        {
            get
            {
                return depth;
            }
        }

        public Customer Leasee
        {
            get
            {
                return leasee;
            }
        }
        public Boat BoatInSlip
        {
            get
            {
                return boatInSlip;
            }
        }

       
        public Slip()
            : this("name not assigned", MIN_SLIP_LENGTH, MIN_SLIP_WIDTH, MIN_SLIP_DEPTH)
        {

        }

      
        public Slip(string slipId, double length, double width, double depth)
        {
            SlipId = slipId;
            this.length = length;
            this.width = width;
            this.depth = depth;
            leasee = null;
            boatInSlip = null;
        }

         
        internal bool AssignBoat(Boat aBoat)
        {

            if (boatInSlip == aBoat)
            {
                return true; 
            }
            else if (BoatInSlip == null) 
            {
                if (aBoat.Owner == Leasee && Leasee != null) 
                {

                    boatInSlip = aBoat;
                    leasee = aBoat.Owner;
                    return true;
                }
                else 
                {
                    if (aBoat.Owner == null)
                        Console.WriteLine("Not owned boat cannot be assigned to a slip");
                    else
                        Console.WriteLine("{0} did not lease the slip", aBoat.Owner.Name);
                    return false;
                }

            }
            else
            {

                Console.WriteLine("Slip is not free");
                return false;
            }
        }

       
        internal void RemoveBoat(Boat aBoat)
        {
            if (BoatInSlip != null)
                if (BoatInSlip.RegistrationNumber == aBoat.RegistrationNumber)
                {
                    boatInSlip = null;
                }
                else
                {
                    Console.WriteLine(" {0} is not assigned to {1}", BoatInSlip, this);
                }
            else
                Console.WriteLine("No boat assigned to slip");
        }

       
        private bool boatFits(Boat aBoat)
        {
            return Length < aBoat.Length;
        }

        
        public override string ToString()
        {
            string temp = string.Format("Slip: {0}, LxWxD:{1}x{2}x{3}", SlipId, Length, Width, Depth);
            if (leasee != null)
                temp += string.Format(", Leased by: {0}; ", leasee.Name);
            if (BoatInSlip != null)
                temp += string.Format("Boat tied: {0}", boatInSlip.RegistrationNumber);
            return temp;
        }
        
        public bool LeaseSlip(Customer aCustomer)
        {
            if (Leasee != aCustomer)
            {
                if (Leasee != null)
                {
                    Console.WriteLine("Slip is already leased to a different customer");
                    return false;
                }
                else
                {
                    leasee = aCustomer;
                    aCustomer.AddSlip(this);
                }
            }
            return true;
        }
        
        public override bool Equals(Object obj)
        {
            bool isEqual = true;

           
            if (obj == null || this.GetType() != obj.GetType())
            {
                isEqual = false;
            }
            else
            {
               
                Slip temp = (Slip)obj;
                if (SlipId == temp.SlipId)
                    isEqual = true;
                else
                    isEqual = false;
            }

            return isEqual;
        }

    
        public override int GetHashCode()
        {
            return Convert.ToInt32(SlipId);
        }

    }
}
