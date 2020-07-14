using System;
using System.Text;
using DealCloud_BM.Constants;
using DealCloud_BM.Data;
using DealCloud_BM.Service;

namespace DealCloud_BM
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"DealCloud: Start Program: {DateTime.Now}");

                RunProgram();

                Console.WriteLine($"DealCloud: End Program: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DealCloud: Error: {DateTime.Now} - Exception: {ex.Message}");

            }
        }

        static void RunProgram()
        {
           
            DealService ds1 = new CalculateAverageServices();
            string cas1 = ds1.Calculate(TradeSymbols.Symbol_MicroSoft, 7);

            DealService ds2 = new CalculateHighestClosingPrice();
            string cas2 = ds2.Calculate(TradeSymbols.Symbol_Apple, 30);

            DealService ds3 = new CalculateAverageServices();
            string cas3 = ds3.Calculate(TradeSymbols.Symbol_BankOfAmerica, 30);

            DealService ds4 = new CalculateLargestOverallReturn();
            string cas4 = ds4.Calculate(null, 30);


            Console.WriteLine("Here are your results:");
            Console.WriteLine();
            Console.WriteLine(string.Format("1. Find the average volume of MSFT in the past 7 days: {0}", cas1));
            Console.WriteLine(string.Format("2. Find the highest closing price of AAPL in the past 6 months: {0}", cas2));
            Console.WriteLine(string.Format("3. Find the difference between open and close price for BA for every day in the last month: {0}", cas3));
            Console.WriteLine(string.Format("4. Given a list of stock symbols, find the symbol with the largest return over the past month: {0}", cas4));
      
            Console.ReadKey();

        }
    }
}
