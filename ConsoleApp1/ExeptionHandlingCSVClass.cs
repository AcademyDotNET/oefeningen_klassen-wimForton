using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExeptionHandlingCSV
{

    public class CsvReader
    {
        const string delimeter = "\",\"";  //","
        public static void readCsvBasicStreamReader()
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader($@"H:\cursus_informatica\Oefening_classes\pokemon.csvnn");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            if (streamReader != null)
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(delimeter);

                    Console.WriteLine(line);
                }
                streamReader.Close();
                streamReader.Dispose();
            }
        }
        public static void readCsvBestPracticeStreamReader()
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"H:\cursus_informatica\Oefening_classes\pokemon.csvnnn");
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("ErrorErrorErrorErrorErrorErrorErrorErrorErrorError");
                Console.WriteLine(e);
            }
            using (streamReader)
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(delimeter);

                    //todo
                }
            }
        }
        public static void readCsvWithoutStreamReader()
        {
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(@"H:\cursus_informatica\Oefening_classes\pokemon.csv");
                //foreach (string line in lines)
                //{
                //    string[] values = line.Split(delimeter);

                //    //todo
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine("ErrorErrorErrorErrorErrorErrorErrorErrorErrorError");
                Console.WriteLine(e);
                //throw;
            }
            if (lines != null) {
                foreach (string line in lines)
                {
                    string[] values = line.Split(delimeter);
                    Console.WriteLine(line);
                    //todo
                }
            }
        }
        public static void readCsvNoQuotes()
        {
            char[] quotes = { '\"', ' ' };
            using (StreamReader streamReader = new StreamReader(@""))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(delimeter).Select(s => s.Trim(quotes).Replace("\\\"", "\"")).ToArray();
                }
            }
        }
        public static void readCsvToDataTable()
        {
            DataTable dataTable = new DataTable();
            char[] quotes = { '\"', ' ' };
            using (StreamReader streamReader = new StreamReader(@""))
            {
                string[] headers = streamReader.ReadLine()
                    .Split(delimeter)
                    .Select(s => s.Trim(quotes)
                    .Replace("\\\"", "\"")).ToArray();

                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line
                        .Split(delimeter)
                        .Select(s => s.Trim(quotes).Replace("\\\"", "\""))
                        .ToArray();

                    DataRow row = dataTable.NewRow();
                    for (int i = 0; i < values.Length; i++)
                    {
                        row[i] = values[i];
                    }
                    dataTable.Rows.Add(row);
                }
            }
        }

    }

}
