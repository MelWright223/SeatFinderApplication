using FindYourSeatsApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using FindYourSeatsAPI;

namespace FindYourSeatsApplication.ViewModels
{
    class TrainHomeViewModel
    {
        private string SearchStation;
        HttpClient client;
        private int StationId;
        private string StattionName;
        private int MaxCarriages;
        private double StationLat;
        private double StationLong;
        private List<StationData> stationData = new List<StationData>();
        
        public async void HomePageViewMode()
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "198.162.1.127";
            uri.Port = 44312;
            uri.Scheme = "http";
            uri.Path = "api/station";
            client = new HttpClient();

            HttpResponseMessage message = await client.GetAsync(uri.Uri);
            stationData = JsonConvert.DeserializeObject<List<StationData>>(await message.Content.ReadAsStringAsync());

            Console.WriteLine(stationData);

        }


        }
}
