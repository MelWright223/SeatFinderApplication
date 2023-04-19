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
        private string getStationName;
        public string GetStationName
        {
            get { return getStationName; }
            set { getStationName = value;
                OnPropertyChanged(nameof(GetStationName));
            }
        }

    
    
        
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
                //Console.WriteLine("Hitpoint");
            }
            // Console.WriteLine("Latitude: " + location.Latitude);
            return (location);

        }
        public async Task<double>  Compare()
        {
            var getCurrentLat = await getLat();
            var getCurrentLong = await getLong();
            var getDeg = await getLatMin();
            
            
            var StationName = data.StationName = "BlackPool pit";
            var StationLat = data.StationLat = 50.3519;
            var StationLong = data.StationLong = -4.8420;
            //var ParLocation = data.GetOverallLoc(StationLat);
            Location ParStation = new Location(StationLat, StationLong);

            int deg = con.calcDegrees(StationLat);
            var min = con.CalMinutes(StationLat, deg);
            var distance = Location.CalculateDistance(getCurrentLat, getCurrentLong, ParStation, DistanceUnits.Miles);
            Console.WriteLine(distance);

            if (distance < 3)
            {

                    BindingContext = this;
                    GetStationName = StationName;
                    
            }
            else if (distance > 3)
            {
                BindingContext = this;
                GetStationName = "St Austell";
            }
                 
            else
            {
                    BindingContext = this;
                    GetStationName = "NO";
            }

       

            // }
            //if (getDeg < 
            // {
            //Console.WriteLine("True");
            //}
            return getDeg;
        }
       
        public async Task<double> getLat()
        {
            var location = await shell.GetCurrentLocation();
            double latDeg = location.Latitude;
            return latDeg;
        }
        public async Task<double> getLong()
        {
            var location = await shell.GetCurrentLocation();
            double longDeg = location.Longitude;
            return longDeg;
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
        public async Task<int> getLongAsync()
        {
            var location = await shell.GetCurrentLocation();
            Console.WriteLine(location);

            var latDeg = con.calcDegrees(location.Latitude);
            Console.WriteLine("Current Deg: " + latDeg);
            return latDeg;
        }
    }
}