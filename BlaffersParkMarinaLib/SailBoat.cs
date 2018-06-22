using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaffersParkMarinaLib
{
    public class SailBoat : Boat
    {
    
        const int MIN_NUM_SAILS = 1;
        const int MIN_NUM_MASTS = 1;
        const string TYPE = "Sailboat";

        private int numOfSails;
        private int numOfMasts;


     
        public int NumOfSails
        {
            get { return numOfSails; }
            set
            {
                if (value > 0)
                    numOfSails = value;
            }
        }

        public int NumOfMasts
        {
            get { return numOfMasts; }
            set
            {
                if (value > 0)
                    numOfMasts = value;
            }
        }

        public string Type
        {
            get { return TYPE; }
        }

        public SailBoat(string regNumber, double length, string manufacturer,
            int year, int numOfSails, int numOfMasts)
            : base(regNumber, length, manufacturer, year)
        {
            NumOfSails = numOfSails;
            NumOfMasts = numOfMasts;
        }

        public SailBoat()
            : base()
        {
            numOfSails = MIN_NUM_SAILS;
            NumOfMasts = MIN_NUM_MASTS;
        }

      
        public override string ToString()
        {
            string temp = "SailBoat" + base.ToString();
            temp += string.Format("\n \t   Num of Sails: {0}, Num of Masts: {1}\n", NumOfSails, NumOfMasts);
            return temp;
        }
    }
}
