using System;
using System.IO;
using CsvHelper;

namespace OpenCSV
{
    class CSVToDataFile
    {
        public static void WriteDataInFile()
        {
            var data = new[]
            {
                new CSVPojo {ID=9,Name="Shivani",Email="shivani12@gmail.com",PhoneNo=+91-87888964578,Address="Nanded",Country="India"},
                new CSVPojo { ID = 6,Name="Raju", Email ="raju21@gmail.com", PhoneNo = +91-99988964578, Address = "Pune", Country = "India" }
            };

            try
            {
                using (var csvWriter = new CsvWriter(new StreamWriter(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\OpenCSV\OpenCSV\users.csv"),true))
                {
                    //delimeter seprating the input
                    csvWriter.Configuration.Delimiter = ",";
                    csvWriter.Configuration.HasHeaderRecord = true;
                    //automap tansforming the input, one type to another
                    //adjusting differnt datatypes
                    csvWriter.Configuration.AutoMap<CSVPojo>();
                    csvWriter.WriteHeader<CSVPojo>();
                    csvWriter.WriteRecords(" \n ");
                    csvWriter.WriteRecords(data);
                    //extra will vanish
                    csvWriter.Flush();
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

