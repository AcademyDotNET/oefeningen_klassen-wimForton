using System;

namespace CSVHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            System.Net.WebClient wc = new System.Net.WebClient();
            string csv = wc.DownloadString("https://bit.ly/2tE4CB0");

            string[] splitted = csv.Split('\n');

            for (int i = 1; i < splitted.Length - 1; i++)
            {
                string[] lijnsplit = splitted[i].Split(',');
                Console.WriteLine("Data 1=" + lijnsplit[0]);
                Console.WriteLine("Data 2=" + lijnsplit[1]);
            }*/
            //CsvReader.readCsvBestPracticeStreamReader();
            CsvReader.readCsvToDataTable();
            //CsvWriter.writeCsvNoStreamWriter();
            //CsvWriter.writeCsvStreamWriter();
        }
    }
}