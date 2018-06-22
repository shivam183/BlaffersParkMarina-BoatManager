using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaffersParkMarinaLib
{
    public class MotorBoat : Boat
    {
    
        const int MIN_NUM_ENGINES = 1;
        const string TYPE = "MotorBoat";

        private int numOfEngines;
        private FuelType fuelType;

  
        public int NumOfEngines
        {
            get { return numOfEngines; }
            set
            {
                if (value != 0)
                    numOfEngines = value;
            }
        }

        public FuelType FuelType
        {
            get { return fuelType; }
            set
            {
                fuelType = value;
            }
        }

        public string Type
        {
            get { return TYPE; }
        }
      
        public MotorBoat(string regNumber, double length, string manufacturer,
            int year, int numOfEngines, FuelType fuelType)
            : base(regNumber, length, manufacturer, year)
        {
            NumOfEngines = numOfEngines;
            FuelType = fuelType;
        }
        
        public MotorBoat()
            : base()
        {
            NumOfEngines = MIN_NUM_ENGINES;
            FuelType = FuelType.Unknown;
        }


        
        public override string ToString()
        {
            string temp = "MotorBoat" + base.ToString();
            temp += string.Format("\n \t   Num of Engines: {0}, Fuel Type: {1}\n", NumOfEngines, FuelType);
            return temp;
        }

    }

    public enum FuelType
    {
        Gasoline,
        Diesel,
        Unknown
    };
}
