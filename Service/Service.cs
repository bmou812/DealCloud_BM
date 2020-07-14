using DealCloud_BM.Data;
using DealCloud_BM.Interfaces;
using DealCloud_BM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealCloud_BM.Service
{
    public abstract class Service
    {

        public string Url { get; set; }
        internal DataLayer DataLayerInstance { get; set; }


        public Service()
        {
            if (DataLayerInstance == null)
                DataLayerInstance = new DataLayer();
        }


        public virtual string Calculate(string symbol, int numberOfDays)
        {
            return null;
        }


        private Dictionary<string, TimeSeriesDaily> ProcessServiceData(string symbol, int output = 100)
        {
            this.Url = Service.GetTimeSeriesDailyURL(symbol, output);
            Dictionary<string, TimeSeriesDaily> list = this.GetDataList(this.Url);

            return list;
        }

        private static string GetTimeSeriesDailyURL(string symbol, int output = 100)
        {
            return $"{Constants.APIHelpers.TimeSeriesDaily}{Constants.APIHelpers.Symbol}{symbol}" +
                            $"{Constants.APIHelpers.OutPutSize}{output}" +
                            $"{Constants.APIHelpers.Key}{Constants.APIHelpers.APIKey}";
        }

        private Dictionary<string, TimeSeriesDaily> GetDataList(string url)
        {
            Dictionary<string, TimeSeriesDaily> list = this.DataLayerInstance.GetAPIDataList(url);

            if (list == null || list.Count <= 0)
                return null;

            return list;
        }


        public virtual Dictionary<string, TimeSeriesDaily> CalculateFirmPrice(string symbol, int numberOfDays = 30)
        {
            Dictionary<string, TimeSeriesDaily> list = this.ProcessServiceData(symbol);

            if (list == null || list.Count <= 0)
                return null;

            return list;
        }
    }
}
