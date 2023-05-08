using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FindYourSeatsApplication.Controller;
using FindYourSeatsApplication.Models;
using Xamarin.Essentials;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json;

namespace FindYourSeatsApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainHomePage : ContentPage
    {
       //dbConnection conn = new dbConnection();
        StationData data = new StationData();
        degreeConverter con = new degreeConverter();
        AppShell shell = new AppShell();
        private string SearchStation;
        static readonly HttpClient client = new HttpClient();
        private int StationId;
        private string StationName;
        private int MaxCarriages;
        private double StationLat;
        private double StationLong;
        private List<StationData> stationData = new List<StationData>();
        private ObservableCollection<StationData> _station;

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

            //var loc = Compare();

            // GetStations();
           
            

            _station = new ObservableCollection<StationData>();
            GetData();

            //client = new HttpClient();
            Title = "Train HomePage";
         
        }
        //public async Task<List<StationData>> GetStations()
        //{
        //Uri uri1 = new Uri(string.Format("127.0.0.1:5001", string.Empty));
        //UriBuilder uri = new UriBuilder();

        //HttpResponseMessage response = await httpClient.GetAsync("127.0.0.1:5001/api/station");


        //   Console.WriteLine(response.IsSuccessStatusCode);
        //  string content = await response.Content.ReadAsStringAsync();
        // var stationData = JsonConvert.DeserializeObject<List<StationData>>(content);
        // return stationData;




        //GetStationName = response;

        //}
        public string RemoveHTMLTags(string str)
        {
            System.Text.RegularExpressions.Regex rx =
            new System.Text.RegularExpressions.Regex("/<[^>]*> /g");
           rx.Replace(str, "");
            
            return str;
        }
        public ObservableCollection<StationData> Stations
        {
            get { return _station; }
            set { _station = value; }
            
        }
        public async void GetData()
        {
            var getCurrentLat = await getLat();
            var getCurrentLong = await getLong();
            var getDeg = await getLatMin();
           // int Longdeg;
           // int LatDeg;
            int CurrentLatDeg;
            int LongMin;
            int LatMin;
            int currentLongMin;
            int currentLatMin;


            HttpResponseMessage message = await client.GetAsync("http://192.168.1.127:44326/api/Station");
            
            Console.WriteLine(message.Content.ReadAsStringAsync());
            stationData = JsonConvert.DeserializeObject<List<StationData>>(await message.Content.ReadAsStringAsync());
            //string responseBody = await message.Content.ReadAsStringAsync();
            if (message.IsSuccessStatusCode){


               

                Console.WriteLine(stationData);
                foreach(StationData station in stationData)
                {
                    Stations.Add(station);
                   // Longdeg = con.calcDegrees(station.StationLong);
                   // CurrentLongDeg = con.calcDegrees(getCurrentLong);
                   // LatDeg = con.calcDegrees(station.StationLat);
                  //  CurrentLatDeg = con.calcDegrees(getCurrentLat);

                    Location Station = new Location(station.StationLat, station.StationLong);
                    var distance = Location.CalculateDistance(getCurrentLat, getCurrentLong, Station, DistanceUnits.Miles);
                    
                   if (distance < 3)
                   {

                      BindingContext = this;
                      GetStationName = station.StationName;

                   }
                             
                   
                }
                Console.WriteLine(GetStationName.ToString());

                //stationData = JsonConvert.DeserializeObject<List<StationData>>(STrippedString);
               // Console.WriteLine(Stations);
            }

            
        }
        public async void SetData()
        {
            
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