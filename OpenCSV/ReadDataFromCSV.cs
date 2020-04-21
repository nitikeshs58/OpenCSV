using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenCSV
{

    public class ReadDataFromCSV
    {

        public static void Main(string[] args)
        {
            ReadData();
            CSVToDataFile.WriteDataInFile();
            CSVPojoToBean.CSVPojoMethod();
        }

        public static void ReadData()
        {
            try
            {
                //    Summary:
                //    Initializes a new instance of the CsvReader class.
                //@ :- backslash is special letter so @symbol literal there is no escape characters
                using (CsvReader csv = new CsvReader(new StreamReader(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\OpenCSV\OpenCSV\users.csv"), true))
                {   
                    //The number of fields 
                    int field_Count = csv.FieldCount;
                    //reading the header into the string array
                    string[] headers = csv.GetFieldHeaders();
                    List<string[]> records = new List<string[]>();
                    //all record into the list
                    while (csv.ReadNextRecord())
                    {
                        //create new object to store the data
                        string[] temp_record = new string[field_Count];
                        // copy data into string
                        csv.CopyCurrentRecordTo(temp_record);
                        // add the data string into List: records
                        records.Add(temp_record);
                    }
                    //print the record
                    foreach (string[] print_record in records)
                    {
                        for (int j = 0; j<field_Count; j++)
                            Console.Write($"  {headers[j]} = {print_record[j]}  ");
                    }
                }
            }
            catch (FileNotFoundException file_not_found)
            {
                throw new FileNotFoundException(file_not_found.FileName);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}