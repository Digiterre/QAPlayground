using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace OpenWeatherMapApi.Helpers
{

    public class RestHelper
    {
        public RestClient EndPoint = null;

        public RestClient SetEndPoint(string endPointUrl)
        {
            EndPoint = new RestClient(endPointUrl);
            return EndPoint;
        }

        public IRestResponse GetQuery(string query)
        {
            var request = new RestRequest(query, Method.GET);
            IRestResponse response = EndPoint.Execute(request);

            //IRestResponse content = response.Content;
            return response;
        }

        public string PostQuery(string query)
        {
            var request = new RestRequest(query, Method.POST);
            IRestResponse response = EndPoint.Execute(request);

            var content = response.Content;
            return content;
        }

        public string DeleteQuery(string query)
        {
            var request = new RestRequest(query, Method.DELETE);
            IRestResponse response = EndPoint.Execute(request);

            var content = response.Content;
            return content;
        }


        public void UpdateQuery(string query, string X)
        {
            var request = new RestRequest(query, Method.POST) { RequestFormat = DataFormat.Json };
            var body = ("" + X + "");
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            EndPoint.Execute(request);
        }
    }
}
