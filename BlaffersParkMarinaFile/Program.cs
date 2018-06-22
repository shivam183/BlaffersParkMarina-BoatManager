using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaffersParkMarinaLib;
using System.IO;

namespace BlaffersParkMarinaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const char DELIM = ',';
            const string IFILE_NAME = "Customer.txt";
            const string OFILE_NAME = "Boat.txt";
            
            

            
            const int NUM_CUSTOMER = 3;
            Customer[] myCustomers = new Customer[NUM_CUSTOMER];

            FileStream iFile = editFile(IFILE_NAME, FileMode.Open, FileAccess.Read);
                
            StreamReader reader = checkFileStreamReader(iFile, IFILE_NAME);
            addCustomers(reader, myCustomers, DELIM);

            
            closeFile(iFile, reader);

            
            MotorBoat motorboat1 = createMotorboat("9005", 10, "Yamaha Inc", 2012, 2, FuelType.Diesel);
           

            MotorBoat motorboat2 = createMotorboat("7654", 25, "Bayliner Inc.", 2016, 3, FuelType.Gasoline);
            

            SailBoat sailboat1 = createSailboat("5142", 15, "Miami Inc.", 1999, 6, 3);
            


            assignBoat(myCustomers[0], motorboat1);

            assignBoat(myCustomers[1], motorboat2);

            assignBoat(myCustomers[0], sailboat1);

            division(1);
            Console.WriteLine(myCustomers[0]);

            division(2);
            Console.WriteLine(myCustomers[1]);

           
            FileStream oFile = editFile(OFILE_NAME, FileMode.Create, FileAccess.Write);

            
            StreamWriter writer = checkFileStreamWriter(oFile, OFILE_NAME);

           
            printRecords(writer, myCustomers, DELIM);
            
            
        }

        
        static FileStream editFile(string fileName, FileMode fMode, FileAccess fAccess)
        {
            FileStream file = null;
            string exception;

            try
            {
                file = new FileStream(fileName, fMode, fAccess);
            }
            catch(Exception ex)
            {
                exception = printError(ex);
                exception += string.Format("This ocurred in the FileStream constructor,\nCheck path of {0} file.\n", fileName);
                Console.WriteLine(exception);
            }
            return file;
        }

        
        static StreamReader checkFileStreamReader(FileStream iFile, string fileName)
        {
            StreamReader reader = null;
            string exception;
            try
            {
                reader = new StreamReader(iFile);
            }
            catch (Exception ex)
            {
                exception = printError(ex);
                //exception += string.Format("FileStream with input file {0} was not created.\n", fileName);
                Console.WriteLine(exception);
            }
            return reader;

        }

     
        static StreamWriter checkFileStreamWriter(FileStream oFile, string fileName)
        {
            StreamWriter writer = null;
            string exception;
            try
            {
                writer = new StreamWriter(oFile);
            }
            catch(Exception ex)
            {
                exception = printError(ex);
                exception += string.Format("FileStream with output file {0} was not created.", fileName);
                Console.WriteLine(exception);
            }
            return writer;
        }

        
        static void closeFile(FileStream file, StreamReader reader)
        {
            string exception;
            try
            {
                reader.Close();
                file.Close();
            }
            catch(Exception ex)
            {
                exception = printError(ex);
                exception += "File couldn't be closed because it was not created!\n";
                Console.WriteLine(exception);
            }
        }

        
        static void addCustomers(StreamReader reader, Customer[] myCustomers, char delimiter)
        {
            string record;
            int counter = 0;
            string exception;

            try
            {
                while (!reader.EndOfStream)
                {
                    record = reader.ReadLine();

                    myCustomers[counter] = processRecord(record, delimiter);

                    Console.WriteLine(myCustomers[counter]);

                    counter++;
                }
            }
            catch(Exception ex)
            {
                exception = printError(ex);
                exception += string.Format("This ocurred in the while - loop.\n");
                Console.WriteLine(exception);
            }
        }
        
       
        static Customer processRecord(string record, char delimiter)
        {
            string[] fields = record.Split(delimiter);
            Customer aCustomer = null;
            string exception;

            try
            {
                aCustomer = new Customer(fields[0], fields[1], fields[2]);
                Console.WriteLine("A customer record has been created!");
            }
            catch (Exception ex)
            {
                exception = printError(ex);
                exception += string.Format("A customer record COULDN'T be created!\n");
                Console.WriteLine(exception);
            }
            

            return aCustomer;
        }

      
        static MotorBoat createMotorboat(string regNumber, double length, string manufacturer, int year, int motor, FuelType fuel)
        {
            MotorBoat aMotorboat = null;
            string exception;

            try
            {
                aMotorboat = new MotorBoat(regNumber, length, manufacturer, year, motor, fuel);
            }
            catch(Exception ex)
            {
                exception = printError(ex);
                exception += string.Format("A motorboat instance couldn't be created!\n");
                Console.WriteLine(exception);
            }

            return aMotorboat;
        }

   
        static SailBoat createSailboat(string regNumber, double length, string manufacturer, int year, int numSails, int numMasts)
        {
            SailBoat aSailboat = null;
            string exception;

            try
            {
                aSailboat = new SailBoat(regNumber, length, manufacturer, year, numSails, numMasts);
            }
            catch(Exception ex)
            {
                exception = printError(ex);
                exception += string.Format("A sailboat instace couldn't be created!\n");
                Console.WriteLine(exception);
            }
            return aSailboat;
        }

    
        static void assignBoat(Customer aCustomer, Boat aBoat)
        {
            string exception;
            try
            {
                aCustomer.AddBoat(aBoat);
            }
            catch(Exception ex)
            {
                exception = printError(ex);
                exception += "Customer instance has not been created!\n";
                Console.WriteLine(exception);
            }
        }

       
        static void printRecords(StreamWriter writer, Customer[] myCustomers, char delimiter)
        {
            int x = 0;
            string temp = null;

            foreach (Customer aCustomer in myCustomers)
            {
                try
                {
                    temp += string.Format("{0}{1}", aCustomer.PhoneNumber, delimiter);
                    try
                    {
                        foreach (Boat aBoat in aCustomer.Boats)
                        {
                            temp += string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", aBoat.RegistrationNumber, delimiter,
                                aBoat.Length, delimiter, aBoat.Manufacturer, delimiter, aBoat.Year, delimiter);
                        }
                    }
                    catch (Exception e)
                    {
                        printError(e);
                    }
                    writer.WriteLine(temp);
                }
                catch (Exception ex)
                {
                    printError(ex);
                }
            }
            try
            {
                writer.Close();
            }
            catch (Exception ex)
            {
                printError(ex);
            }
        }

     
        static string printError(Exception ex)
        {
            string temp = string.Format("ERROR: " + ex.Message +"\n");
            return temp;
        }

        static void division(int num)
        {
            if (num > 0)
            {
                Console.WriteLine("*****************************************************************************");
                Console.WriteLine("                              CUSTOMER #{0} DATA", num);
                Console.WriteLine("*****************************************************************************\n");
            }
        }

       
        static void checkEquality(Boat aBoat, Boat anotherBoat)
        {
            string temp;
            bool status = aBoat.Equals(anotherBoat);
            temp = string.Format("Comparing Boats: ");
          
            if (aBoat.Equals(anotherBoat) && anotherBoat.Equals(aBoat))
            {
                temp += string.Format("Are Boats Equal? : {0} >>", status);
                temp += string.Format(" Hashcode: {0} and {1}\n", aBoat.GetHashCode(), anotherBoat.GetHashCode());
            }
            else
                temp += string.Format("Are Boats Equal? : {0}\n", status);
            Console.WriteLine(temp);
        }

       
        static void checkEquality(Slip aSlip, Slip anotherSlip)
        {
            string temp;
            bool status = aSlip.Equals(anotherSlip);
            temp = string.Format("Comparing Slips: ");
            
            if (aSlip.Equals(anotherSlip) && anotherSlip.Equals(aSlip))
            {
                temp += string.Format("Are Slips Equal? : {0} >>", status);
                temp += string.Format(" Hasscode: {0} and {1}\n", aSlip.GetHashCode(), anotherSlip.GetHashCode());
            }
            else
                temp += string.Format("Are Slips Equal? : {0}\n", status);
            Console.WriteLine(temp);
        }
    }
}
