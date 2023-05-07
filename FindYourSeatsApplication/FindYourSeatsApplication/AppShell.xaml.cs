using FindYourSeatsApplication.ViewModels;
using FindYourSeatsApplication.Views;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using FindYourSeatsApplication.Controller;
using FindYourSeatsApplication.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace FindYourSeatsApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //GetCurrentLocation();
           stationAsync();

        }

        public async Task<List<StationData>> stationAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("127.0.0.1:5001");




            Console.WriteLine("Blah Blah");
            string content = await response.Content.ReadAsStringAsync();
            var stationData = JsonConvert.DeserializeObject<List<StationData>>(content);
            return stationData;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        degreeConverter getDeg = new degreeConverter();
    
    private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
        public async Task<Location> GetCurrentLocation()
        {


                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                CancellationTokenSource cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Console.WriteLine("nbncfxhdshjfdhjtfcjymgv");
           

            }
           // Console.WriteLine("Latitude: " + location.Latitude);
            return (location);

        }
        public async Task<Location> GetLatDegreesAsync(double location)
        {
            var getLoc = await GetCurrentLocation();
           // var getCurrentDegLat = getDeg.calcDegrees(getLoc);

           
            return getLoc;
            
        }
       
      

    }
}
