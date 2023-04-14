using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FindYourSeatsApplication.Controller;
using FindYourSeatsApplication.Models;
using Xamarin.Essentials;
using System.Threading;

namespace FindYourSeatsApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainHomePage : ContentPage
    {
    databaseConn conn = new databaseConn();
        StationData data = new StationData();
        degreeConverter con = new degreeConverter();
        AppShell shell = new AppShell();
     
        public TrainHomePage()
        {
            InitializeComponent();

            var loc = Compare();
            
           





        }
        public async Task<Location> GetCurrentLocation()
        {


            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(5));
            CancellationTokenSource cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);

            if (location != null)
            {
                //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                Console.WriteLine("Hitpoint");
            }
            // Console.WriteLine("Latitude: " + location.Latitude);
            return (location);

        }
        public async Task<double>  Compare()
        {
            var getDeg = await getLatMin();
            var StationName = data.StationName = "Par";
            var StationLat = data.StationLat = 50.2560;
            var StationLong = data.StationLong = -4.7044;

            int deg = con.calcDegrees(StationLat);
            var min = con.CalMinutes(StationLat, deg);

            if (getDeg < 59)
            {

                if (getDeg <= min)
                {
                    Console.WriteLine("!");
                }

            }

            // }
            //if (getDeg < 
            // {
            //Console.WriteLine("True");
            //}
            return getDeg;
        }
        public async Task<int> getLatAsync()
        {
            var location =  await shell.GetCurrentLocation();
            Console.WriteLine(location);
            
            var latDeg = con.calcDegrees(location.Latitude);
            Console.WriteLine("Current Deg: " + latDeg);
            return latDeg;
        }
        public async Task<double> getLatMin()
        {
            var location = await shell.GetCurrentLocation();
            Console.WriteLine(location);
            var getDeg = await getLatAsync();

            //var getLat = await shell.GetLatDegreesAsync(getDeg);
            Console.WriteLine(getDeg);
            var latMin = con.CalMinutes(location.Latitude, getDeg);
            Console.WriteLine("mins: " + latMin);
            return latMin;
        }
    }
}