using DealCloud_BM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealCloud_BM.Service
{
    public class CalculateAverageServices:DealService
    {
        
        public override string Calculate(string symbol, int numberOfDays)
        {
            Dictionary<string, TimeSeriesDaily> list = base.CalculateFirmPrice(symbol, numberOfDays);

            List<decimal> listVolume = new List<decimal>();
            DateTime dtStop = DateTime.Now.AddDays(numberOfDays * -1);

            foreach (KeyValuePair<string, TimeSeriesDaily> m in list)
            {
                //checked date
                if (DateTime.TryParse(m.Key, out DateTime dtIs))
                {
                    //gt or et would add
                    if (dtIs.CompareTo(dtStop) >= 0)
                        listVolume.Add(decimal.Parse(m.Value.Volume));
                }
            }

            if (listVolume.Count > 0)
            {
                decimal result = this.GetAverage(listVolume);
                return result.ToString();
            }

            return null;
        }
    }


    public class CalculateHighestClosingPrice : DealService
    {
        public override string Calculate(string symbol, int numberOfDays)
        {
            Dictionary<string, TimeSeriesDaily> list = base.CalculateFirmPrice(symbol, numberOfDays);
            DateTime dtEnd = DateTime.Now.AddDays(numberOfDays * -1);

            if (list == null || list.Count <= 0)
                return null;

            string average = ProcessHighestClosingPrice(list, dtEnd);

            return average;
        }


        private string ProcessHighestClosingPrice(Dictionary<string, TimeSeriesDaily> list, DateTime dtEnd)
        {
            List<decimal> listVolume = new List<decimal>();

            foreach (KeyValuePair<string, TimeSeriesDaily> m in list)
            {
                //checked date
                if (DateTime.TryParse(m.Key, out DateTime dtIs))
                {
                    //gt or et would add
                    if (dtIs.CompareTo(dtEnd) >= 0)
                        listVolume.Add(decimal.Parse(m.Value.Volume));
                }
            }


            if (listVolume.Count > 0)
            {
                decimal result = this.GetMaximum(listVolume);
                return result.ToString();
            }

            return null;
        }
    }


    public class CalculateGreatestPriceDifference : DealService
    {
        public override string Calculate(string symbol, int numberOfDays)
        {
            Dictionary<string, TimeSeriesDaily> list = base.CalculateFirmPrice(symbol);

            if (list == null || list.Count <= 0)
                return null;

            string average = ProcessOpenAndClosePrice(list, numberOfDays);

            return average;
        }

        private string ProcessOpenAndClosePrice(Dictionary<string, TimeSeriesDaily> list, int numberOfDays)
        {
            List<decimal> listVolume = new List<decimal>();
            DateTime dtStop = DateTime.Now.AddDays(numberOfDays * -1);
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, TimeSeriesDaily> m in list)
            {
                //checked date
                if (DateTime.TryParse(m.Key, out DateTime dtIs))
                {
                    //gt or et would add
                    if (dtIs.CompareTo(dtStop) >= 0)
                    {
                        if (decimal.TryParse(m.Value.High, out decimal high) && decimal.TryParse(m.Value.Low, out decimal low))
                        {
                            decimal result = Decimal.Subtract(high, low);
                            sb.AppendFormat($"This Date: {m.Key} -The difference from high and low is: {result}");
                        }
                    }
                }
            }


            return sb.ToString();

        }
    }

    public class CalculateLargestOverallReturn : DealService
    {

        //•	Given a list of stock symbols, find the symbol with the largest return over the past month
        public override string Calculate(string symbol, int numberOfDays)
        {
            Dictionary<string, decimal> topValues = new Dictionary<string, decimal>();

            this.DataLayerInstance.ListOfSymbols.ForEach(dl =>
            {
                Dictionary<string, TimeSeriesDaily> list = base.CalculateFirmPrice(dl);

                if (list == null || list.Count <= 0) { }
                else
                {
                    decimal open = 0M;

                    int iCnt = 0;
                    foreach (KeyValuePair<string, TimeSeriesDaily> m in list)
                    {
                        decimal first;
                        decimal last; 
                        

                        if (iCnt == 0 && decimal.TryParse(m.Value.Open, out first)) 
                        {
                            open = first;
                        }

                        if (iCnt >= list.Count - 1 && decimal.TryParse(m.Value.Close, out last))
                        {
                            topValues.Add(dl, this.ProcessHighestClosingPrice(open, last));                            
                        }
                                 
                        iCnt++;
                    }
                        
                }
            });


            return this.HighestValye(topValues);

        }


        private decimal ProcessHighestClosingPrice(decimal first, decimal last)
        {
            decimal result = this.CalculateROI(first, last);

            return result;
        }


        private string HighestValye(Dictionary<string, decimal> topValues)
        {
            var maxValue = topValues.Values.Max();
            var keyOfMaxValue = topValues.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return $"Lagest Return Company is: {keyOfMaxValue}";
        }


    }

}
