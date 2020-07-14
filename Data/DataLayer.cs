using DealCloud_BM.Model;
using DealCloud_BM.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DealCloud_BM.Data
{
    public class DataLayer
    {
        public DataLayer()
        {

        }

        
        private List<string> _listOfSymbols = new List<string> { Constants.TradeSymbols.Symbol_Apple, Constants.TradeSymbols.Symbol_BankOfAmerica, Constants.TradeSymbols.Symbol_MicroSoft };

        public List<string> ListOfSymbols { get => _listOfSymbols; set => _listOfSymbols = value; }


       

        public ResponseModel GetAPIData(string uri)
        {
            
            HttpService serv = new HttpService();

            string json = serv.FetchRequest(uri);

            if (string.IsNullOrEmpty(json))
                return null;

            ResponseModel model = JsonConvert.DeserializeObject<ResponseModel>(json);

            if (model == null)
                return null;

            return model;
        }

        public Dictionary<string, TimeSeriesDaily> GetAPIDataList(string uri)
        {

            HttpService serv = new HttpService();

            string json = serv.FetchRequest(uri);

            if (string.IsNullOrEmpty(json))
                return null;

            dynamic data = JsonConvert.DeserializeObject(json);

            var jObj = (JObject)data;

            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jObj.ToString());
                    
            foreach (var time in dict)
            {
                if(time.Key == "Time Series (Daily)")
                {
                    var dit = JsonConvert.DeserializeObject<Dictionary<string, TimeSeriesDaily>>(time.Value.ToString());

                    return dit;
                }
            }
            

            return null;

            
        }
    }
}
