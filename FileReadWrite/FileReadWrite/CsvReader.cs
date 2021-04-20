using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVHandling
{
    public class CsvReader
    {
        const string delimeter = "\",\"";  //","
        public static void readCsvBasicStreamReader()
        {
            StreamReader streamReader = new StreamReader($@"https://gist.githubusercontent.com/armgilles/194bcff35001e7eb53a2a8b441e8b2c6/raw/92200bc0a673d5ce2110aaad4544ed6c4010f687/pokemon.csv");
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] values = line.Split(delimeter);

                for (int i = 0; i < values.Length; i++) {
                    Console.Write(values[i]);
                }
            }
            streamReader.Close();
            streamReader.Dispose();
        }
        public static void readCsvBestPracticeStreamReader()
        {
            using(StreamReader streamReader = new StreamReader(@"H:\cursus_informatica\Oefening_classes\pokemon.csv"))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(',');

                    //todo
                    for (int i = 0; i < values.Length; i++)
                    {
                        Console.Write(values[i]);
                        Console.Write("\t");
                    }
                    Console.WriteLine("");
                }
            }
        }
        public static void readCsvWithoutStreamReader()
        {
            string[] lines = System.IO.File.ReadAllLines(@"H:\cursus_informatica\Oefening_classes\pokemon.csv");
            foreach(string line in lines)
            {
                string[] values = line.Split(delimeter);

                //todo
            }
        }
        public static void readCsvNoQuotes()
        {
            char[] quotes = { '\"', ' ' };
            using(StreamReader streamReader = new StreamReader(@"H:\cursus_informatica\Oefening_classes\pokemon.csv"))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(delimeter).Select(s => s.Trim(quotes).Replace("\\\"","\"")).ToArray();

                    //todo
                }
            }
        }
        public static void readCsvToDataTable()
        {
            DataTable dataTable = new DataTable();
            char[] quotes = { '\"', ' ' };
            using(StreamReader streamReader = new StreamReader(@"H:\cursus_informatica\Oefening_classes\pokemon.csv"))
            {
                string[] headers = streamReader.ReadLine()
                    .Split(delimeter)
                    .Select(s => s.Trim(quotes)
                    .Replace("\\\"", "\"")).ToArray();

                foreach(string header in headers)
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
                    for(int i = 0; i < values.Length; i++)
                    {
                        row[i] = values[i];
                    }
                    dataTable.Rows.Add(row);
                }
            }
        }

    }
}
