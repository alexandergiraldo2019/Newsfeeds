using Deloitte.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Deloitte.ServiceNewsfeeds.ExternalServices
{
    public class ServiceAction
    {
        //public List<Feed> Get(string url)
        //{
        //    HttpWebRequest WebRequest = (HttpWebRequest)WebRequest.Create(url);
        //    WebRequest.UserAgent = "Mozilla/5.0";
        //    WebRequest.Credentials = CredentialCache.DefaultCredentials;
        //    WebRequest.Proxy = null;

        //    HttpWebResponse WebResponse = (HttpWebResponse) WebRequest.GetResponse();
        //    Stream StreamData = WebResponse.GetResponseStream();
        //    StreamReader StreamDataReader = new StreamReader(StreamData);

        //    string Data = HttpUtility.HtmlDecode(StreamDataReader.ReadToEnd());

        //    return (JsonConvert.DeserializeObject<List<Feed>>(Data));
        //}


        public async Task<Response> Get<T>(
        string urlBase, string servicePrefix, string controller,
        string tokenType, string accessToken)
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}/{2}", servicePrefix, controller);

                var response = client.GetAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = model,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
