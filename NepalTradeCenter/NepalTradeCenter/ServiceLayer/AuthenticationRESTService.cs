using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenter.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace NepalTradeCenter.ServiceLayer
{
    public class AuthenticationRESTService
    {

        public Admin authenticate(string username, string password)
        {
            Admin admin = new Admin();

            TempUser tempUser = new TempUser();
            tempUser.username = username;
            tempUser.password = password;



            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57494/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = client.PostAsJsonAsync("api/authentication", tempUser).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                System.Diagnostics.Debug.WriteLine("consume web service success");
                admin = JsonConvert.DeserializeObject<Admin>(responseJson);
            }
            return admin;
        }
    }

    public class TempUser
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}