using Newtonsoft.Json.Linq;
using Report.Models;
using Report.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpClientProvider))]
namespace Report.Services
{
    class HttpClientProvider: IHttpClientProvider
    {
        //Dictionary<string,string> parameters = null, 
        #region Http Client Post
        public async Task<string> HttpPostMobileApi(Dictionary<string, string> parameters = null, string endpointurl = null)
        {
            string ControllerEndpoint = "";
            if (endpointurl != null)
            {
                ControllerEndpoint = endpointurl;
            }
            string ResultContent = "";
            HttpResponseMessage result;
            try
            {
                using (HttpClient ApiClient = new HttpClient())
                {
                    string url = DependencyService.Get<IConfigFetcher>().GetAsync("dataServiceUrl").Result;

                    ApiClient.BaseAddress = new Uri(@url);

                    ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    ApiClient.DefaultRequestHeaders.Add("myOrigin", "Origin");
                    if (parameters != null)
                    {
                        var content = new FormUrlEncodedContent(parameters);
                        var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), ControllerEndpoint);
                        requestMessage.Content = content;
                        //  StringContent stringContent = new StringContent(parameters, UnicodeEncoding.UTF8, "application/json");
                        //  result = await ApiClient.PostAsync(ControllerEndpoint, stringContent).ConfigureAwait(false);
                        result = await ApiClient.SendAsync(requestMessage).ConfigureAwait(false);
                    }
                    else
                    {
                        result = await ApiClient.PostAsync(ControllerEndpoint, null).ConfigureAwait(false);
                    }

                    if (result.IsSuccessStatusCode)
                    {
                        ResultContent = await result.Content.ReadAsStringAsync();
                    }
                    else
                        ResultContent = "false";
                }

                return ResultContent;
            }
            catch (WebException)
            {
                return "false";
            }
        }
        #endregion
    }
}
