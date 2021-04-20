using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            PrijzenMetForeach();
        }

        private static void PrijzenMetForeach()
        {
            double totaal = 0;
            double[] prijzen = new double[5];
            for (int i = 0; i < prijzen.Length; i++)
            {
                Console.WriteLine("geef een prijs");
                prijzen[i] = Convert.ToDouble(Console.ReadLine());
            }
            foreach (var item in prijzen)
            {
                if(item <= 5) { 
                    Console.WriteLine(item); 
                }
                totaal += item;
            }
            if(prijzen.Length != 0)
            {
                Console.WriteLine($"gemiddelde =  {totaal / prijzen.Length}");
            }
        }
    }
}
