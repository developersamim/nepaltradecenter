using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenter.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NepalTradeCenter.ServiceLayer
{
    public class AdminRESTService
    {
        public dynamic getAllUser()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57494/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/admin").Result;

            if (response.IsSuccessStatusCode)
            {
                //var userList = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                var userList = response.Content.ReadAsStringAsync().Result;
                System.Diagnostics.Debug.WriteLine("consume web service success");
                //return Json(userList, JsonRequestBehavior.AllowGet);
                return userList;
            }
            return null;
        }
        
    }
}