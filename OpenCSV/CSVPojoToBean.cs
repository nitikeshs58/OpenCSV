using System;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
using System.IO;

namespace OpenCSV
{
    public class CSVPojo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        // Default constructor
        public CSVPojo()
        {
        }

        // Parameterised Constructor
        public CSVPojo(int ID, string Name, string Email, long PhoneNo, string Address, string Country)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNo = PhoneNo;
            this.Address = Address;
            this.Country = Country;
        }
    }

    public class CSVPojoToBean
    {
        public static void CSVPojoMethod()
        {
            try
            {
                using (CsvReader csv = new CsvReader(new StreamReader(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\OpenCSV\OpenCSV\users.csv"), true))
                {
                    // the number of fields 
                    int fields_count = csv.FieldCount;
                    // reading the header into th string array
                    string[] headers = csv.GetFieldHeaders();
                    List<CSVPojo> records = new List<CSVPojo>();
                    // add all records into List
                    while (csv.ReadNextRecord())
                    {
                        CSVPojo obj_csvPojo = new CSVPojo(Int32.Parse(csv[0]), csv[1], csv[2], long.Parse(csv[3]), csv[4], csv[5]);
                        records.Add(obj_csvPojo);
                    }

                    //Print the record
                    foreach (CSVPojo print_record in records)
                    {
                        //$ :- double" " space will be actual in O/P.
                        Console.WriteLine($"ID : {print_record.ID}");
                        Console.WriteLine($"Name : {print_record.Name}");
                        Console.WriteLine($"Email : {print_record.Email}");
                        Console.WriteLine($"PhoneNo : {print_record.PhoneNo}");
                        Console.WriteLine($"Address : {print_record.Address}");
                        Console.WriteLine($"Email: {print_record.Country}");
                    }
                }
            }
            catch (FileNotFoundException file_not_found)
            {
                throw new FileNotFoundException(file_not_found.FileName);
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}