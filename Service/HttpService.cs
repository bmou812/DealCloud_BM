using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace DealCloud_BM.Service
{
    public class HttpService
    {
        public string FetchRequest(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

                    using (HttpResponseMessage resp = client.SendAsync(request).Result)
                    {

                        if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Accepted)
                            return resp.Content.ReadAsStringAsync().Result;

                        else return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
