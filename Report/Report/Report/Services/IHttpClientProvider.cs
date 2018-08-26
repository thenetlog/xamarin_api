using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Report.Services;

namespace Report.Services
{
    interface IHttpClientProvider
    {
        Task<string> HttpPostMobileApi(Dictionary<string, string> parameters, string endpointurl = null);
    }
}
//Dictionary<string,string> parameters, 