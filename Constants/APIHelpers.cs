using System;
using System.Collections.Generic;
using System.Text;

namespace DealCloud_BM.Constants
{
    public class APIHelpers
    {

        public const string APIKey = "HZT9CB39AH1J24PO";

        /// <summary>
        /// TIME_SERIES_MONTHLY_ADJUSTED
        ///   This API returns monthly adjusted time series(last trading day of each month, monthly open, monthly high, monthly low,
        ///   monthly close, monthly adjusted close, monthly volume, monthly dividend) of the equity specified,
        ///   covering 20+ years of historical data.
        /// </summary>
        public const string TimeSeriesMonthlyAdjusted = "https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY_ADJUSTED&symbol={0}&apikey={1}";

        public const string TimeSeriesDailyAdjusted = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={0}&apikey={1}";

        //TIME_SERIES_WEEKLY
        public const string TimeSeriesWeeklyAdjusted = "https://www.alphavantage.co/query?function=TIME_SERIES_WEEKLY&symbol={0}&apikey={1}";

        //TIME_SERIES_DAILY
        public const string TimeSeriesDaily = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY";

        public const string Symbol = "&symbol=";
        public const string Key = "&apikey=";
        public const string OutPutSize = "&outputsize=";


    }
}
